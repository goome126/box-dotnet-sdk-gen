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
    public class GroupsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public GroupsManager() {
            
        }
        /// <summary>
        /// Retrieves all of the groups for a given enterprise. The user
        /// must have admin permissions to inspect enterprise's groups.
        /// </summary>
        /// <param name="queryParams">
        /// Query parameters of getGroups method
        /// </param>
        /// <param name="headers">
        /// Headers of getGroups method
        /// </param>
        public async System.Threading.Tasks.Task<Groups> GetGroupsAsync(GetGroupsQueryParamsArg? queryParams = default, GetGroupsHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetGroupsQueryParamsArg();
            headers = headers ?? new GetGroupsHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "filter_term", StringUtils.ToStringRepresentation(queryParams.FilterTerm) }, { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) }, { "limit", StringUtils.ToStringRepresentation(queryParams.Limit) }, { "offset", StringUtils.ToStringRepresentation(queryParams.Offset) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/groups"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Groups>(response.Text);
        }

        /// <summary>
        /// Creates a new group of users in an enterprise. Only users with admin
        /// permissions can create new groups.
        /// </summary>
        /// <param name="requestBody">
        /// Request body of createGroup method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of createGroup method
        /// </param>
        /// <param name="headers">
        /// Headers of createGroup method
        /// </param>
        public async System.Threading.Tasks.Task<Group> CreateGroupAsync(CreateGroupRequestBodyArg requestBody, CreateGroupQueryParamsArg? queryParams = default, CreateGroupHeadersArg? headers = default) {
            queryParams = queryParams ?? new CreateGroupQueryParamsArg();
            headers = headers ?? new CreateGroupHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/groups"), new FetchOptions(method: "POST", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<Group>(response.Text);
        }

        /// <summary>
        /// Retrieves information about a group. Only members of this
        /// group or users with admin-level permissions will be able to
        /// use this API.
        /// </summary>
        /// <param name="groupId">
        /// The ID of the group.
        /// Example: "57645"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getGroupById method
        /// </param>
        /// <param name="headers">
        /// Headers of getGroupById method
        /// </param>
        public async System.Threading.Tasks.Task<GroupFull> GetGroupByIdAsync(string groupId, GetGroupByIdQueryParamsArg? queryParams = default, GetGroupByIdHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetGroupByIdQueryParamsArg();
            headers = headers ?? new GetGroupByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/groups/", StringUtils.ToStringRepresentation(groupId)), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<GroupFull>(response.Text);
        }

        /// <summary>
        /// Updates a specific group. Only admins of this
        /// group or users with admin-level permissions will be able to
        /// use this API.
        /// </summary>
        /// <param name="groupId">
        /// The ID of the group.
        /// Example: "57645"
        /// </param>
        /// <param name="requestBody">
        /// Request body of updateGroupById method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of updateGroupById method
        /// </param>
        /// <param name="headers">
        /// Headers of updateGroupById method
        /// </param>
        public async System.Threading.Tasks.Task<GroupFull> UpdateGroupByIdAsync(string groupId, UpdateGroupByIdRequestBodyArg? requestBody = default, UpdateGroupByIdQueryParamsArg? queryParams = default, UpdateGroupByIdHeadersArg? headers = default) {
            requestBody = requestBody ?? new UpdateGroupByIdRequestBodyArg();
            queryParams = queryParams ?? new UpdateGroupByIdQueryParamsArg();
            headers = headers ?? new UpdateGroupByIdHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/groups/", StringUtils.ToStringRepresentation(groupId)), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<GroupFull>(response.Text);
        }

        /// <summary>
        /// Permanently deletes a group. Only users with
        /// admin-level permissions will be able to use this API.
        /// </summary>
        /// <param name="groupId">
        /// The ID of the group.
        /// Example: "57645"
        /// </param>
        /// <param name="headers">
        /// Headers of deleteGroupById method
        /// </param>
        public async System.Threading.Tasks.Task DeleteGroupByIdAsync(string groupId, DeleteGroupByIdHeadersArg? headers = default) {
            headers = headers ?? new DeleteGroupByIdHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/groups/", StringUtils.ToStringRepresentation(groupId)), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
        }

    }
}