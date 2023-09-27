using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateMetadataTemplateEnterpriseSecurityClassificationSchemaUpdateRequestBodyArgDataField {
        /// <summary>
        /// A new label for the classification, as it will be
        /// shown in the web and mobile interfaces.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Additional details for the classification.
        /// </summary>
        [JsonPropertyName("classification")]
        public UpdateMetadataTemplateEnterpriseSecurityClassificationSchemaUpdateRequestBodyArgDataFieldClassificationField? Classification { get; set; } = default;

        public UpdateMetadataTemplateEnterpriseSecurityClassificationSchemaUpdateRequestBodyArgDataField(string key) {
            Key = key;
        }
    }
}