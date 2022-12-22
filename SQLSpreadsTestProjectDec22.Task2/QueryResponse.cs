using Newtonsoft.Json;

namespace SQLSpreadsTestProjectDec22.Task2
{

    public class QueryResponse
    {

        [JsonProperty("result")]
        public string? Result { get; set; }

        [JsonProperty("base_code")]
        public string? BaseCode { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; private set; } = new Dictionary<string, double>();

    }

}
