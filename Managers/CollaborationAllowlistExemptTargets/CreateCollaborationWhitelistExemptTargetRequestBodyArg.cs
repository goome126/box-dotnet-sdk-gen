using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateCollaborationWhitelistExemptTargetRequestBodyArg {
        [JsonPropertyName("user")]
        public CreateCollaborationWhitelistExemptTargetRequestBodyArgUserField User { get; }

        public CreateCollaborationWhitelistExemptTargetRequestBodyArg(CreateCollaborationWhitelistExemptTargetRequestBodyArgUserField user) {
            User = user;
        }
    }
}