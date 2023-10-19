using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;

namespace FrölundaArcade.Client.Helpers;

public class AuthMessageHandler : DelegatingHandler, IDisposable
{
    private readonly IAccessTokenProvider _provider;
    private readonly AuthenticationStateChangedHandler _authenticationStateChangedHandler;
    private AccessToken _lastToken;
    private AuthenticationHeaderValue _cachedHeader;

    public AuthMessageHandler(IAccessTokenProvider provider)
    {
        _provider = provider;

        // Invalidate the cached _lastToken when the authentication state changes
        if (_provider is AuthenticationStateProvider authStateProvider)
        {
            _authenticationStateChangedHandler = _ => _lastToken = null;
            authStateProvider.AuthenticationStateChanged += _authenticationStateChangedHandler;
        }
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.Now;

        if (_lastToken == null || now >= _lastToken.Expires.AddMinutes(-5))
        {
            var tokenResult = await _provider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token))
            {
                _lastToken = token;
                _cachedHeader = new AuthenticationHeaderValue("Bearer", _lastToken.Value);
            }
        }

        request.Headers.Authorization = _cachedHeader;

        return await base.SendAsync(request, cancellationToken);
    }

    void IDisposable.Dispose()
    {
        if (_provider is AuthenticationStateProvider authStateProvider)
        {
            authStateProvider.AuthenticationStateChanged -= _authenticationStateChangedHandler;
        }

        base.Dispose(true);
    }
}
