using Unions;
using System.Text.Json.Serialization;
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
    public class TrashedFoldersManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public TrashedFoldersManager() {
            
        }
        /// <summary>
        /// Restores a folder that has been moved to the trash.
        /// 
        /// An optional new parent ID can be provided to restore the folder to in case the
        /// original folder has been deleted.
        /// 
        /// # Folder locking
        /// 
        /// During this operation, part of the file tree will be locked, mainly
        /// the source folder and all of its descendants, as well as the destination
        /// folder.
        /// 
        /// For the duration of the operation, no other move, copy, delete, or restore
        /// operation can performed on any of the locked folders.
        /// </summary>
        /// <param name="folderId">
        /// The unique identifier that represent a folder.
        /// 
        /// The ID for any folder can be determined
        /// by visiting this folder in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/folder/123`
        /// the `folder_id` is `123`.
        /// 
        /// The root folder of a Box account is
        /// always represented by the ID `0`.
        /// Example: "12345"
        /// </param>
        /// <param name="requestBody">
        /// Request body of restoreFolderFromTrash method
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of restoreFolderFromTrash method
        /// </param>
        /// <param name="headers">
        /// Headers of restoreFolderFromTrash method
        /// </param>
        public async System.Threading.Tasks.Task<TrashFolderRestored> RestoreFolderFromTrashAsync(string folderId, RestoreFolderFromTrashRequestBodyArg? requestBody = default, RestoreFolderFromTrashQueryParamsArg? queryParams = default, RestoreFolderFromTrashHeadersArg? headers = default) {
            requestBody = requestBody ?? new RestoreFolderFromTrashRequestBodyArg();
            queryParams = queryParams ?? new RestoreFolderFromTrashQueryParamsArg();
            headers = headers ?? new RestoreFolderFromTrashHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/folders/", StringUtils.ToStringRepresentation(folderId)), new FetchOptions(method: "POST", parameters: queryParamsMap, headers: headersMap, body: SimpleJsonSerializer.Serialize(requestBody), contentType: "application/json", responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<TrashFolderRestored>(response.Text);
        }

        /// <summary>
        /// Retrieves a folder that has been moved to the trash.
        /// 
        /// Please note that only if the folder itself has been moved to the
        /// trash can it be retrieved with this API call. If instead one of
        /// its parent folders was moved to the trash, only that folder
        /// can be inspected using the
        /// [`GET /folders/:id/trash`](e://get_folders_id_trash) API.
        /// 
        /// To list all items that have been moved to the trash, please
        /// use the [`GET /folders/trash/items`](e://get-folders-trash-items/)
        /// API.
        /// </summary>
        /// <param name="folderId">
        /// The unique identifier that represent a folder.
        /// 
        /// The ID for any folder can be determined
        /// by visiting this folder in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/folder/123`
        /// the `folder_id` is `123`.
        /// 
        /// The root folder of a Box account is
        /// always represented by the ID `0`.
        /// Example: "12345"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of getFolderTrash method
        /// </param>
        /// <param name="headers">
        /// Headers of getFolderTrash method
        /// </param>
        public async System.Threading.Tasks.Task<TrashFolder> GetFolderTrashAsync(string folderId, GetFolderTrashQueryParamsArg? queryParams = default, GetFolderTrashHeadersArg? headers = default) {
            queryParams = queryParams ?? new GetFolderTrashQueryParamsArg();
            headers = headers ?? new GetFolderTrashHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(new Dictionary<string, string?>() { { "fields", StringUtils.ToStringRepresentation(queryParams.Fields) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/folders/", StringUtils.ToStringRepresentation(folderId), "/trash"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "json", auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
            return SimpleJsonSerializer.Deserialize<TrashFolder>(response.Text);
        }

        /// <summary>
        /// Permanently deletes a folder that is in the trash.
        /// This action cannot be undone.
        /// </summary>
        /// <param name="folderId">
        /// The unique identifier that represent a folder.
        /// 
        /// The ID for any folder can be determined
        /// by visiting this folder in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/folder/123`
        /// the `folder_id` is `123`.
        /// 
        /// The root folder of a Box account is
        /// always represented by the ID `0`.
        /// Example: "12345"
        /// </param>
        /// <param name="headers">
        /// Headers of deleteFolderTrash method
        /// </param>
        public async System.Threading.Tasks.Task DeleteFolderTrashAsync(string folderId, DeleteFolderTrashHeadersArg? headers = default) {
            headers = headers ?? new DeleteFolderTrashHeadersArg();
            Dictionary<string, string> headersMap = Utils.PrepareParams(DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() {  }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/folders/", StringUtils.ToStringRepresentation(folderId), "/trash"), new FetchOptions(method: "DELETE", headers: headersMap, responseFormat: null, auth: this.Auth, networkSession: this.NetworkSession)).ConfigureAwait(false);
        }

    }
}