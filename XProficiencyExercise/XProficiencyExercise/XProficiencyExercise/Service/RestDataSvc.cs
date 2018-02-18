using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace XProficiencyExercise
{
    public class RestDataSvc
    {
        #region Attributes
        //Url can be provided through more flexible ways like from configuration file
        private const string RestUrl = "https://dl.dropboxusercontent.com/s/2iodh4vg0eortkl/facts.json";
        HttpClient client;
        #endregion

        #region Constructor
        public RestDataSvc()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }
        #endregion

        #region Methods
        public async Task<string> GetDataFromServiceAsync()
        {
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return string.Empty;
        }

        public string GetDataFromFile()
        {
            string fact = string.Empty;
            var assembly = Assembly.GetExecutingAssembly();

            //this file is embedded resource in the project folder name JsonSampleData
            var resourceName = "XProficiencyExercise.JsonSampleData.SampleData.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
        #endregion
    }
}
