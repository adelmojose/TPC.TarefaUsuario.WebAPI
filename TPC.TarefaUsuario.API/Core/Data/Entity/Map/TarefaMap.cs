using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace TPC.TarefaUsuario.API.Core.Data.Entity.Map
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UsuarioId).HasColumnName("UsuarioId").IsRequired();
            //builder.HasOne(t => t.Usuario)
            //       .WithMany()
            //       .HasForeignKey(t => t.UsuarioId)
            //       .IsRequired(false);
        }
    }
}
