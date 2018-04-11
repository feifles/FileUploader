using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploaderV2.Controllers.Resources
{
    public class DbConfigResource : KeyValuePairResource
    {

        public string Server { get; set; }

        public string DatabaseName { get; set; }

    }
}
