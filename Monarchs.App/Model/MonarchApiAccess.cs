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
    public class MonarchApiAccess : BaseMonarchApiAccess
    {
        private readonly string _token;

        private MonarchFileAccess fileAccess;

        public MonarchApiAccess(string basePath, string token) : base(basePath)
        {
            _token = token;

            fileAccess = new MonarchFileAccess("");
        }

        /// <summary>
        /// Gets a list of MonarchDTO's from the source
        /// </summary>
        /// <param name="path">API path</param>
        /// <returns>List of MonarchDTO's</returns>
        public override List<MonarchDTO> GetObjects(string path)
        {
            string url = $"{BasePath}{path}&token={_token}";
            string apiResult = "";

            using(WebClient client = new WebClient())
            {
                apiResult = client.DownloadString(url);
            }

            fileAccess.SaveApiResult(apiResult);//save the API result locally, so i dont have to contact the API every time i run the program
            
            var res = JsonConvert.DeserializeObject<List<MonarchDTO>>(apiResult);

            return res;
        }
    }
}
