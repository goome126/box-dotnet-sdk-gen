using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using StringExtensions;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class IntegrationMappingsManager : IIntegrationMappingsManager {
        public IAuthentication? Auth { get; set; } = default;

        public NetworkSession NetworkSession { get; set; }

        public IntegrationMappingsManager(NetworkSession networkSession = default) {
            NetworkSession = networkSession ?? new NetworkSession();
        }
        /// <summary>
        /// Lists [Slack integration mappings](https://support.box.com/hc/en-us/articles/4415585987859-Box-as-the-Content-Layer-for-Slack) in a users' enterprise.
        /// 
        /// You need Admin or Co-Admin role to
        /// use this endpoint.
        /// </summary>
        /// <param name="queryParams">
        /// Query parameters of getIntegrationMappingSlack method
        /// </param>
        /// <param name="headers">
        /// Headers of getIntegrationMappingSlack method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<IntegrationMappings> GetIntegrationMappingSlackAsync(GetIntegrationMappingSlackQueryParams? queryParams = default, GetIntegrationMappingSlackHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new GetIntegrationMappingSlackQueryParams();
            headers = headers ?? new GetIntegrationMappingSlackHeaders();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "marker", StringUtils.ToStringRepresentation(queryParams.Marker) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) }, { "partner_item_type", StringUtils.ToStringRepresentation(queryParams.PartnerItemType) }, { "partner_item_id", StringUtils.ToStringRepresentation(queryParams.PartnerItemId) }, { "box_item_id", StringUtils.ToStringRepresentation(queryParams.BoxItemId) }, { "box_item_type", StringUtils.ToStringRepresentation(queryParams.BoxItemType) }, { "is_manually_created", StringUtils.ToStringRepresentation(queryParams.IsManuallyCreated) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/integration_mappings/slack"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<IntegrationMappings>(response.Data);
        }

        /// <summary>
        /// Creates a [Slack integration mapping](https://support.box.com/hc/en-us/articles/4415585987859-Box-as-the-Content-Layer-for-Slack)
        /// by mapping a Slack channel to a Box item.
        /// 
        /// You need Admin or Co-Admin role to
        /// use this endpoint.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of createIntegrationMappingSlack method
        /// </param>
        /// <param name="headers">
        /// Headers of createIntegrationMappingSlack method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<IntegrationMapping> CreateIntegrationMappingSlackAsync(IntegrationMappingSlackCreateRequest requestBody, CreateIntegrationMappingSlackHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new CreateIntegrationMappingSlackHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/integration_mappings/slack"), new FetchOptions(method: "POST", headers: headersMap, data: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<IntegrationMapping>(response.Data);
        }

        /// <summary>
        /// Updates a [Slack integration mapping](https://support.box.com/hc/en-us/articles/4415585987859-Box-as-the-Content-Layer-for-Slack).
        /// Supports updating the Box folder ID and options.
        /// 
        /// You need Admin or Co-Admin role to
        /// use this endpoint.
        /// </summary>
        /// <param name="integrationMappingId">
        /// An ID of an integration mapping
        /// Example: "11235432"
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateIntegrationMappingSlackById method
        /// </param>
        /// <param name="headers">
        /// Headers of updateIntegrationMappingSlackById method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<IntegrationMapping> UpdateIntegrationMappingSlackByIdAsync(string integrationMappingId, UpdateIntegrationMappingSlackByIdRequestBody? requestBody = default, UpdateIntegrationMappingSlackByIdHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            requestBody = requestBody ?? new UpdateIntegrationMappingSlackByIdRequestBody();
            headers = headers ?? new UpdateIntegrationMappingSlackByIdHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/integration_mappings/slack/", StringUtils.ToStringRepresentation(integrationMappingId)), new FetchOptions(method: "PUT", headers: headersMap, data: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<IntegrationMapping>(response.Data);
        }

        /// <summary>
        /// Deletes a [Slack integration mapping](https://support.box.com/hc/en-us/articles/4415585987859-Box-as-the-Content-Layer-for-Slack).
        /// 
        /// 
        /// You need Admin or Co-Admin role to
        /// use this endpoint.
        /// </summary>
        /// <param name="integrationMappingId">
        /// An ID of an integration mapping
        /// Example: "11235432"
        /// </param>
        /// <param name="headers">
        /// Headers of deleteIntegrationMappingSlackById method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task DeleteIntegrationMappingSlackByIdAsync(string integrationMappingId, DeleteIntegrationMappingSlackByIdHeaders? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            headers = headers ?? new DeleteIntegrationMappingSlackByIdHeaders();
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat(this.NetworkSession.BaseUrls.BaseUrl, "/integration_mappings/slack/", StringUtils.ToStringRepresentation(integrationMappingId)), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
        }

    }
}