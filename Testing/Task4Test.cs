using Microsoft.Extensions.Configuration;
using SQLSpreadsTestProjectDec22.Test4;
using System.Collections.Generic;

namespace Testing
{

    [TestClass]
    public class Task4Test
    {

        private static string? _connectionString;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext? TestContext
        {
            get; set;
        }

        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                          .AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [TestMethod]
        public void TestCalculate1()
        {
            List<(int, decimal)> result = Task.Run(() => DbQuery.Calculate1(_connectionString!)).ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 12); // with this dataset, the expected row number is 12

            using (FileStream fs = new FileStream("SQL Output Calc 1.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    result.ForEach(row => sw.WriteLine($"PeriodKey: {row.Item1}, Sum.Amount: {row.Item2.ToString("0#")}"));
                }
            }

        }

        [TestMethod]
        public void TestCalculate2()
        {
            List<(int, decimal)> result = Task.Run(() => DbQuery.Calculate2(_connectionString!)).ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.IsTrue(result.Count == 12); // with this dataset, the expected row number is 12

            using (FileStream fs = new FileStream("SQL Output Calc 2.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    result.ForEach(row => sw.WriteLine($"PeriodKey: {row.Item1}, Sum.Amount: {row.Item2.ToString("#0")}"));
                }
            }

        }

    }

}