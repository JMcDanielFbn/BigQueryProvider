using System.Data;
using BigQueryProvider;
using BigQueryProviderTests.Model;
using NUnit.Framework;

namespace BigQueryProviderTests.Connection
{
    [TestFixture]
    public class BigQueryConnectionTest : BigQueryProviderTestBase
    {
        [TestCase]
        public void openConnection_SuccessTest()
        {
            // given
            var connectionStringBuilder = new BigQueryConnectionStringBuilder();

            // when
            using BigQueryConnection connection = new BigQueryConnection(connectionStringBuilder.ToString());
            connection.Open();

            // then
            Assert.AreEqual(ConnectionState.Open, connection.State);
        }
    }
}