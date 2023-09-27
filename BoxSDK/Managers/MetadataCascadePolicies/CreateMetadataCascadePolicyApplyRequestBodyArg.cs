using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateMetadataCascadePolicyApplyRequestBodyArg {
        /// <summary>
        /// Describes the desired behavior when dealing with the conflict
        /// where a metadata template already has an instance applied
        /// to a child.
        /// 
        /// * `none` will preserve the existing value on the file
        /// * `overwrite` will force-apply the templates values over
        ///   any existing values.
        /// </summary>
        [JsonPropertyName("conflict_resolution")]
        public CreateMetadataCascadePolicyApplyRequestBodyArgConflictResolutionField ConflictResolution { get; set; }

        public CreateMetadataCascadePolicyApplyRequestBodyArg(CreateMetadataCascadePolicyApplyRequestBodyArgConflictResolutionField conflictResolution) {
            ConflictResolution = conflictResolution;
        }
    }
}