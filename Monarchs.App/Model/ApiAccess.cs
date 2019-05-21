using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Monarchs.App.Entities;
using Monarchs.App.Helpers;
using Newtonsoft.Json;

namespace Monarchs.App.Model
{
    public class ApiAccess : BaseApiAccess
    {
        private readonly string _token;

        private FileAccess fileAccess;

        public ApiAccess(string basePath, string token) : base(basePath)
        {
            _token = token;

            fileAccess = new FileAccess("");
        }

        public override List<MonarchDTO> GetObjects(string path)
        {
            string url = $"{BasePath}{path}&token={_token}";
            string apiResult = "";

            using(WebClient client = new WebClient())
            {
                apiResult = client.DownloadString(url);
            }

            fileAccess.SaveApiResult(apiResult);
            
            var res = JsonConvert.DeserializeObject<List<MonarchDTO>>(apiResult);

            return res;
        }
    }
}
