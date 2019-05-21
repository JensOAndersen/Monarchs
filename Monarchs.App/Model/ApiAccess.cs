using System;
using System.Collections.Generic;
using System.Text;
using Monarchs.App.Entities;
using Monarchs.App.Helpers;

namespace Monarchs.App.Model
{
    public class ApiAccess : BaseApiAccess
    {
        private readonly string _token;

        public ApiAccess(string basePath, string token) : base(basePath)
        {
            _token = token;
        }

        public override MonarchDTO GetObjects(string Path)
        {
            throw new NotImplementedException();
        }
    }
}
