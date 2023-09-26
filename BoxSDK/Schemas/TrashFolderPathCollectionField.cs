using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json;

namespace Box.Schemas {
    public class TrashFolderPathCollectionField {
        /// <summary>
        /// The number of folders in this list.
        /// </summary>
        [JsonPropertyName("total_count")]
        public long TotalCount { get; set; }

        /// <summary>
        /// Array of folders for this item's path collection
        /// </summary>
        [JsonPropertyName("entries")]
        public IReadOnlyList<TrashFolderPathCollectionFieldEntriesField> Entries { get; set; }

        public TrashFolderPathCollectionField(long totalCount, IReadOnlyList<TrashFolderPathCollectionFieldEntriesField> entries) {
            TotalCount = totalCount;
            Entries = entries;
        }
    }
}