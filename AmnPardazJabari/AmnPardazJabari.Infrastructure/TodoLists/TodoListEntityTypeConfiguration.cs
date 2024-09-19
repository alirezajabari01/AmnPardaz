using System.Data;
using AmnPardazJabari.Domain.TodoList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmnPardazJabari.Infrastructure.TodoLists;

public class TodoListEntityTypeConfiguration:IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.OwnsOne
        (
            todoList => todoList.Title, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(15)
                    .HasColumnName(nameof(TodoList.Title));
            }
        );
        builder.OwnsOne
        (
            todoList => todoList.Description, buildAction =>
            {
                buildAction.Property(propertyExpression => propertyExpression.Value)
                    .IsRequired()
                    .HasColumnType(SqlDbType.NVarChar.ToString())
                    .HasMaxLength(150)
                    .HasColumnName(nameof(TodoList.Description));
            }
        );
    }
}