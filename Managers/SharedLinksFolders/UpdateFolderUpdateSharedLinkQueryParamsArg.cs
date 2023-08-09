using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateFolderUpdateSharedLinkQueryParamsArg {
        public string Fields { get; }

        public UpdateFolderUpdateSharedLinkQueryParamsArg(string fields) {
            Fields = fields;
        }
    }
}