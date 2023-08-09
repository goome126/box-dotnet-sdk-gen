using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetCollaborationWhitelistEntriesHeadersArg {
        public Dictionary<string, string> ExtraHeaders { get; }

        public GetCollaborationWhitelistEntriesHeadersArg(Dictionary<string, string> extraHeaders) {
            ExtraHeaders = extraHeaders;
        }
    }
}