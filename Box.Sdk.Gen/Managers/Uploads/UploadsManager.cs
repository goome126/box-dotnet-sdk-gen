using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Sdk.Gen.Internal;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Managers {
    public class UploadsManager : IUploadsManager {
        public IAuthentication? Auth { get; init; }

        public NetworkSession NetworkSession { get; }

        public UploadsManager(NetworkSession? networkSession = default) {
            NetworkSession = networkSession ?? new NetworkSession();
        }
        /// <summary>
        /// Update a file's content. For file sizes over 50MB we recommend
        /// using the Chunk Upload APIs.
        /// 
        /// The `attributes` part of the body must come **before** the
        /// `file` part. Requests that do not follow this format when
        /// uploading the file will receive a HTTP `400` error with a
        /// `metadata_after_file_contents` error code.
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
        /// Request body of uploadFileVersion method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of uploadFileVersion method
        /// </param>
        /// <param name="headers">
        /// Headers of uploadFileVersion method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<Files> UploadFileVersionAsync(string fileId, UploadFileVersionRequestBody requestBody, UploadFileVersionQueryParams? queryParams = default, UploadFileVersionHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new UploadFileVersionQueryParams();
            headers = headers ?? new UploadFileVersionHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "if-match", StringUtils.ToStringRepresentation(headers.IfMatch) }, { "content-md5", StringUtils.ToStringRepresentation(headers.ContentMd5) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.UploadUrl, "/2.0/files/", StringUtils.ToStringRepresentation(fileId), "/content"), new FetchOptions(networkSession: this.NetworkSession) { Method = "POST", Parameters = queryParamsMap, Headers = headersMap, MultipartData = Array.AsReadOnly(new [] {new MultipartItem(partName: "attributes") { Data = SimpleJsonSerializer.Serialize(requestBody.Attributes) },new MultipartItem(partName: "file") { FileStream = requestBody.File, FileName = requestBody.FileFileName, ContentType = requestBody.FileContentType }}), ContentType = "multipart/form-data", ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Files>(response.Data);
        }

        /// <summary>
        /// Uploads a small file to Box. For file sizes over 50MB we recommend
        /// using the Chunk Upload APIs.
        /// 
        /// The `attributes` part of the body must come **before** the
        /// `file` part. Requests that do not follow this format when
        /// uploading the file will receive a HTTP `400` error with a
        /// `metadata_after_file_contents` error code.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of uploadFile method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of uploadFile method
        /// </param>
        /// <param name="headers">
        /// Headers of uploadFile method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<Files> UploadFileAsync(UploadFileRequestBody requestBody, UploadFileQueryParams? queryParams = default, UploadFileHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new UploadFileQueryParams();
            headers = headers ?? new UploadFileHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "content-md5", StringUtils.ToStringRepresentation(headers.ContentMd5) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.UploadUrl, "/2.0/files/content"), new FetchOptions(networkSession: this.NetworkSession) { Method = "POST", Parameters = queryParamsMap, Headers = headersMap, MultipartData = Array.AsReadOnly(new [] {new MultipartItem(partName: "attributes") { Data = SimpleJsonSerializer.Serialize(requestBody.Attributes) },new MultipartItem(partName: "file") { FileStream = requestBody.File, FileName = requestBody.FileFileName, ContentType = requestBody.FileContentType }}), ContentType = "multipart/form-data", ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Files>(response.Data);
        }

        /// <summary>
        /// Performs a check to verify that a file will be accepted by Box
        /// before you upload the entire file.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of preflightFileUploadCheck method
        /// </param>
        /// <param name="headers">
        /// Headers of preflightFileUploadCheck method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<UploadUrl> PreflightFileUploadCheckAsync(PreflightFileUploadCheckRequestBody? requestBody = default, PreflightFileUploadCheckHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            requestBody = requestBody ?? new PreflightFileUploadCheckRequestBody();
            headers = headers ?? new PreflightFileUploadCheckHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/2.0/files/content"), new FetchOptions(networkSession: this.NetworkSession) { Method = "OPTIONS", Headers = headersMap, Data = SimpleJsonSerializer.Serialize(requestBody), ContentType = "application/json", ResponseFormat = "json", Auth = this.Auth, CancellationToken = cancellationToken }).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<UploadUrl>(response.Data);
        }

    }
}