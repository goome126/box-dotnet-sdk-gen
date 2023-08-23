using System.IO;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateFileUploadSessionRequestBodyArg {
        [JsonPropertyName("folder_id")]
        public string FolderId { get; }

        [JsonPropertyName("file_size")]
        public long FileSize { get; }

        [JsonPropertyName("file_name")]
        public string FileName { get; }

        public CreateFileUploadSessionRequestBodyArg(string folderId, long fileSize, string fileName) {
            FolderId = folderId;
            FileSize = fileSize;
            FileName = fileName;
        }
    }
}