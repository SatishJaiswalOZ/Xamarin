using Newtonsoft.Json;
using System.Threading.Tasks;

namespace XProficiencyExercise.Model
{
    class FactsData
    {
        public Facts GetFacts(bool fromFile = false)
        {
            var svc = new RestDataSvc();
            string data = string.Empty;
            if (!fromFile)
            {
                Task<string> task = Task.Run<string>(async () => await svc.RefreshDataAsync());
                data = task.Result;
            }
            data = svc.GetDataFromFile();
            return JsonConvert.DeserializeObject<Facts>(data);
        }
    }
}
