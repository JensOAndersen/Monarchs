using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Helpers
{
    /*
        This interface can be extended with other get, put, post and delete methods, ensuring that the same methods will work across the application
        it is of type T, so it can be used for other objects than Monarch

        Is meant to be used with Json.Net
    */
    public interface IApiAccess<T>
    {
        string BasePath { get; }

        List<T> GetObjects(string path);
    }
}
