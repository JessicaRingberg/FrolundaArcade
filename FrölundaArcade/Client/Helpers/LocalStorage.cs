using Microsoft.JSInterop;
using System.Text.Json;

namespace FrölundaArcade.Client.Helpers;

public class LocalStorage
{
    private readonly IJSRuntime _js;

    public LocalStorage(IJSRuntime js)
    {
        _js = js;
    }

    public async Task Set<T>(string key, T value)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
    }

    public async Task<T> Get<T>(string key)
    {
        var value = await _js.InvokeAsync<string>("localStorage.getItem", key);

        return value is null ? default : JsonSerializer.Deserialize<T>(value);
    }
}
