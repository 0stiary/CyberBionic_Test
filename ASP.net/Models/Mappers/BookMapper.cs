
using System;

namespace ASP.net.Models.Mappers
{
	public static class BookMapper
	{
		public static BookDTO BookToBookDto(this Book book)
		{
			return new BookDTO()
			{
				Title = book.Title,
				Genre = book.Genre,
				PageCount = book.PageCount
			};
		}

		public static Book BookDtoToBook(this BookDTO bookDTO)
		{
			return new Book()
			{
				Title = bookDTO.Title,
				Genre = bookDTO.Genre,
				PageCount = bookDTO.PageCount
			};
		}
	}
}
