using BookStore.DataAccess.Entites;
using BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DataAccess;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(b => b.Title)
        .HasMaxLength(Book.MAX_TITLE_LENGHT)

        .IsRequired();

        builder.Property(b => b.Description)
       .IsRequired();

        builder.Property(b => b.Price)
        .IsRequired();
    }
}
