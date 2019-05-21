using System;
using System.Collections.Generic;
using System.Text;
using Monarchs.App.Entities;
using Monarchs.App.Helpers;
using Newtonsoft.Json;

namespace Monarchs.App.Model
{
    public class ApiAccess : BaseApiAccess
    {
        private readonly string _token;

        public ApiAccess(string basePath, string token) : base(basePath)
        {
            _token = token;
        }

        public override List<MonarchDTO> GetObjects(string Path)
        {
            var apiResult = 

            throw new NotImplementedException();
        }
    }
}
