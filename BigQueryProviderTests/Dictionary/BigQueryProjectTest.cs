using BigQueryProvider;
using BigQueryProviderTests.Model;
using NUnit.Framework;

namespace BigQueryProviderTests.Dictionary
{
    [TestFixture]
    public class BigQueryProjectTest : BigQueryProviderTestBase
    {
        [TestCase]
        public void GetProjectListSuccessTest()
        {
            // given
            var connectionString = new BigQueryConnectionStringBuilder().ToString();
            using BigQueryConnection connection = new BigQueryConnection(connectionString);
            connection.Open();

            // when
            string[] projectNames = connection.GetProjectNames();

            // then
            Assert.IsNotEmpty(projectNames);
        }
    }
}