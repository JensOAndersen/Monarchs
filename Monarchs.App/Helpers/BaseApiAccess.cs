using Monarchs.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Helpers
{
    public abstract class BaseApiAccess : IApiAccess<MonarchDTO>
    {
        private readonly string _basePath;

        public BaseApiAccess(string basePath)
        {
            _basePath = basePath;
        }

        public string BasePath { get; }

        public abstract List<MonarchDTO> GetObjects(string Path);
    }
}
