using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<UpdateWebhookByIdRequestBodyArgTargetFieldTypeField>))]
    public enum UpdateWebhookByIdRequestBodyArgTargetFieldTypeField {
        [Description("file")]
        File,
        [Description("folder")]
        Folder
    }
}