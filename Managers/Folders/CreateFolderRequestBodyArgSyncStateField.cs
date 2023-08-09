using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<CreateFolderRequestBodyArgSyncStateField>))]
    public enum CreateFolderRequestBodyArgSyncStateField {
        [Description("synced")]
        Synced,
        [Description("not_synced")]
        NotSynced,
        [Description("partially_synced")]
        PartiallySynced
    }
}