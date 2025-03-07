using TPC.TarefaUsuario.API.Core.Data.Entity.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TPC.TarefaUsuario.API.Core.Services.Exception
{
    public class ServiceException : System.Exception
    {
        private Problem _problem { get; set; }

        public Problem Problem { get { return _problem; } }

        public ServiceException(Problem problem) : base()
        {
            _problem = problem;
        }

        public ServiceException(string message, Problem problem) : base(message)
        {
            _problem = problem;
        }

        public ServiceException(string message, System.Exception innerException, Problem problem) : base(message, innerException)
        {
            _problem = problem;
        }

        protected ServiceException(SerializationInfo info, StreamingContext context, Problem problem) : base(info, context)
        {
            _problem = problem;
        }
    }
}
