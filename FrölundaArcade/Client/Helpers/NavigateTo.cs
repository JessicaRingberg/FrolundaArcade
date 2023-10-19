using Microsoft.AspNetCore.Components;

namespace FrölundaArcade.Client.Helpers;

public class NavigateTo
{
    private readonly NavigationManager _nav;

    public NavigateTo(NavigationManager nav)
    {
        _nav = nav;
    }

    public void GameDetails(int id) => _nav.NavigateTo($"/game-details/{id}");
}
