namespace HTTP.Security
{
    /// <summary>
    /// This class represents the basis of what a token needs
    /// to be able to provide authentication.
    /// </summary>
    public abstract class AuthToken
    {
        /// <summary>
        /// Gets the type (scheme) of the token (i.e., Bearer)
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        public virtual string Scheme { get; private set; }

        /// <summary>
        /// Gets the token, which is usually a long string of
        /// encoded characters that when decoded provides proof
        /// that the possessor is who they say they are.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public virtual string Token { get; private set; }

        protected AuthToken(string scheme, string token)
        {
            this.Scheme = scheme;
            this.Token = token;
        }
    }
}