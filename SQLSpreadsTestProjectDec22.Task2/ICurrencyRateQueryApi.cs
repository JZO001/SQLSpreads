namespace SQLSpreadsTestProjectDec22.Task2
{

    /// <summary>Represents the API, which executes HTTP query</summary>
    public interface ICurrencyRateQueryApi
    {

        /// <summary>Gets the service URL.</summary>
        /// <value>The service URL.</value>
        string Url { get; }

        /// <summary>Gets the HTTP message handler factory.</summary>
        /// <value>The HTTP message handler factory.</value>
        Func<HttpMessageHandler>? HttpMessageHandlerFactory { get; }

        /// <summary>Executes an asynchronous Http Get query</summary>
        /// <returns>The query response</returns>
        Task<QueryResponse> GetAsync();

        /// <summary>Executes an asynchronous Http Get query with URL parameter</summary>
        /// <param name="url">The service URL.</param>
        /// <returns>The query response</returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        /// <exception cref="System.Net.Http.HttpRequestException">null</exception>
        Task<QueryResponse> GetAsync(string url);

    }

}
