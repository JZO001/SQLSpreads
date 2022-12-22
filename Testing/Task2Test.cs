using SQLSpreadsTestProjectDec22.Task2;

namespace Testing
{

    [TestClass]
    public class Task2Test
    {

        [TestMethod]
        public void TestHttpApi()
        {
            CurrencyRateQueryApi api = new CurrencyRateQueryApi();
            QueryResponse response = Task.Run(() => api.GetAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.IsNotNull(response);
            Assert.IsTrue("success".Equals(response.Result));
            Assert.IsTrue("USD".Equals(response.BaseCode));
            Assert.IsTrue(response.Rates.Any());

        }

    }

}