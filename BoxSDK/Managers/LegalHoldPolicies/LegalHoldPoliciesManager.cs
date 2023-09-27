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
    public class LegalHoldPoliciesManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public LegalHoldPoliciesManager() {
            
        }
        /// <summary>
        /// Retrieves a list of legal hold policies that belong to
        /// an enterprise.
        /// </summary>
        /// <param name="queryParams">
        /// Query parameters of getLegalHoldPolicies method
        /// </param>
        /// <param name="headers">
        /// Headers of getLegalHoldPolicies method
        /// </param>
        public async System.Threading.Tasks.Task<LegalHoldPolicies> GetLegalHoldPoliciesAsync(GetLegalHoldPoliciesQueryParamsArg? queryParams = default, GetLegalHoldPoliciesHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetLegalHoldPoliciesQueryParamsArg();
            headers = headers ?? new GetLegalHoldPoliciesHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "policy_name", StringUtils.ToStringRepresentation(queryParams.PolicyName) }, { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) }, { "marker", StringUtils.ToStringRepresentation(queryParams.Marker) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/legal_hold_policies"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<LegalHoldPolicies>(response.Text);
        }

        /// <summary>
        /// Create a new legal hold policy.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of createLegalHoldPolicy method
        /// </param>
        /// <param name="headers">
        /// Headers of createLegalHoldPolicy method
        /// </param>
        public async System.Threading.Tasks.Task<LegalHoldPolicy> CreateLegalHoldPolicyAsync(CreateLegalHoldPolicyRequestBodyArg requestBody, CreateLegalHoldPolicyHeadersArg? headers = default) {
            headers = headers ?? new CreateLegalHoldPolicyHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/legal_hold_policies"), new FetchOptions(method: "POST", headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<LegalHoldPolicy>(response.Text);
        }

        /// <summary>
        /// Retrieve a legal hold policy.
        /// </summary>
        /// <param name="legalHoldPolicyId">
        /// The ID of the legal hold policy
        /// Example: "324432"
        /// </param>
        /// <param name="headers">
        /// Headers of getLegalHoldPolicyById method
        /// </param>
        public async System.Threading.Tasks.Task<LegalHoldPolicy> GetLegalHoldPolicyByIdAsync(string legalHoldPolicyId, GetLegalHoldPolicyByIdHeadersArg? headers = default) {
            headers = headers ?? new GetLegalHoldPolicyByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/legal_hold_policies/", StringUtils.ToStringRepresentation(legalHoldPolicyId)), new FetchOptions(method: "GET", headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<LegalHoldPolicy>(response.Text);
        }

        /// <summary>
        /// Update legal hold policy.
        /// </summary>
        /// <param name="legalHoldPolicyId">
        /// The ID of the legal hold policy
        /// Example: "324432"
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateLegalHoldPolicyById method
        /// </param>
        /// <param name="headers">
        /// Headers of updateLegalHoldPolicyById method
        /// </param>
        public async System.Threading.Tasks.Task<LegalHoldPolicy> UpdateLegalHoldPolicyByIdAsync(string legalHoldPolicyId, UpdateLegalHoldPolicyByIdRequestBodyArg? requestBody = default, UpdateLegalHoldPolicyByIdHeadersArg? headers = default) {
            requestBody = requestBody ?? new UpdateLegalHoldPolicyByIdRequestBodyArg();
            headers = headers ?? new UpdateLegalHoldPolicyByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/legal_hold_policies/", StringUtils.ToStringRepresentation(legalHoldPolicyId)), new FetchOptions(method: "PUT", headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<LegalHoldPolicy>(response.Text);
        }

        /// <summary>
        /// Delete an existing legal hold policy.
        /// 
        /// This is an asynchronous process. The policy will not be
        /// fully deleted yet when the response returns.
        /// </summary>
        /// <param name="legalHoldPolicyId">
        /// The ID of the legal hold policy
        /// Example: "324432"
        /// </param>
        /// <param name="headers">
        /// Headers of deleteLegalHoldPolicyById method
        /// </param>
        public async System.Threading.Tasks.Task DeleteLegalHoldPolicyByIdAsync(string legalHoldPolicyId, DeleteLegalHoldPolicyByIdHeadersArg? headers = default) {
            headers = headers ?? new DeleteLegalHoldPolicyByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/legal_hold_policies/", StringUtils.ToStringRepresentation(legalHoldPolicyId)), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
        }

    }
}