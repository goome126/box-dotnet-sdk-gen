using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class FilesUnderRetention {
        [JsonPropertyName("limit")]
        public long? Limit { get; }

        [JsonPropertyName("next_marker")]
        public long? NextMarker { get; }

        [JsonPropertyName("prev_marker")]
        public long? PrevMarker { get; }

        [JsonPropertyName("entries")]
        public IReadOnlyList<FileMini> Entries { get; }

        public FilesUnderRetention(long? limit, long? nextMarker, long? prevMarker, IReadOnlyList<FileMini> entries) {
            Limit = limit;
            NextMarker = nextMarker;
            PrevMarker = prevMarker;
            Entries = entries;
        }
    }
}