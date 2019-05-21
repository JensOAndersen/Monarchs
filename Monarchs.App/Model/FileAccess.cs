using System;
using System.Collections.Generic;
using System.IO;
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

        public override List<MonarchDTO> GetObjects(string path)
        {
            throw new NotImplementedException();
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
