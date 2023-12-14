using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using StringExtensions;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class TrashedItemsManager : ITrashedItemsManager {
        public IAuthentication? Auth { get; set; } = default;

        public NetworkSession NetworkSession { get; set; }

        public TrashedItemsManager(NetworkSession networkSession = default) {
            NetworkSession = networkSession ?? new NetworkSession();
        }
        /// <summary>
        /// Retrieves the files and folders that have been moved
        /// to the trash.
        /// 
        /// Any attribute in the full files or folders objects can be passed
        /// in with the `fields` parameter to retrieve those specific
        /// attributes that are not returned by default.
        /// 
        /// This endpoint defaults to use offset-based pagination, yet also supports
        /// marker-based pagination using the `marker` parameter.
        /// </summary>
        /// <param name="queryParams">
        /// Query parameters of getFolderTrashItems method
        /// </param>
        /// <param name="headers">
        /// Headers of getFolderTrashItems method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<Items> GetFolderTrashItemsAsync(GetFolderTrashItemsQueryParams? queryParams = default, GetFolderTrashItemsHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new GetFolderTrashItemsQueryParams();
            headers = headers ?? new GetFolderTrashItemsHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) }, { "offset", StringUtils.ToStringRepresentation(queryParams.Offset) }, { "usemarker", StringUtils.ToStringRepresentation(queryParams.Usemarker) }, { "marker", StringUtils.ToStringRepresentation(queryParams.Marker) }, { "direction", StringUtils.ToStringRepresentation(queryParams.Direction) }, { "sort", StringUtils.ToStringRepresentation(queryParams.Sort) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/folders/trash/items"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Items>(response.Data);
        }

    }
}