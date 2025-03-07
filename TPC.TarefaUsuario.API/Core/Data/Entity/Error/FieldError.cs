using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC.TarefaUsuario.API.Core.Data.Entity.Error
{
    public class FieldError
    {

        public FieldError() : this(string.Empty, new List<string>(), string.Empty)
        {
        }

        public FieldError(string field, ICollection<string> erros, string fieldTypeErro = "ERRO")
        {
            FieldName = field;
            FieldErros = erros;
            FieldTypeErro = fieldTypeErro;
        }

        public string FieldName { get; set; }

        public ICollection<string> FieldErros { get; set; }

        public string FieldTypeErro { get; set; }
    }
}
