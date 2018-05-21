using System.Threading.Tasks;
using HTTP.Security;

namespace HTTP.Client.Security
{
    /// <summary>
    /// Implementers of this interface provide access to an
    /// authentication token.
    /// </summary>
    public interface IAuthTokenProvider
    {
        /// <summary>
        /// Gets an authentication token that can be used to
        /// prove the identity of someone or something.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        AuthToken Token { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has an auth token or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has an auth token; otherwise, <c>false</c>.
        /// </value>
        bool HasToken { get; }

        /// <summary>
        /// Gets a boolean indicator whether authentication is enabled
        /// </summary>
        bool IsAuthenticationEnabled { get; }

        /// <summary>
        /// Method forces a token to be revoked from the current service instance, and new token to be requested.
        /// </summary>
        /// <param name="token">The failed authorization token to be revoked.</param>
        /// <returns>Returns boolean value indicating success.</returns>
        Task<bool> ReinstateToken(string token);

        /// <summary>
        /// Checks the connectivity to whichever external system is providing the auth token.
        /// </summary>
        /// <returns>
        /// A task that completes when the connectivity check has completed.  The result will be <c>true</c>
        /// if there is connectivity; <c>false</c> otherwise.
        /// </returns>
        /// <remarks>
        /// This function should not be called from production code.  It is meant as a diagnostic tool.
        /// </remarks>
        Task<ConnectivityStatus> CheckConnectivity();
    }
}