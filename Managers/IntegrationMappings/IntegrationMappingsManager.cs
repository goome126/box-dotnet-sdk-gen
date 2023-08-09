using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DictionaryExtensions;
using Fetch;
using Serializer;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class IntegrationMappingsManager {
        public IAuth Auth { get; }

        public NetworkSession NetworkSession { get; }

        public IntegrationMappingsManager(IAuth auth, NetworkSession networkSession) {
            Auth = auth;
            NetworkSession = networkSession;
        }
        public async System.Threading.Tasks.Task<IntegrationMappings> GetIntegrationMappingSlack(GetIntegrationMappingSlackQueryParamsArg queryParams, GetIntegrationMappingSlackHeadersArg headers) {
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string>() { { "marker", Utils.ToString(queryParams.Marker) }, { "limit", Utils.ToString(queryParams.Limit) }, { "partner_item_type", Utils.ToString(queryParams.PartnerItemType) }, { "partner_item_id", Utils.ToString(queryParams.PartnerItemId) }, { "box_item_id", Utils.ToString(queryParams.BoxItemId) }, { "box_item_type", Utils.ToString(queryParams.BoxItemType) }, { "is_manually_created", Utils.ToString(queryParams.IsManuallyCreated) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/integration_mappings/slack"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<IntegrationMappings>(response.Text);
        }

        public async System.Threading.Tasks.Task<IntegrationMapping> CreateIntegrationMappingSlack(IntegrationMappingSlackCreateRequest requestBody, CreateIntegrationMappingSlackHeadersArg headers) {
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/integration_mappings/slack"), new FetchOptions(method: "POST", headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<IntegrationMapping>(response.Text);
        }

        public async System.Threading.Tasks.Task<IntegrationMapping> UpdateIntegrationMappingSlackById(string integrationMappingId, UpdateIntegrationMappingSlackByIdRequestBodyArg requestBody, UpdateIntegrationMappingSlackByIdHeadersArg headers) {
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/integration_mappings/slack/", integrationMappingId), new FetchOptions(method: "PUT", headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<IntegrationMapping>(response.Text);
        }

        public async System.Threading.Tasks.Task DeleteIntegrationMappingSlackById(string integrationMappingId, DeleteIntegrationMappingSlackByIdHeadersArg headers) {
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/integration_mappings/slack/", integrationMappingId), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession));
        }

    }
}