using Monarchs.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Helpers
{
    //class created to access the either the API or a file containing the json
    //naming could be a bit better, but i like the overall result of it
    //with the Interface it would be easy to implement it with a database as well
    public abstract class BaseMonarchApiAccess : IApiAccess<MonarchDTO>
    {
        private readonly string _basePath;

        public BaseMonarchApiAccess(string basePath)
        {
            _basePath = basePath;
        }

        public string BasePath { get => _basePath; }

        public abstract List<MonarchDTO> GetObjects(string path);
    }
}
