using Forge.Logging.Abstraction;
using Newtonsoft.Json;

namespace SQLSpreadsTestProjectDec22.Task2
{

    /// <summary>Represents the API, which executes HTTP query</summary>
    public class CurrencyRateQueryApi : ICurrencyRateQueryApi
    {

        private static readonly ILog LOGGER = LogManager.GetLogger<CurrencyRateQueryApi>();

        private const string DEFAULT_URL = "https://open.er-api.com/v6/latest/USD";

        /// <summary>Initializes a new instance of the <see cref="CurrencyRateQueryApi" /> class.</summary>
        public CurrencyRateQueryApi()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CurrencyRateQueryApi" /> class.</summary>
        /// <param name="url">The URL.</param>
        /// <exception cref="System.ArgumentNullException">url</exception>
        public CurrencyRateQueryApi(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            Url = url;
        }

        /// <summary>Initializes a new instance of the <see cref="CurrencyRateQueryApi" /> class.</summary>
        /// <param name="httpMessageHandlerFactory">The HTTP message handler factory.</param>
        public CurrencyRateQueryApi(Func<HttpMessageHandler>? httpMessageHandlerFactory)
        {
            HttpMessageHandlerFactory = httpMessageHandlerFactory;
        }

        /// <summary>Initializes a new instance of the <see cref="CurrencyRateQueryApi" /> class.</summary>
        /// <param name="url">The URL.</param>
        /// <param name="httpMessageHandlerFactory">The HTTP message handler factory.</param>
        public CurrencyRateQueryApi(string url, Func<HttpMessageHandler>? httpMessageHandlerFactory)
            : this(url)
        {
            HttpMessageHandlerFactory = httpMessageHandlerFactory;
        }

        /// <summary>Gets the service URL.</summary>
        /// <value>The service URL.</value>
        public string Url { get; private set; } = DEFAULT_URL;

        /// <summary>Gets the HTTP message handler factory.</summary>
        /// <value>The HTTP message handler factory.</value>
        public Func<HttpMessageHandler>? HttpMessageHandlerFactory { get; private set; }

        /// <summary>Executes an asynchronous Http Get query</summary>
        /// <returns>The query response</returns>
        public async Task<QueryResponse> GetAsync()
        {
            return await GetAsync(Url);
        }

        /// <summary>Executes an asynchronous Http Get query with URL parameter</summary>
        /// <param name="url">The service URL.</param>
        /// <returns>The query response</returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        /// <exception cref="System.Net.Http.HttpRequestException">null</exception>
        public async Task<QueryResponse> GetAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            QueryResponse? result = null;
            try
            {
                using (HttpClient httpClient = CreateHttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                    if (LOGGER.IsDebugEnabled) LOGGER.Debug($"GetAsync, sending {request.Method} to {httpClient.BaseAddress}");
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    if (LOGGER.IsDebugEnabled) LOGGER.Debug($"GetAsync, response arrived from {httpClient.BaseAddress}, method: {request.Method}");

                    string jsonResult = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        if (LOGGER.IsDebugEnabled) LOGGER.Debug($"GetAsync, response indicates an unsuccessful operation from {httpClient.BaseAddress}, method: {request.Method}");
                        throw new HttpRequestException(jsonResult, null, response.StatusCode);
                    }

                    result = JsonConvert.DeserializeObject<QueryResponse>(jsonResult);
                }
            }
            catch (Exception ex)
            {
                if (LOGGER.IsErrorEnabled) LOGGER.Error(ex.Message, ex);
                result = new QueryResponse();
            }

            return result!;
        }

        private HttpClient CreateHttpClient()
        {
            if (HttpMessageHandlerFactory == null)
            {
                if (LOGGER.IsDebugEnabled) LOGGER.Debug($"HttpMessageHandler not set, Url: {Url}");
                return new HttpClient { BaseAddress = new Uri(Url) };
            }
            else
            {
                if (LOGGER.IsDebugEnabled) LOGGER.Debug($"HttpMessageHandler presents, Url: {Url}");
                return new HttpClient(HttpMessageHandlerFactory()) { BaseAddress = new Uri(Url) };
            }
        }
    }

}
