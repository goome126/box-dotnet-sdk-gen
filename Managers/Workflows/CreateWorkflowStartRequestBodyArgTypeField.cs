using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<CreateWorkflowStartRequestBodyArgTypeField>))]
    public enum CreateWorkflowStartRequestBodyArgTypeField {
        [Description("workflow_parameters")]
        WorkflowParameters
    }
}