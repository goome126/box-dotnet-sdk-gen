# MembershipsManager


- [List user's groups](#list-users-groups)
- [List members of group](#list-members-of-group)
- [Add user to group](#add-user-to-group)
- [Get group membership](#get-group-membership)
- [Update group membership](#update-group-membership)
- [Remove user from group](#remove-user-from-group)

## List user's groups

Retrieves all the groups for a user. Only members of this
group or users with admin-level permissions will be able to
use this API.

This operation is performed by calling function `GetUserMemberships`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-users-id-memberships/).

<!-- sample get_users_id_memberships -->
```
await client.Memberships.GetUserMembershipsAsync(user.Id).ConfigureAwait(false)
```

### Arguments

- userId `string`
  - The ID of the user. Example: "12345"
- queryParams `GetUserMembershipsQueryParamsArg`
  - Query parameters of getUserMemberships method
- headers `GetUserMembershipsHeadersArg`
  - Headers of getUserMemberships method


### Returns

This function returns a value of type `GroupMemberships`.

Returns a collection of membership objects. If there are no
memberships, an empty collection will be returned.


## List members of group

Retrieves all the members for a group. Only members of this
group or users with admin-level permissions will be able to
use this API.

This operation is performed by calling function `GetGroupMemberships`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-groups-id-memberships/).

<!-- sample get_groups_id_memberships -->
```
await client.Memberships.GetGroupMembershipsAsync(group.Id).ConfigureAwait(false)
```

### Arguments

- groupId `string`
  - The ID of the group. Example: "57645"
- queryParams `GetGroupMembershipsQueryParamsArg`
  - Query parameters of getGroupMemberships method
- headers `GetGroupMembershipsHeadersArg`
  - Headers of getGroupMemberships method


### Returns

This function returns a value of type `GroupMemberships`.

Returns a collection of membership objects. If there are no
memberships, an empty collection will be returned.


## Add user to group

Creates a group membership. Only users with
admin-level permissions will be able to use this API.

This operation is performed by calling function `CreateGroupMembership`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/post-group-memberships/).

<!-- sample post_group_memberships -->
```
await client.Memberships.CreateGroupMembershipAsync(new CreateGroupMembershipRequestBodyArg(user: new CreateGroupMembershipRequestBodyArgUserField(id: user.Id), group: new CreateGroupMembershipRequestBodyArgGroupField(id: group.Id))).ConfigureAwait(false)
```

### Arguments

- requestBody `CreateGroupMembershipRequestBodyArg`
  - Request body of createGroupMembership method
- queryParams `CreateGroupMembershipQueryParamsArg`
  - Query parameters of createGroupMembership method
- headers `CreateGroupMembershipHeadersArg`
  - Headers of createGroupMembership method


### Returns

This function returns a value of type `GroupMembership`.

Returns a new group membership object.


## Get group membership

Retrieves a specific group membership. Only admins of this
group or users with admin-level permissions will be able to
use this API.

This operation is performed by calling function `GetGroupMembershipById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/get-group-memberships-id/).

<!-- sample get_group_memberships_id -->
```
await client.Memberships.GetGroupMembershipByIdAsync(groupMembership.Id).ConfigureAwait(false)
```

### Arguments

- groupMembershipId `string`
  - The ID of the group membership. Example: "434534"
- queryParams `GetGroupMembershipByIdQueryParamsArg`
  - Query parameters of getGroupMembershipById method
- headers `GetGroupMembershipByIdHeadersArg`
  - Headers of getGroupMembershipById method


### Returns

This function returns a value of type `GroupMembership`.

Returns the group membership object.


## Update group membership

Updates a user's group membership. Only admins of this
group or users with admin-level permissions will be able to
use this API.

This operation is performed by calling function `UpdateGroupMembershipById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/put-group-memberships-id/).

<!-- sample put_group_memberships_id -->
```
await client.Memberships.UpdateGroupMembershipByIdAsync(groupMembership.Id, new UpdateGroupMembershipByIdRequestBodyArg(role: UpdateGroupMembershipByIdRequestBodyArgRoleField.Admin)).ConfigureAwait(false)
```

### Arguments

- groupMembershipId `string`
  - The ID of the group membership. Example: "434534"
- requestBody `UpdateGroupMembershipByIdRequestBodyArg`
  - Request body of updateGroupMembershipById method
- queryParams `UpdateGroupMembershipByIdQueryParamsArg`
  - Query parameters of updateGroupMembershipById method
- headers `UpdateGroupMembershipByIdHeadersArg`
  - Headers of updateGroupMembershipById method


### Returns

This function returns a value of type `GroupMembership`.

Returns a new group membership object.


## Remove user from group

Deletes a specific group membership. Only admins of this
group or users with admin-level permissions will be able to
use this API.

This operation is performed by calling function `DeleteGroupMembershipById`.

See the endpoint docs at
[API Reference](https://developer.box.com/reference/delete-group-memberships-id/).

<!-- sample delete_group_memberships_id -->
```
await client.Memberships.DeleteGroupMembershipByIdAsync(groupMembership.Id).ConfigureAwait(false)
```

### Arguments

- groupMembershipId `string`
  - The ID of the group membership. Example: "434534"
- headers `DeleteGroupMembershipByIdHeadersArg`
  - Headers of deleteGroupMembershipById method


### Returns

This function returns a value of type `null`.

A blank response is returned if the membership was
successfully deleted.

