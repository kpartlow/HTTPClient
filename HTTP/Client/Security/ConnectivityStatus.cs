namespace HTTP.Client.Security
{
    /// <summary>
    /// Class contains the current OAuth service status.
    /// </summary>
    public class ConnectivityStatus
    {
        /// <summary>
        /// Gets or sets the boolean indicator whether service has a valid authentication token.
        /// </summary>
        public bool HasToken { get; set; }

        /// <summary>
        /// Gets or sets the boolean indicator whether service has connectivity to remote Identity service.
        /// </summary>
        public bool HasAuthServerConnectivity { get; set; }

        /// <summary>
        /// Gets or sets the boolean indicator whether authentication service is currently enabled.
        /// </summary>
        public bool Enabled { get; set; }
    }
}