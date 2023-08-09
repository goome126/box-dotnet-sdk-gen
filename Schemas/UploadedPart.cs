using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class UploadedPart {
        [JsonPropertyName("part")]
        public UploadPart Part { get; }

        public UploadedPart(UploadPart part) {
            Part = part;
        }
    }
}