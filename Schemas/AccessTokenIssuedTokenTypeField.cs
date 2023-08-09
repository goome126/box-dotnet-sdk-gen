using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;

namespace Box.Schemas {
    [JsonConverter(typeof(StringEnumConverter<AccessTokenIssuedTokenTypeField>))]
    public enum AccessTokenIssuedTokenTypeField {
        [Description("urn:ietf:params:oauth:token-type:access_token")]
        UrnIetfParamsOauthTokenTypeAccessToken
    }
}