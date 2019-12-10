using System.Collections;
using BigQueryProvider;
using BigQueryProviderTests.Model;
using NUnit.Framework;

/**
 * BigQuery Table Information Schema Url
 * 
 * https://cloud.google.com/bigquery/docs/information-schema-tables?hl=ko
 */
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
        
        [TestCase]
        public void Get_Table_Columns_SuccessTest()
        {
            // given
            var connectionString = new BigQueryConnectionStringBuilder().ToString();
            using BigQueryConnection connection = new BigQueryConnection(connectionString);
            connection.Open();
            
            connection.ChangeDatabase("sakila");

            const string tableName = "bmi";
            ArrayList columnNames = new ArrayList();

            // when
            using BigQueryCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = $@"SELECT * FROM `{connection.DataSource}`.{connection.Database}.INFORMATION_SCHEMA.COLUMNS where table_name = '{tableName}'";

            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                columnNames.Add(dataReader.GetString(3));
            }
            
            // then
            Assert.IsNotEmpty(columnNames);
        }
    }
}