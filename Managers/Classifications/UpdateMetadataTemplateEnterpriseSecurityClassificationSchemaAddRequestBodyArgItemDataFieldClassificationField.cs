using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateMetadataTemplateEnterpriseSecurityClassificationSchemaAddRequestBodyArgItemDataFieldClassificationField {
        [JsonPropertyName("classificationDefinition")]
        public string ClassificationDefinition { get; }

        [JsonPropertyName("colorID")]
        public int? ColorId { get; }

        public UpdateMetadataTemplateEnterpriseSecurityClassificationSchemaAddRequestBodyArgItemDataFieldClassificationField(string classificationDefinition, int? colorId) {
            ClassificationDefinition = classificationDefinition;
            ColorId = colorId;
        }
    }
}