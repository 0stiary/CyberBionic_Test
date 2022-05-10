using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.net.Models
{
	public class Book
	{
		public int Id { get; set; }

		[Display(Name = "Название")]
		[MyRequired]
		public string Title { get; set; }

		[Display(Name = "Жанр")]
		public string Genre { get; set; }

		[Display(Name = "Кол-во страниц")]
		[MyRequired]
		public short PageCount { get; set; }

		public int AuthorId { get; set; }

		public Author Author { get; set; }
	}
	
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(b => b.Id);
		}
	}
}