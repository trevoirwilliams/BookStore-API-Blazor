using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore_UI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var savedToken = await _localStorage.GetItemAsync<string>("authToken");
                if (string.IsNullOrWhiteSpace(savedToken))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
                var claims = ParseClaims(savedToken).ToList();
                var email = await _localStorage.GetItemAsync<string>("LoginName");
                claims.Add(new Claim(ClaimTypes.Name, email));
               
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

                return new AuthenticationState(user);
            }
            catch (Exception)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task LoggedIn(string email)
        {
            var savedToken = await _localStorage.GetItemAsync<string>("authToken");
            var claims = ParseClaims(savedToken).ToList();
            claims.Add(new Claim(ClaimTypes.Name, email));
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public void LoggedOut()
        {
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim> ParseClaims(string token)
        {
            var claims = new List<Claim>();
            var payload = token.Split('.')[1];
            var jsonBytes = DecodeClaims(payload);
            var keyValues = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            claims.AddRange(keyValues.Select(q => new Claim(q.Key, q.Value.ToString())));
            return claims;
        }

        private byte[] DecodeClaims(string payload)
        {
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }
            return Convert.FromBase64String(payload);
        }
    }
}
