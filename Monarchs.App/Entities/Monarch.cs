using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Entities
{
    public class MonarchDTO
    {
        public int Id { get; set; }
        public string Nm { get; set; }
        public string Cty { get; set; }
        public string Hse { get; set; }
        public string Yrs { get; set; }
    }

    public struct Monarch
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string House { get; set; }
        public int ReignStart { get; set; }
        public int ReignEnd { get; set; }

        public int ReignDuration
        {
            get
            {
                return ReignEnd - ReignStart;
            }
        }
    }
}
