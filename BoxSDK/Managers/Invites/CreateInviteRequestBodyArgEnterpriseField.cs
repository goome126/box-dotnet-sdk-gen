using System.Text.Json.Serialization;
using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateInviteRequestBodyArgEnterpriseField {
        /// <summary>
        /// The ID of the enterprise
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public CreateInviteRequestBodyArgEnterpriseField(string id) {
            Id = id;
        }
    }
}