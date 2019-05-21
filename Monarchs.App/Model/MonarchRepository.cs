using Monarchs.App.Helpers;
using System;
using System.Collections.Generic;
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
    }
}
