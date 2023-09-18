using Box.Schemas;
using System.Threading.Tasks;

namespace Box
{
    /// <summary>
    /// Interface used for storing Access Token.
    /// </summary>
    public interface ITokenStorage
    {
        /// <summary>
        /// Stores access token.
        /// </summary>
        System.Threading.Tasks.Task Store(AccessToken token);

        /// <summary>
        /// Gets stored the token.
        /// </summary>
        /// <returns>An access token.</returns>
        Task<AccessToken> Get();

        /// <summary>
        /// Clears the stored token.
        /// </summary>
        System.Threading.Tasks.Task Clear();
    }
}
