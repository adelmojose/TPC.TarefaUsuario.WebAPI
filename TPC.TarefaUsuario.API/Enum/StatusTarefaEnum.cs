using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TPC.TarefaUsuario.API.Enum
{
    public enum StatusTarefaEnum
    {
        [Display(Name = "Em Andamento")]
        EmAndamento = 1,

        [Display(Name = "Pendente")]
        Pendente=2,
        
        [Display(Name = "Concluído")]
        Concluido=3
    }
}
