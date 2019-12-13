using BigQueryProvider;
using BigQueryProviderTests.Model;
using NUnit.Framework;

namespace BigQueryProviderTests.Dictionary
{
    [TestFixture]
    public class BigQueryDatasetTest : BigQueryProviderTestBase
    {
        [TestCase]
        public void GetDataSetListSuccessTest()
        {
            // given
            var connectionString = new BigQueryConnectionStringBuilder().ToString();
            using BigQueryConnection connection = new BigQueryConnection(connectionString);
            connection.Open();

            // when
            string[] dataSetNames = connection.GetDataSetNames();

            // then
            Assert.IsNotEmpty(dataSetNames);
        }
    }
}