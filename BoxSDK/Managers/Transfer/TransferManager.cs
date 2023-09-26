using System.Text.Json.Serialization;
using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using StringExtensions;
using DictionaryExtensions;
using Serializer;
using Fetch;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class TransferManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public TransferManager() {
            
        }
        public async System.Threading.Tasks.Task<FolderFull> TransferOwnedFolder(string userId, TransferOwnedFolderRequestBodyArg requestBody, TransferOwnedFolderQueryParamsArg? queryParams = default, TransferOwnedFolderHeadersArg? headers = default) {
            queryParams = queryParams ?? new TransferOwnedFolderQueryParamsArg();
            headers = headers ?? new TransferOwnedFolderHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) }, { "notify", StringUtils.ToStringRepresentation(queryParams.Notify) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/users/", StringUtils.ToStringRepresentation(userId), "/folders/0"), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<FolderFull>(response.Text);
        }

    }
}