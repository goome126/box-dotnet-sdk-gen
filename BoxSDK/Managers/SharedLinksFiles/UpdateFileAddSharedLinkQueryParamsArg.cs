using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateFileAddSharedLinkQueryParamsArg {
        /// <summary>
        /// Explicitly request the `shared_link` fields
        /// to be returned for this item.
        /// </summary>
        public string Fields { get; set; }

        public UpdateFileAddSharedLinkQueryParamsArg(string fields) {
            Fields = fields;
        }
    }
}