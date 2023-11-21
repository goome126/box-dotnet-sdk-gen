using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public interface IAvatarsManager {
        public IAuthentication? Auth { get; set; }

        public NetworkSession? NetworkSession { get; set; }

        public System.Threading.Tasks.Task<System.IO.Stream> GetUserAvatarAsync(string userId, GetUserAvatarHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null);

        public System.Threading.Tasks.Task<UserAvatar> CreateUserAvatarAsync(string userId, CreateUserAvatarRequestBodyArg requestBody, CreateUserAvatarHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null);

        public System.Threading.Tasks.Task DeleteUserAvatarAsync(string userId, DeleteUserAvatarHeadersArg? headers = default, System.Threading.CancellationToken? cancellationToken = null);

    }
}