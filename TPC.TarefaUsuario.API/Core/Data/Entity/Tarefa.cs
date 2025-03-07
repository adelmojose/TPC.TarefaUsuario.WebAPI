using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace TPC.TarefaUsuario.API.Core.Data.Entity
{
    [Table("Tarefa", Schema = "dbo")]
    public class Tarefa: BaseEntity
    {
        public Tarefa()
        {
        }

        public Tarefa(int idTarefa, string titulo, string descricao, int statusId, int usuarioId)
        {
            Id = idTarefa; Titulo = titulo;
            Descricao = descricao;
            StatusId = statusId;
            UsuarioId = usuarioId;
        }

        [Key]
        public override int Id { get; set; }
        
        [Required(ErrorMessage = "Informe um Título")]
        [StringLength(50, MinimumLength = 3)]
        [MaxLength(50), MinLength(3)]
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o Status")]
        public int StatusId { get; set; }

       [Required(ErrorMessage = "Informe o Usuário")]
        
//        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }

        //[NotMapped]
        //public Usuario Usuario { get; private set; }

    }


}
