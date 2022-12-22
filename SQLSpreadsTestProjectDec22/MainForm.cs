using Forge.Logging.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SQLSpreadsTestProjectDec22.Task2;
using System.Globalization;

namespace SQLSpreadsTestProjectDec22
{
    /*
    **********
    * Task 1 *
    **********
    - These are three lists with numbers: 
        int[] A = { 15, 24, 11, 3, 91, 82, 16, 77, 2, 10 };
        int[] B = { 25, 93,82, 22, 24};
        int[] C = { 3, 16, 27 };
    - Get a new list with all numbers from list A and B but do not include the numbers in C. Return the numbers in ascending order. 
    - This task do not need any GUI.
    

    **********
    * Task 2 *
    **********
    Create a button on this form and when the user press the button, fetch the currency exchange rates from the API below: 
    https://open.er-api.com/v6/latest/USD

    When the data is received, show the currencies in a listbox in ascending order using this format:
    EUR: 1.03
    SEK: 10.34
    .....
    
     
    **********
    * Task 3 *
    **********
    - Please describe in text what steps you would like to do to take this small test project to a production ready software that can be delivered to end users. 
    

    **********
    * Task 4 *
    **********
    - In the top folder for this test job project, there is a file named “SQL test database.sql” that contains a create script for a small table with some test data.
    - Step 1 - Please write a SQL query that will calculate the sum of the values in the Amount column for every YearMonth in the Period column.
    - Step 2 - Modify the query so that the values for account 1010 are subtracted from the sum of the other accounts.
     */

    public partial class MainForm : Form
    {

        private ILog? LOGGER;
        private ServiceProvider? _serviceProvider;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            Func<HttpMessageHandler> GetInsecureHandler = delegate ()
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    if (cert != null && cert.Issuer.Equals("CN=localhost")) return true;
                    return errors == System.Net.Security.SslPolicyErrors.None;
                };
                return handler;
            };

            serviceCollection.AddLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Trace);
            });

            // add query api
            serviceCollection.AddTransient<ICurrencyRateQueryApi, CurrencyRateQueryApi>((serviceProvider) => new CurrencyRateQueryApi(GetInsecureHandler));

            _serviceProvider = serviceCollection.BuildServiceProvider();

            ILoggerFactory loggerFactory = _serviceProvider.GetService<ILoggerFactory>()!;
            loggerFactory.AddLog4Net();
            _ = _serviceProvider.GetService<ILoggerWrapper>()!; // initiallize Forge logging

            LOGGER = LogManager.GetLogger<MainForm>();
            if (LOGGER.IsInfoEnabled) LOGGER.Info("Application initialized.");
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            btnFetch.Enabled = false;
            lStatus.Visible = true;

            try
            {
                ICurrencyRateQueryApi currencyApi = _serviceProvider!.GetService<ICurrencyRateQueryApi>()!;
                QueryResponse response = await currencyApi.GetAsync();
                if ("success".Equals(response.Result))
                {
                    lbCurrencies.Items.Clear();

                    Func<string, double, string> formatter;
                    formatter = (string currencyName, double price) =>
                    {
                        return $"{currencyName}: {price.ToString("#0.##", CultureInfo.GetCultureInfo("en-US"))}";
                    };

                    // ensure ascending order
                    List<string> keys = response.Rates.Keys.ToList();
                    keys.Sort();

                    foreach (string currency in keys)
                    {
                        lbCurrencies.Items.Add(formatter(currency, response.Rates[currency]));
                    }
                }
                else
                {
                    MessageBox.Show(this, "Fetching currency data was not successful. Maybe service down, please try again a bit later.", "Failed to fetch currency prices", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (LOGGER!.IsErrorEnabled) LOGGER.Error(ex.Message, ex);
                MessageBox.Show(this, ex.Message, "Failed to fetch currency prices", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnFetch.Enabled = true;
            lStatus.Visible = false;
        }

    }
}