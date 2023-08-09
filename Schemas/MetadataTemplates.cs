using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class MetadataTemplates {
        [JsonPropertyName("limit")]
        public int? Limit { get; }

        [JsonPropertyName("next_marker")]
        public int? NextMarker { get; }

        [JsonPropertyName("prev_marker")]
        public int? PrevMarker { get; }

        [JsonPropertyName("entries")]
        public IReadOnlyList<MetadataTemplate> Entries { get; }

        public MetadataTemplates(int? limit, int? nextMarker, int? prevMarker, IReadOnlyList<MetadataTemplate> entries) {
            Limit = limit;
            NextMarker = nextMarker;
            PrevMarker = prevMarker;
            Entries = entries;
        }
    }
}