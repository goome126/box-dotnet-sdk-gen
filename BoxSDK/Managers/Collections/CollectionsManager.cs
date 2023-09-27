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
    public class CollectionsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public CollectionsManager() {
            
        }
        /// <summary>
        /// Retrieves all collections for a given user.
        /// 
        /// Currently, only the `favorites` collection
        /// is supported.
        /// </summary>
        /// <param name="queryParams">
        /// Query parameters of getCollections method
        /// </param>
        /// <param name="headers">
        /// Headers of getCollections method
        /// </param>
        public async System.Threading.Tasks.Task<Collections> GetCollectionsAsync(GetCollectionsQueryParamsArg? queryParams = default, GetCollectionsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetCollectionsQueryParamsArg();
            headers = headers ?? new GetCollectionsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) }, { "offset", StringUtils.ToStringRepresentation(queryParams.Offset) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/collections"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Collections>(response.Text);
        }

        /// <summary>
        /// Retrieves the files and/or folders contained within
        /// this collection.
        /// </summary>
        /// <param name="collectionId">
        /// The ID of the collection.
        /// Example: "926489"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getCollectionItems method
        /// </param>
        /// <param name="headers">
        /// Headers of getCollectionItems method
        /// </param>
        public async System.Threading.Tasks.Task<Items> GetCollectionItemsAsync(string collectionId, GetCollectionItemsQueryParamsArg? queryParams = default, GetCollectionItemsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetCollectionItemsQueryParamsArg();
            headers = headers ?? new GetCollectionItemsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) }, { "offset", StringUtils.ToStringRepresentation(queryParams.Offset) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/collections/", StringUtils.ToStringRepresentation(collectionId), "/items"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Items>(response.Text);
        }

    }
}