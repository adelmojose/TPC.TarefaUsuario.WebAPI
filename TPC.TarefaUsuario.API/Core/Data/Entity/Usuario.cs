using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPC.TarefaUsuario.API.Core.Data.Entity
{
    [Table("Usuario", Schema = "dbo")]
    public class Usuario: BaseEntity
    {

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string nomeUsuario, string email)
        {
            Id = idUsuario;
            NomeUsuario = nomeUsuario;
            Email = email;
        }

        [Key]
        public override int Id { get; set; }


        [Required(ErrorMessage = "Informe o Nome do usuário")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        [StringLength(50, MinimumLength = 4)]
        [MaxLength(50), MinLength(4)]
        public string NomeUsuario{ get; set; }


        [Required(ErrorMessage = "Informe o email")]
        [StringLength(50, MinimumLength = 6)]
        [MaxLength(50), MinLength(6)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        
        //[ForeignKey("UsuarioId")]
        //public virtual ICollection<Tarefa> Tarefas { get; set; }


    }
}
