using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StringExtensions;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class FilesManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public FilesManager() {
            
        }
        /// <summary>
        /// Retrieves the details about a file.
        /// </summary>
        /// <param name="fileId">
        /// The unique identifier that represents a file.
        /// 
        /// The ID for any file can be determined
        /// by visiting a file in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/files/123`
        /// the `file_id` is `123`.
        /// Example: "12345"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getFileById method
        /// </param>
        /// <param name="headers">
        /// Headers of getFileById method
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> GetFileByIdAsync(string fileId, GetFileByIdQueryParamsArg? queryParams = default, GetFileByIdHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFileByIdQueryParamsArg();
            headers = headers ?? new GetFileByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "if-none-match", StringUtils.ToStringRepresentation(headers.IfNoneMatch) }, { "boxapi", StringUtils.ToStringRepresentation(headers.Boxapi) }, { "x-rep-hints", StringUtils.ToStringRepresentation(headers.XRepHints) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId)), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Text);
        }

        /// <summary>
        /// Updates a file. This can be used to rename or move a file,
        /// create a shared link, or lock a file.
        /// </summary>
        /// <param name="fileId">
        /// The unique identifier that represents a file.
        /// 
        /// The ID for any file can be determined
        /// by visiting a file in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/files/123`
        /// the `file_id` is `123`.
        /// Example: "12345"
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateFileById method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of updateFileById method
        /// </param>
        /// <param name="headers">
        /// Headers of updateFileById method
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> UpdateFileByIdAsync(string fileId, UpdateFileByIdRequestBodyArg? requestBody = default, UpdateFileByIdQueryParamsArg? queryParams = default, UpdateFileByIdHeadersArg? headers = default) {
            requestBody = requestBody ?? new UpdateFileByIdRequestBodyArg();
            queryParams = queryParams ?? new UpdateFileByIdQueryParamsArg();
            headers = headers ?? new UpdateFileByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "if-match", StringUtils.ToStringRepresentation(headers.IfMatch) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId)), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Text);
        }

        /// <summary>
        /// Deletes a file, either permanently or by moving it to
        /// the trash.
        /// 
        /// The the enterprise settings determine whether the item will
        /// be permanently deleted from Box or moved to the trash.
        /// </summary>
        /// <param name="fileId">
        /// The unique identifier that represents a file.
        /// 
        /// The ID for any file can be determined
        /// by visiting a file in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/files/123`
        /// the `file_id` is `123`.
        /// Example: "12345"
        /// </param>
        /// <param name="headers">
        /// Headers of deleteFileById method
        /// </param>
        public async System.Threading.Tasks.Task DeleteFileByIdAsync(string fileId, DeleteFileByIdHeadersArg? headers = default) {
            headers = headers ?? new DeleteFileByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "if-match", StringUtils.ToStringRepresentation(headers.IfMatch) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId)), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a copy of a file.
        /// </summary>
        /// <param name="fileId">
        /// The unique identifier that represents a file.
        /// 
        /// The ID for any file can be determined
        /// by visiting a file in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/files/123`
        /// the `file_id` is `123`.
        /// Example: "12345"
        /// </param>
        /// <param name="requestBody">
        /// Request body of copyFile method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of copyFile method
        /// </param>
        /// <param name="headers">
        /// Headers of copyFile method
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> CopyFileAsync(string fileId, CopyFileRequestBodyArg requestBody, CopyFileQueryParamsArg? queryParams = default, CopyFileHeadersArg? headers = default) {
            queryParams = queryParams ?? new CopyFileQueryParamsArg();
            headers = headers ?? new CopyFileHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "/copy"), new FetchOptions(method: "POST", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Text);
        }

        /// <summary>
        /// Retrieves a thumbnail, or smaller image representation, of a file.
        /// 
        /// Sizes of `32x32`,`64x64`, `128x128`, and `256x256` can be returned in
        /// the `.png` format and sizes of `32x32`, `160x160`, and `320x320`
        /// can be returned in the `.jpg` format.
        /// 
        /// Thumbnails can be generated for the image and video file formats listed
        /// [found on our community site][1].
        /// 
        /// [1]: https://community.box.com/t5/Migrating-and-Previewing-Content/File-Types-and-Fonts-Supported-in-Box-Content-Preview/ta-p/327
        /// </summary>
        /// <param name="fileId">
        /// The unique identifier that represents a file.
        /// 
        /// The ID for any file can be determined
        /// by visiting a file in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/files/123`
        /// the `file_id` is `123`.
        /// Example: "12345"
        /// </param>
        /// <param name="extension">
        /// The file format for the thumbnail
        /// Example: "png"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getFileThumbnailById method
        /// </param>
        /// <param name="headers">
        /// Headers of getFileThumbnailById method
        /// </param>
        public async System.Threading.Tasks.Task<System.IO.Stream> GetFileThumbnailByIdAsync(string fileId, GetFileThumbnailByIdExtensionArg extension, GetFileThumbnailByIdQueryParamsArg? queryParams = default, GetFileThumbnailByIdHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFileThumbnailByIdQueryParamsArg();
            headers = headers ?? new GetFileThumbnailByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "min_height", StringUtils.ToStringRepresentation(queryParams.MinHeight) }, { "min_width", StringUtils.ToStringRepresentation(queryParams.MinWidth) }, { "max_height", StringUtils.ToStringRepresentation(queryParams.MaxHeight) }, { "max_width", StringUtils.ToStringRepresentation(queryParams.MaxWidth) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "/thumbnail.", StringUtils.ToStringRepresentation(extension)), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "binary", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return response.Content;
        }

    }
}