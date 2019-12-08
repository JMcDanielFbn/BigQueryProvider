using BigQueryProvider;
using BigQueryProviderTests.Model;
using NUnit.Framework;

namespace BigQueryProviderTests.Dictionary
{
    [TestFixture]
    public class BigQueryTableTest : BigQueryProviderTestBase
    {
        [TestCase]
        public void Get_Tables_SuccessTest()
        {
            // given
            var connectionString = new BigQueryConnectionStringBuilder().ToString();
            using BigQueryConnection connection = new BigQueryConnection(connectionString);
            connection.Open();
            
            connection.ChangeDatabase("sakila");

            // when
            string[] tableNames = connection.GetTableNames();

            // then
            Assert.IsNotEmpty(tableNames);
        }
    }
}