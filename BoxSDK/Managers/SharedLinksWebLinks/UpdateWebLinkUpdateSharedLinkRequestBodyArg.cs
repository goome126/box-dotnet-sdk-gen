using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateWebLinkUpdateSharedLinkRequestBodyArg {
        /// <summary>
        /// The settings for the shared link to update.
        /// </summary>
        [JsonPropertyName("shared_link")]
        public UpdateWebLinkUpdateSharedLinkRequestBodyArgSharedLinkField? SharedLink { get; set; } = default;

        public UpdateWebLinkUpdateSharedLinkRequestBodyArg() {
            
        }
    }
}