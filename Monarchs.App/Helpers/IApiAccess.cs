using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Helpers
{
    public interface IApiAccess<T>
    {
        string BaseUrl { get; set; }

        T GetObjects(string Path);
    }
}
