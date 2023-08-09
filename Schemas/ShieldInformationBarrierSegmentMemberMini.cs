using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class ShieldInformationBarrierSegmentMemberMini : ShieldInformationBarrierSegmentMemberBase {
        [JsonPropertyName("user")]
        public UserBase User { get; }

        public ShieldInformationBarrierSegmentMemberMini(string id, ShieldInformationBarrierSegmentMemberBaseTypeField type, UserBase user) : base(id, type) {
            User = user;
        }
    }
}