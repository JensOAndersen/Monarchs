using Monarchs.App.Entities;
using Monarchs.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monarchs.App.Model
{
    class MonarchRepository
    {
        private BaseApiAccess access; //both file and api access derives from BaseApiAccess

        public MonarchRepository(BaseApiAccess access)
        {
            this.access = access;
        }

        /*
            Okay, finding the reign start and ends have been a pain, as some of the kings have only reigned for a single year.

            There's probably a better way to handle this, but this is what i could come up with.
        */
        public List<Monarch> GetAllMonarchs(string path)
        {
            var monarchDtos = access.GetObjects(path);

            List<Monarch> monarchs = new List<Monarch>();

            foreach (var mnDto in monarchDtos)
            {


                int reignStart = 0;
                int reignEnd = 0;

                string reignDur = mnDto.Yrs;

                if (reignDur[reignDur.Length - 1] == '-')
                {
                    reignStart = int.Parse(reignDur.Replace("-", string.Empty));
                    reignEnd = DateTime.Now.Year;
                }
                else if (!reignDur.Contains("-"))
                {
                    reignEnd = reignStart = int.Parse(reignDur);
                }
                else
                {
                    reignStart = int.Parse(reignDur.Split("-")[0]);
                    reignEnd = int.Parse(reignDur.Split("-")[1]);
                }

                Monarch monarch = new Monarch
                {
                    Name = mnDto.Nm,
                    Country = mnDto.Cty,
                    House = mnDto.Hse,
                    ReignEnd = reignEnd,
                    ReignStart = reignStart
                };
                monarchs.Add(monarch);
            }
            return monarchs;
        }
    }
}
