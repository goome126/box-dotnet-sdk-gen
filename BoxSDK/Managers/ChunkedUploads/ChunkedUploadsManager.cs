using System.Text.Json.Serialization;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using DictionaryExtensions;
using Serializer;
using Fetch;
using StringExtensions;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class ChunkedUploadsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public ChunkedUploadsManager() {
            
        }
        public async System.Threading.Tasks.Task<UploadSession> CreateFileUploadSession(CreateFileUploadSessionRequestBodyArg requestBody, CreateFileUploadSessionHeadersArg? headers = default) {
            headers = headers ?? new CreateFileUploadSessionHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/upload_sessions"), new FetchOptions(method: "POST", headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<UploadSession>(response.Text);
        }

        public async System.Threading.Tasks.Task<UploadSession> CreateFileUploadSessionForExistingFile(string fileId, CreateFileUploadSessionForExistingFileRequestBodyArg requestBody, CreateFileUploadSessionForExistingFileHeadersArg? headers = default) {
            headers = headers ?? new CreateFileUploadSessionForExistingFileHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/", StringUtils.ToStringRepresentation(fileId), "/upload_sessions"), new FetchOptions(method: "POST", headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<UploadSession>(response.Text);
        }

        public async System.Threading.Tasks.Task<UploadSession> GetFileUploadSessionById(string uploadSessionId, GetFileUploadSessionByIdHeadersArg? headers = default) {
            headers = headers ?? new GetFileUploadSessionByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/upload_sessions/", StringUtils.ToStringRepresentation(uploadSessionId)), new FetchOptions(method: "GET", headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<UploadSession>(response.Text);
        }

        public async System.Threading.Tasks.Task<UploadedPart> UploadFilePart(string uploadSessionId, System.IO.Stream requestBody, UploadFilePartHeadersArg headers) {
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "digest", StringUtils.ToStringRepresentation(headers.Digest) }, { "content-range", StringUtils.ToStringRepresentation(headers.ContentRange) } }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/upload_sessions/", StringUtils.ToStringRepresentation(uploadSessionId)), new FetchOptions(method: "PUT", headers: headersMap, fileStream: requestBody, contentType: "application/octet-stream", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<UploadedPart>(response.Text);
        }

        public async System.Threading.Tasks.Task DeleteFileUploadSessionById(string uploadSessionId, DeleteFileUploadSessionByIdHeadersArg? headers = default) {
            headers = headers ?? new DeleteFileUploadSessionByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/upload_sessions/", StringUtils.ToStringRepresentation(uploadSessionId)), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession));
        }

        public async System.Threading.Tasks.Task<UploadParts> GetFileUploadSessionParts(string uploadSessionId, GetFileUploadSessionPartsQueryParamsArg? queryParams = default, GetFileUploadSessionPartsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFileUploadSessionPartsQueryParamsArg();
            headers = headers ?? new GetFileUploadSessionPartsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "offset", StringUtils.ToStringRepresentation(queryParams.Offset) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/upload_sessions/", StringUtils.ToStringRepresentation(uploadSessionId), "/parts"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<UploadParts>(response.Text);
        }

        public async System.Threading.Tasks.Task<Files> CreateFileUploadSessionCommit(string uploadSessionId, CreateFileUploadSessionCommitRequestBodyArg requestBody, CreateFileUploadSessionCommitHeadersArg headers) {
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "digest", StringUtils.ToStringRepresentation(headers.Digest) }, { "if-match", StringUtils.ToStringRepresentation(headers.IfMatch) }, { "if-none-match", StringUtils.ToStringRepresentation(headers.IfNoneMatch) } }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://upload.box.com/api/2.0/files/upload_sessions/", StringUtils.ToStringRepresentation(uploadSessionId), "/commit"), new FetchOptions(method: "POST", headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Files>(response.Text);
        }

    }
}