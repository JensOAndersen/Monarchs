using System;
using System.Collections.Generic;
using System.Text;
using Monarchs.App.Entities;
using Monarchs.App.Helpers;

namespace Monarchs.App.Model
{
    public class FileAccess : BaseApiAccess
    {
        public FileAccess(string basePath) : base(basePath)
        {
        }

        public override MonarchDTO GetObjects(string Path)
        {
            throw new NotImplementedException();
        }
    }
}
