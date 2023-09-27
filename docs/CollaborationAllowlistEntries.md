# CollaborationAllowlistEntriesManager


- [List allowed collaboration domains](#list-allowed-collaboration-domains)
- [Add domain to list of allowed collaboration domains](#add-domain-to-list-of-allowed-collaboration-domains)
- [Get allowed collaboration domain](#get-allowed-collaboration-domain)
- [Remove domain from list of allowed collaboration domains](#remove-domain-from-list-of-allowed-collaboration-domains)

## List allowed collaboration domains

Returns the list domains that have been deemed safe to create collaborations
for within the current enterprise.

This operation is performed by calling function `GetCollaborationWhitelistEntries`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-collaboration-whitelist-entries/).

*Currently we don't have an example for calling `GetCollaborationWhitelistEntries` in integration tests*

### Arguments

- queryParams `GetCollaborationWhitelistEntriesQueryParamsArg`
  - Query parameters of getCollaborationWhitelistEntries method
- headers `GetCollaborationWhitelistEntriesHeadersArg`
  - Headers of getCollaborationWhitelistEntries method


### Returns

This function returns a value of type `CollaborationAllowlistEntries`.

Returns a collection of domains that are allowed for collaboration.


## Add domain to list of allowed collaboration domains

Creates a new entry in the list of allowed domains to allow
collaboration for.

This operation is performed by calling function `CreateCollaborationWhitelistEntry`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/post-collaboration-whitelist-entries/).

*Currently we don't have an example for calling `CreateCollaborationWhitelistEntry` in integration tests*

### Arguments

- requestBody `CreateCollaborationWhitelistEntryRequestBodyArg`
  - Request body of createCollaborationWhitelistEntry method
- headers `CreateCollaborationWhitelistEntryHeadersArg`
  - Headers of createCollaborationWhitelistEntry method


### Returns

This function returns a value of type `CollaborationAllowlistEntry`.

Returns a new entry on the list of allowed domains.


## Get allowed collaboration domain

Returns a domain that has been deemed safe to create collaborations
for within the current enterprise.

This operation is performed by calling function `GetCollaborationWhitelistEntryById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-collaboration-whitelist-entries-id/).

*Currently we don't have an example for calling `GetCollaborationWhitelistEntryById` in integration tests*

### Arguments

- collaborationWhitelistEntryId `string`
  - The ID of the entry in the list. Example: "213123"
- headers `GetCollaborationWhitelistEntryByIdHeadersArg`
  - Headers of getCollaborationWhitelistEntryById method


### Returns

This function returns a value of type `CollaborationAllowlistEntry`.

Returns an entry on the list of allowed domains.


## Remove domain from list of allowed collaboration domains

Removes a domain from the list of domains that have been deemed safe to create
collaborations for within the current enterprise.

This operation is performed by calling function `DeleteCollaborationWhitelistEntryById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/delete-collaboration-whitelist-entries-id/).

*Currently we don't have an example for calling `DeleteCollaborationWhitelistEntryById` in integration tests*

### Arguments

- collaborationWhitelistEntryId `string`
  - The ID of the entry in the list. Example: "213123"
- headers `DeleteCollaborationWhitelistEntryByIdHeadersArg`
  - Headers of deleteCollaborationWhitelistEntryById method


### Returns

This function returns a value of type `null`.

A blank response is returned if the entry was
successfully deleted.

