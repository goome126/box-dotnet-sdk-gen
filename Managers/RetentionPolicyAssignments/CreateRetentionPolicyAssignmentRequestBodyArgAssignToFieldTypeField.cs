using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<CreateRetentionPolicyAssignmentRequestBodyArgAssignToFieldTypeField>))]
    public enum CreateRetentionPolicyAssignmentRequestBodyArgAssignToFieldTypeField {
        [Description("enterprise")]
        Enterprise,
        [Description("folder")]
        Folder,
        [Description("metadata_template")]
        MetadataTemplate
    }
}