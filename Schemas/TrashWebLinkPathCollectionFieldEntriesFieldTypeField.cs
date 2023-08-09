using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;

namespace Box.Schemas {
    [JsonConverter(typeof(StringEnumConverter<TrashWebLinkPathCollectionFieldEntriesFieldTypeField>))]
    public enum TrashWebLinkPathCollectionFieldEntriesFieldTypeField {
        [Description("folder")]
        Folder
    }
}