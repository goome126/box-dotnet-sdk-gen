using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class RetentionPolicyAssignmentAssignedToField {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("type")]
        public RetentionPolicyAssignmentAssignedToFieldTypeField Type { get; }

        public RetentionPolicyAssignmentAssignedToField(string id, RetentionPolicyAssignmentAssignedToFieldTypeField type) {
            Id = id;
            Type = type;
        }
    }
}