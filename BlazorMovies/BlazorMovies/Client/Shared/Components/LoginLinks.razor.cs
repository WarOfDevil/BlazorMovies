﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Shared.Components
{
    public partial class LoginLinks
    {
        [Inject]
        protected NavigationManager NavMan { get; set; }

        [Inject]
        protected SignOutSessionStateManager SignOutManager { get; set; }

        private async Task BeginSignOut(MouseEventArgs args)
        {
            await SignOutManager.SetSignOutState();
            NavMan.NavigateTo("authentication/logout");
        }
    }
}
