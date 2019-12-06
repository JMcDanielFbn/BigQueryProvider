namespace BigQueryProviderTests.Model
{
    public class BigQueryConnectionStringBuilder
    {
        string ServiceAccount => @"
            {
                'type': '',
                'project_id': '',
                'private_key_id': '',
                'private_key': '',
                'client_email': '',
                'client_id': '',
                'auth_uri': '',
                'token_uri': '',
                'auth_provider_x509_cert_url': '',
                'client_x509_cert_url': ''
            }";

        public string DatabaseName => "projectId";

        public override string ToString()
        {
            return "ServiceAccount=" + ServiceAccount + ";" + "ProjectId=" + DatabaseName;
        }
    }
}