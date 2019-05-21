using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Monarchs.App.Entities;
using Monarchs.App.Helpers;
using Newtonsoft.Json;
namespace Monarchs.App.Model
{
    public class FileAccess : BaseApiAccess
    {
        public FileAccess(string basePath) : base(basePath)
        {
        }

        public override List<MonarchDTO> GetObjects(string path)
        {
            string fullpath = BasePath + path;
            string fileContent = "";

            if (File.Exists(path))
                fileContent = File.ReadAllText(fullpath);
            else
                throw new IOException("File not available");

            return JsonConvert.DeserializeObject<List<MonarchDTO>>(fileContent);
        }

        public void SaveApiResult(string input)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("monarchs.txt"))
                {
                    writer.WriteLine(input);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
