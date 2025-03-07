using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC.TarefaUsuario.API.Core.Data.Entity.Error
{
    public class Problem
    {
        public int Status { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public string Method { get; set; }
        public string TraceId { get; set; }

        public ICollection<FieldError> Erros { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public System.Exception InnerException { get; set; }
    }
}
