using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace XProficiencyExercise
{
    class RestDataSvc
    {
        //Url can be provided through more flexible way
        private const string RestUrl = "https://dl.dropboxusercontent.com/s/2iodh4vg0eortkl/facts.json";
        HttpClient client;

        public RestDataSvc()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<string> RefreshDataAsync()
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
            var resourceName = "XProficiencyExercise.JsonSampleData.SampleData.json";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
