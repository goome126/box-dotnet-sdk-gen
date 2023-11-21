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
    public class SharedLinksFilesManager : ISharedLinksFilesManager {
        public IAuthentication? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public SharedLinksFilesManager() {
            
        }
        /// <summary>
        /// Returns the file represented by a shared link.
        /// 
        /// A shared file can be represented by a shared link,
        /// which can originate within the current enterprise or within another.
        /// 
        /// This endpoint allows an application to retrieve information about a
        /// shared file when only given a shared link.
        /// 
        /// The `shared_link_permission_options` array field can be returned
        /// by requesting it in the `fields` query parameter.
        /// </summary>
        /// <param name="headers">
        /// Headers of getSharedItems method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getSharedItems method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> GetSharedItemsAsync(GetSharedItemsHeadersArg headers, GetSharedItemsQueryParamsArg? queryParams = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new GetSharedItemsQueryParamsArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "if-none-match", StringUtils.ToStringRepresentation(headers.IfNoneMatch) }, { "boxapi", StringUtils.ToStringRepresentation(headers.Boxapi) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/shared_items"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Data);
        }

        /// <summary>
        /// Gets the information for a shared link on a file.
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
        /// Query parameters of getFileGetSharedLink method
        /// </param>
        /// <param name="headers">
        /// Headers of getFileGetSharedLink method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> GetFileGetSharedLinkAsync(string fileId, GetFileGetSharedLinkQueryParamsArg queryParams, GetFileGetSharedLinkHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new GetFileGetSharedLinkHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "#get_shared_link"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Data);
        }

        /// <summary>
        /// Adds a shared link to a file.
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
        /// Query parameters of updateFileAddSharedLink method
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateFileAddSharedLink method
        /// </param>
        /// <param name="headers">
        /// Headers of updateFileAddSharedLink method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> UpdateFileAddSharedLinkAsync(string fileId, UpdateFileAddSharedLinkQueryParamsArg queryParams, UpdateFileAddSharedLinkRequestBodyArg? requestBody = default, UpdateFileAddSharedLinkHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            requestBody = requestBody ?? new UpdateFileAddSharedLinkRequestBodyArg();
            headers = headers ?? new UpdateFileAddSharedLinkHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "#add_shared_link"), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, data: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Data);
        }

        /// <summary>
        /// Updates a shared link on a file.
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
        /// Query parameters of updateFileUpdateSharedLink method
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateFileUpdateSharedLink method
        /// </param>
        /// <param name="headers">
        /// Headers of updateFileUpdateSharedLink method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> UpdateFileUpdateSharedLinkAsync(string fileId, UpdateFileUpdateSharedLinkQueryParamsArg queryParams, UpdateFileUpdateSharedLinkRequestBodyArg? requestBody = default, UpdateFileUpdateSharedLinkHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            requestBody = requestBody ?? new UpdateFileUpdateSharedLinkRequestBodyArg();
            headers = headers ?? new UpdateFileUpdateSharedLinkHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "#update_shared_link"), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, data: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Data);
        }

        /// <summary>
        /// Removes a shared link from a file.
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
        /// Query parameters of updateFileRemoveSharedLink method
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateFileRemoveSharedLink method
        /// </param>
        /// <param name="headers">
        /// Headers of updateFileRemoveSharedLink method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<FileFull> UpdateFileRemoveSharedLinkAsync(string fileId, UpdateFileRemoveSharedLinkQueryParamsArg queryParams, UpdateFileRemoveSharedLinkRequestBodyArg? requestBody = default, UpdateFileRemoveSharedLinkHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            requestBody = requestBody ?? new UpdateFileRemoveSharedLinkRequestBodyArg();
            headers = headers ?? new UpdateFileRemoveSharedLinkHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "#remove_shared_link"), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, data: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<FileFull>(response.Data);
        }

    }
}