using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
