using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net.Models;
using ASP.net.Models.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ASP.net.Controllers
{
	public class BooksController : Controller
	{
		private const string bookListKey = "BookList";
		private ApplicationContext DbContext { get; }

		public BooksController(ApplicationContext dbContext)
		{
			this.DbContext = dbContext;
			
		}

		public async Task<IActionResult> Index(int? id)
		{
			if(TempData.ContainsKey(bookListKey))
				TempData.Clear();

			if (id == null)
				return NotFound();

			var author = await DbContext.Authors.Include(a => a.Books).FirstAsync(a => a.Id == id);
			return View(author);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromRoute]int id, [FromForm]Book book)
		{
			List<BookDTO> tmpBookList = new List<BookDTO>();
			if (TempData.ContainsKey(bookListKey))
				tmpBookList.AddRange(JsonConvert.DeserializeObject<List<BookDTO>>(TempData[bookListKey].ToString()));
			tmpBookList.Add(book.BookToBookDto());
			TempData[bookListKey] = JsonConvert.SerializeObject(tmpBookList);
			

			var author = await DbContext.Authors.Include(a => a.Books).FirstAsync(a => a.Id == id);
			var allBooks = author.Books.ToList();
			allBooks.AddRange(tmpBookList.Select(BookMapper.BookDtoToBook));
			return PartialView("_BooksListPartial", allBooks);
		}

		public async Task<IActionResult> Save(int? id)
		{
			if (id == null)
				return NotFound();

			var author = await DbContext.Authors.Include(a => a.Books).FirstAsync(a => a.Id == id);
			author.Books.AddRange(JsonConvert.DeserializeObject<List<BookDTO>>(TempData[bookListKey].ToString())
				.Select(BookMapper.BookDtoToBook).ToList());

			await DbContext.SaveChangesAsync();

			return RedirectToAction("Index", new {id = id});
		}

		public async Task<IActionResult> Delete(int? id)
		{
			var book = await DbContext.Books.FindAsync(id);
			DbContext.Books.Remove(book);
			await DbContext.SaveChangesAsync();
			return RedirectToAction("Index", new { id = book.AuthorId });
		}
	}
}
