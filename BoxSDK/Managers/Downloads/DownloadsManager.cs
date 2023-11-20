using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StringExtensions;
using DictionaryExtensions;
using Fetch;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class DownloadsManager {
        public IAuth? Auth { get; set; } = default;

        public NetworkSession? NetworkSession { get; set; } = default;

        public DownloadsManager() {
            
        }
        /// <summary>
        /// Returns the contents of a file in binary format.
        /// </summary>
        /// <param name="fileId">
        /// The unique identifier that represents a file.
        /// 
        /// The ID for any file can be determined
        /// by visiting a file in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/files/123`
        /// the `file_id` is `123`.
        /// Example: "12345"
        /// </param>
        /// <param name="queryParams">
        /// Query parameters of downloadFile method
        /// </param>
        /// <param name="headers">
        /// Headers of downloadFile method
        /// </param>
        /// <param name="cancellationToken">
        /// Token used for request cancellation.
        /// </param>
        public async System.Threading.Tasks.Task<System.IO.Stream> DownloadFileAsync(string fileId, DownloadFileQueryParamsArg? queryParams = default, DownloadFileHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null) {
            queryParams = queryParams ?? new DownloadFileQueryParamsArg();
            headers = headers ?? new DownloadFileHeadersArg();
            Dictionary<string, string> queryParamsMap = Utils.PrepareParams(map: new Dictionary<string, string?>() { { "version", StringUtils.ToStringRepresentation(queryParams.Version) }, { "access_token", StringUtils.ToStringRepresentation(queryParams.AccessTokenField) } });
            Dictionary<string, string> headersMap = Utils.PrepareParams(map: DictionaryUtils.MergeDictionaries(new Dictionary<string, string?>() { { "range", StringUtils.ToStringRepresentation(headers.Range) }, { "boxapi", StringUtils.ToStringRepresentation(headers.Boxapi) } }, headers.ExtraHeaders));
            FetchResponse response = await HttpClientAdapter.FetchAsync(string.Concat("https://api.box.com/2.0/files/", StringUtils.ToStringRepresentation(fileId), "/content"), new FetchOptions(method: "GET", parameters: queryParamsMap, headers: headersMap, responseFormat: "binary", auth: this.Auth, networkSession: this.NetworkSession, cancellationToken: cancellationToken)).ConfigureAwait(false);
            return response.Content;
        }

    }
}