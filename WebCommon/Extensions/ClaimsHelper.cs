using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebCommon.Extensions
{
    public class ClaimsHelper : ClaimAction
    {
        /// <summary>
        /// Creates a new ArrayToClaimsClaimAction.
        /// </summary>
        /// <param name="claimType">The value to use for Claim.Type when creating a Claim.</param>
        /// <param name="valueType">The value to use for Claim.ValueType when creating a Claim.</param>
        /// <param name="jsonKey">The top level key to look for in the json user data.</param>
        public ClaimsHelper(string claimType, string valueType, string jsonKey)
            : base(claimType, valueType)
        {
            JsonKey = jsonKey;
        }

        /// <summary>
        /// The top level key to look for in the json user data.
        /// </summary>
        public string JsonKey { get; }

        /// <inheritdoc />
        public override void Run(JObject userData, ClaimsIdentity identity, string issuer)
        {
            var value = userData?[JsonKey];
            if (value is JValue)
            {
                AddClaim(value?.ToString(), identity, issuer);
            }
            else if (value is JArray)
            {
                foreach (var v in value)
                {
                    AddClaim(v?.ToString(), identity, issuer);
                }
            }
        }

        private void AddClaim(string value, ClaimsIdentity identity, string issuer)
        {
            if (!string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(ClaimType, value, ValueType, issuer));
            }
        }

    }
}
