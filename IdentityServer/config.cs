using IdentityServer4;
using IdentityServer4.Models;
using System.Security.Principal;

namespace IdentityServer
{
    public static class config
    {
        public static IEnumerable<ApiScope> ApiScope =>
            new ApiScope[] {

            new ApiScope("catalog_fullpermission", "Catalog Api erişimi"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };


        public static IEnumerable<ApiResource> ApiResource =>
            new ApiResource[] {
            new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };
        public static IEnumerable<IdentityResource> IdentityResources =>

        new IdentityResource[] {
        new IdentityResources.Email(),
        new IdentityResources.OpenId(),//mutlaka olmalı
        new IdentityResources.Profile(),
        new IdentityResource(){Name="roles",DisplayName="Roles"
            ,Description="Kullanıcı Rolleri",UserClaims=new[]{"role" } }
        };

        public static IEnumerable<Client> Client =>
            new Client[] {

                new Client
                {
                    ClientName ="ApiClinet",
                    ClientId="cilentId",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"catalog_fullpermission"}
                },
                  new Client
{
    ClientName = "ApiClient",
    ClientId = "clientIdForUser",
    ClientSecrets = { new Secret("secret".Sha256()) },  // Güvenli bir şekilde hashlenmiş gizli anahtar
    
    AllowOfflineAccess = true, // Yenileme token'larını destekler
    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, // Şifre tabanlı yetkilendirme (password grant type)
    
    AllowedScopes = new List<string>
    {
        IdentityServerConstants.StandardScopes.Email,
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile,
        IdentityServerConstants.StandardScopes.OfflineAccess,
        "roles" // Kullanıcı rolleri erişimi
    },

    AccessTokenLifetime = 3600, // Erişim token'ı ömrü: 1 saat (3600 saniye)
    
    RefreshTokenExpiration = TokenExpiration.Absolute, // Mutlak süreli yenileme token'ı
    AbsoluteRefreshTokenLifetime = (int)TimeSpan.FromDays(60).TotalSeconds, // Yenileme token'ı ömrü: 60 gün
    RefreshTokenUsage = TokenUsage.ReUse // Aynı yenileme token'ı tekrar kullanılabilir
}
            };


    }
}
