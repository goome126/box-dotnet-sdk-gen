using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;

namespace Box.Schemas {
    [JsonConverter(typeof(StringEnumConverter<TermsOfServiceEnterpriseFieldTypeField>))]
    public enum TermsOfServiceEnterpriseFieldTypeField {
        [Description("enterprise")]
        Enterprise
    }
}