using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AHS
{
    internal class HospitalService
    {
        HttpClient client = new HttpClient();
        private string url = "https://retoolapi.dev/L7J6kU/data";

        public List<DataDef> GetAll()
        {
            string json = client.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<List<DataDef>>(json);
        }

		public DataDef Add(DataDef input)
		{
			StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
			HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
			Debug.WriteLine(responseMessage.ToString());
			Debug.WriteLine(null);
			Debug.WriteLine(responseMessage.Content);
			return null;
		}

		internal bool Delete(DataDef patient)
		{
			int id = patient.id;
			HttpResponseMessage response = client.DeleteAsync($"{url}/{id}").Result;
			return response.IsSuccessStatusCode;
		}
	}
}
