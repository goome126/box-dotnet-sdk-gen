using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class PromoteFileVersionRequestBodyArg {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("type")]
        public PromoteFileVersionRequestBodyArgTypeField Type { get; }

        public PromoteFileVersionRequestBodyArg(string id, PromoteFileVersionRequestBodyArgTypeField type) {
            Id = id;
            Type = type;
        }
    }
}