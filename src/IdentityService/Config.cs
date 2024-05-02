using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        ];

    public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope(name: "batbetApp", displayName: "BatBet app full access"),
        ];

    public static IEnumerable<Client> Clients =>
        [
            new Client
            {
                ClientId = "postman",
                ClientName = "Postman",
                AllowedScopes = {"openid", "profile", "batbetApp"},
                RedirectUris = {"http://localhost:5000"},
                ClientSecrets = [new Secret("SuperSecret".Sha256())],
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword}
            },
        ];
}
