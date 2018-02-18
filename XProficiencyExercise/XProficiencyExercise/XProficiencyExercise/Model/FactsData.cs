using Newtonsoft.Json;
using System.Threading.Tasks;

namespace XProficiencyExercise.Model
{
    public class FactsData
    {
        #region Methods
        /// <summary>
        /// get json feeds in object name Facts
        /// </summary>
        /// <param name="fromFile">Optional parameter to get either from web service or fro file system</param>
        /// <returns></returns>
        public static Facts GetFacts(bool fromFile = false)
        {
            var svc = new RestDataSvc();
            string data = string.Empty;
            if (!fromFile)
            {
                Task<string> task = Task.Run<string>(async () => await svc.GetDataFromServiceAsync());
                data = task.Result;
            }
            data = svc.GetDataFromFile();
            var facts = JsonConvert.DeserializeObject<Facts>(data);
            facts.rows.RemoveAll(x => string.IsNullOrEmpty(x.title) || (string.IsNullOrEmpty(x.description) && !string.IsNullOrEmpty(x.imageHref)));
            return facts;
        } 
        #endregion
    }
}
