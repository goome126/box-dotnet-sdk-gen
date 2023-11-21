using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using System;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateClassificationRequestBodyArgDataField {
        /// <summary>
        /// A new label for the classification, as it will be
        /// shown in the web and mobile interfaces.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// A static configuration for the classification.
        /// </summary>
        [JsonPropertyName("staticConfig")]
        public UpdateClassificationRequestBodyArgDataFieldStaticConfigField? StaticConfig { get; set; } = default;

        public UpdateClassificationRequestBodyArgDataField(string key) {
            Key = key;
        }
    }
}