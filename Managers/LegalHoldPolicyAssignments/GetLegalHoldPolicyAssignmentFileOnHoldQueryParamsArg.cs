using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetLegalHoldPolicyAssignmentFileOnHoldQueryParamsArg {
        public string Marker { get; }

        public long? Limit { get; }

        public string Fields { get; }

        public GetLegalHoldPolicyAssignmentFileOnHoldQueryParamsArg(string marker, long? limit, string fields) {
            Marker = marker;
            Limit = limit;
            Fields = fields;
        }
    }
}