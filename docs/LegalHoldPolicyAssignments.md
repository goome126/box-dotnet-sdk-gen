# LegalHoldPolicyAssignmentsManager


- [List legal hold policy assignments](#list-legal-hold-policy-assignments)
- [Assign legal hold policy](#assign-legal-hold-policy)
- [Get legal hold policy assignment](#get-legal-hold-policy-assignment)
- [Unassign legal hold policy](#unassign-legal-hold-policy)
- [List current file versions for legal hold policy assignment](#list-current-file-versions-for-legal-hold-policy-assignment)
- [List previous file versions for legal hold policy assignment](#list-previous-file-versions-for-legal-hold-policy-assignment)

## List legal hold policy assignments

Retrieves a list of items a legal hold policy has been assigned to.

This operation is performed by calling function `GetLegalHoldPolicyAssignments`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-legal-hold-policy-assignments/).

*Currently we don't have an example for calling `GetLegalHoldPolicyAssignments` in integration tests*

### Arguments

- queryParams `GetLegalHoldPolicyAssignmentsQueryParamsArg`
  - Query parameters of getLegalHoldPolicyAssignments method
- headers `GetLegalHoldPolicyAssignmentsHeadersArg`
  - Headers of getLegalHoldPolicyAssignments method


### Returns

This function returns a value of type `LegalHoldPolicyAssignments`.

Returns a list of legal hold policy assignments.


## Assign legal hold policy

Assign a legal hold to a file, file version, folder, or user.

This operation is performed by calling function `CreateLegalHoldPolicyAssignment`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/post-legal-hold-policy-assignments/).

*Currently we don't have an example for calling `CreateLegalHoldPolicyAssignment` in integration tests*

### Arguments

- requestBody `CreateLegalHoldPolicyAssignmentRequestBodyArg`
  - Request body of createLegalHoldPolicyAssignment method
- headers `CreateLegalHoldPolicyAssignmentHeadersArg`
  - Headers of createLegalHoldPolicyAssignment method


### Returns

This function returns a value of type `LegalHoldPolicyAssignment`.

Returns a new legal hold policy assignment.


## Get legal hold policy assignment

Retrieve a legal hold policy assignment.

This operation is performed by calling function `GetLegalHoldPolicyAssignmentById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-legal-hold-policy-assignments-id/).

*Currently we don't have an example for calling `GetLegalHoldPolicyAssignmentById` in integration tests*

### Arguments

- legalHoldPolicyAssignmentId `string`
  - The ID of the legal hold policy assignment Example: "753465"
- headers `GetLegalHoldPolicyAssignmentByIdHeadersArg`
  - Headers of getLegalHoldPolicyAssignmentById method


### Returns

This function returns a value of type `LegalHoldPolicyAssignment`.

Returns a legal hold policy object.


## Unassign legal hold policy

Remove a legal hold from an item.

This is an asynchronous process. The policy will not be
fully removed yet when the response returns.

This operation is performed by calling function `DeleteLegalHoldPolicyAssignmentById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/delete-legal-hold-policy-assignments-id/).

*Currently we don't have an example for calling `DeleteLegalHoldPolicyAssignmentById` in integration tests*

### Arguments

- legalHoldPolicyAssignmentId `string`
  - The ID of the legal hold policy assignment Example: "753465"
- headers `DeleteLegalHoldPolicyAssignmentByIdHeadersArg`
  - Headers of deleteLegalHoldPolicyAssignmentById method


### Returns

This function returns a value of type `null`.

A blank response is returned if the assignment was
successfully deleted.


## List current file versions for legal hold policy assignment

Get a list of current file versions for a legal hold
assignment.

In some cases you may want to get previous file versions instead. In these
cases, use the `GET  /legal_hold_policy_assignments/:id/file_versions_on_hold`
API instead to return any previous versions of a file for this legal hold
policy assignment.

Due to ongoing re-architecture efforts this API might not return all file
versions held for this policy ID. Instead, this API will only return the
latest file version held in the newly developed architecture. The `GET
/file_version_legal_holds` API can be used to fetch current and past versions
of files held within the legacy architecture.

The `GET /legal_hold_policy_assignments?policy_id={id}` API can be used to
find a list of policy assignments for a given policy ID.

This operation is performed by calling function `GetLegalHoldPolicyAssignmentFileOnHold`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-legal-hold-policy-assignments-id-files-on-hold/).

*Currently we don't have an example for calling `GetLegalHoldPolicyAssignmentFileOnHold` in integration tests*

### Arguments

- legalHoldPolicyAssignmentId `string`
  - The ID of the legal hold policy assignment Example: "753465"
- queryParams `GetLegalHoldPolicyAssignmentFileOnHoldQueryParamsArg`
  - Query parameters of getLegalHoldPolicyAssignmentFileOnHold method
- headers `GetLegalHoldPolicyAssignmentFileOnHoldHeadersArg`
  - Headers of getLegalHoldPolicyAssignmentFileOnHold method


### Returns

This function returns a value of type `FileVersionLegalHolds`.

Returns the list of current file versions held under legal hold for a
specific legal hold policy assignment.


## List previous file versions for legal hold policy assignment

Get a list of previous file versions for a legal hold
assignment.

In some cases you may only need the latest file versions instead. In these
cases, use the `GET  /legal_hold_policy_assignments/:id/files_on_hold` API
instead to return any current (latest) versions of a file for this legal hold
policy assignment.

Due to ongoing re-architecture efforts this API might not return all files
held for this policy ID. Instead, this API will only return past file versions
held in the newly developed architecture. The `GET /file_version_legal_holds`
API can be used to fetch current and past versions of files held within the
legacy architecture.

The `GET /legal_hold_policy_assignments?policy_id={id}` API can be used to
find a list of policy assignments for a given policy ID.

This operation is performed by calling function `GetLegalHoldPolicyAssignmentFileVersionOnHold`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-legal-hold-policy-assignments-id-file-versions-on-hold/).

*Currently we don't have an example for calling `GetLegalHoldPolicyAssignmentFileVersionOnHold` in integration tests*

### Arguments

- legalHoldPolicyAssignmentId `string`
  - The ID of the legal hold policy assignment Example: "753465"
- queryParams `GetLegalHoldPolicyAssignmentFileVersionOnHoldQueryParamsArg`
  - Query parameters of getLegalHoldPolicyAssignmentFileVersionOnHold method
- headers `GetLegalHoldPolicyAssignmentFileVersionOnHoldHeadersArg`
  - Headers of getLegalHoldPolicyAssignmentFileVersionOnHold method


### Returns

This function returns a value of type `FileVersionLegalHolds`.

Returns the list of previous file versions held under legal hold for a
specific legal hold policy assignment.

