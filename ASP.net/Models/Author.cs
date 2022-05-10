using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.net.Models
{
	public class Author
	{
		public int Id { get; set; }

		[Display(Name = "Фамилия")]
		[MyRequired]
		public string LastName { get; set; }

		[Display(Name = "Имя")]
		[MyRequired]
		public string FirstName { get; set; }

		[Display(Name = "Отчество")]
		[MyRequired]
		public string SurName { get; set; }

		[DataType(DataType.Date, ErrorMessage = "Введённые данные неверны")]
		[Display(Name = "Дата рождения")]
		[DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
		public DateTime BirthDate { get; set; }

		[Display(Name = "Книги")]
		public List<Book> Books { get; set; } = new List<Book>();
	}

	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.HasKey(a => a.Id);
			builder.HasMany(a => a.Books).WithOne(b => b.Author)
					.HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.Cascade);
		}
	}


}