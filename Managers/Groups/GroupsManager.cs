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
    public class GroupsManager {
        public IAuth Auth { get; }

        public NetworkSession NetworkSession { get; }

        public GroupsManager(IAuth auth, NetworkSession networkSession) {
            Auth = auth;
            NetworkSession = networkSession;
        }
        public async System.Threading.Tasks.Task<Groups> GetGroups(GetGroupsQueryParamsArg queryParams, GetGroupsHeadersArg headers) {
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string>() { { "filter_term", Utils.ToString(queryParams.FilterTerm) }, { "fields", Utils.ToString(queryParams.Fields) }, { "limit", Utils.ToString(queryParams.Limit) }, { "offset", Utils.ToString(queryParams.Offset) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/groups"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Groups>(response.Text);
        }

        public async System.Threading.Tasks.Task<Group> CreateGroup(CreateGroupRequestBodyArg requestBody, CreateGroupQueryParamsArg queryParams, CreateGroupHeadersArg headers) {
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/groups"), new FetchOptions(method: "POST", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<Group>(response.Text);
        }

        public async System.Threading.Tasks.Task<GroupFull> GetGroupById(string groupId, GetGroupByIdQueryParamsArg queryParams, GetGroupByIdHeadersArg headers) {
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/groups/", groupId), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<GroupFull>(response.Text);
        }

        public async System.Threading.Tasks.Task<GroupFull> UpdateGroupById(string groupId, UpdateGroupByIdRequestBodyArg requestBody, UpdateGroupByIdQueryParamsArg queryParams, UpdateGroupByIdHeadersArg headers) {
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string>() { { "fields", Utils.ToString(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/groups/", groupId), new FetchOptions(method: "PUT", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonConverter.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession));
            return SimpleJsonConverter.Deserialize<GroupFull>(response.Text);
        }

        public async System.Threading.Tasks.Task DeleteGroupById(string groupId, DeleteGroupByIdHeadersArg headers) {
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string>() {  }, headers.ExtraHeaders));
            FetchResponse response = await SimpleHttpClient.Fetch(string.Concat("https://api.box.com/2.0/groups/", groupId), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession));
        }

    }
}