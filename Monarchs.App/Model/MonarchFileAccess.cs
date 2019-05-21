using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Monarchs.App.Entities;
using Monarchs.App.Helpers;
using Newtonsoft.Json;
namespace Monarchs.App.Model
{
    public class MonarchFileAccess : BaseMonarchApiAccess
    {
        public MonarchFileAccess(string basePath) : base(basePath)
        {
        }

        /// <summary>
        /// Gets monarch DTO's from source
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>List<MonarchDTO></returns>
        public override List<MonarchDTO> GetObjects(string fileName)
        {
            string fullpath = BasePath + fileName;
            string fileContent = "";

            if (File.Exists(fileName))
                fileContent = File.ReadAllText(fullpath);
            else
                throw new IOException("File not available");

            return JsonConvert.DeserializeObject<List<MonarchDTO>>(fileContent);
        }

        /// <summary>
        /// Saves the input in file monarchs.txt in the same location as the program
        /// </summary>
        /// <param name="input">input to be saved</param>
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
