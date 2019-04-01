using IdentityServer4;
using IdentityServer4.Models;
using IdServer.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdServer.Models.InitData
{
    public static class Config
    {
        private static string IdServerClientID = "49970FAA-9746-48C7-BBCC-8DF0F1B44E78";
        private static string ClientID = Guid.NewGuid().ToString();

        public static IEnumerable<User> GetUsers()
        {
            var passwordHasher = new PasswordHasher<User>();

            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = "admin",
                    Email = "itadmin@itflight.com",
                    GivenName  = "Администратор",
                    FamilyName = "IdServer",
                    FullName = "Администратор IdServer",
                    IsActive = true,
                    Password = "Passw0rd123"
                }
            };

            foreach (var user in users)
            {
                user.Password = passwordHasher.HashPassword(user, user.Password);
            }

            return users;
        }

        internal static IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    DisplayName = "Администратор",
                    Name = "admin",
                    ClientId = IdServerClientID
                },
                new Role()
                {
                    DisplayName = "Потребител",
                    Name = "User",
                    ClientId = IdServerClientID
                },
                new Role()
                {
                    DisplayName = "Потребител",
                    Name = "User",
                    ClientId = ClientID
                }
            };

            return roles;
        }



        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(){ DisplayName = "Идентичност"},
                new IdentityResources.Profile(){ DisplayName = "Профилни данни"},
                new IdentityResources.Email(){ DisplayName = "Електронна поща"},
                new IdentityResource("roles", "Потребителски роли", new List<string>(){ "role" }),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = IdServerClientID,
                    ClientName = "Управление на потребители",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequireConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://idserver.com/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://idserver.com/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles"
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client()
                {
                    ClientId = ClientID,
                    ClientName = "Тестово приложение",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequireConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://test-client.com/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://test-client.com/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles"
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
