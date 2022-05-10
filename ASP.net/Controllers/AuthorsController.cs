using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.net.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.net.Controllers
{
	public class AuthorsController : Controller
	{
		private ApplicationContext DbContext { get; }
		public AuthorsController(ApplicationContext dbContext)
		{
			this.DbContext = dbContext;
		}


		public async Task<IActionResult> Index()
		{
			return View(await DbContext.Authors.Include(a => a.Books).ToListAsync());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]Author author)
		{
			if (!ModelState.IsValid) return View(author);

			DbContext.Add(author);
			await DbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}


		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();

			var  author = await DbContext.Authors.FirstAsync(a => a.Id == id);

			return author == null ? NotFound() : View(author);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [FromForm] Author author)
		{
			if (id != author.Id)
				return NotFound();

			if (!ModelState.IsValid) return View(author);


			DbContext.Update(author);
			await DbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var author = await DbContext.Authors.FindAsync(id);
			DbContext.Remove(author);
			await DbContext.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult InitializeDatabase()
		{
			DbContext.Database.EnsureDeleted();
			DbContext.Database.EnsureCreated();

			var Andrew = new Author()
			{
				LastName = "Скуратовский",
				FirstName = "Андрей",
				SurName = "Владимирович",
				BirthDate = new DateTime(2000, 12, 12)
			};

			var Taras = new Author()
			{
				LastName = "Шевченко",
				FirstName = "Тарас",
				SurName = "Григорович",
				BirthDate = new DateTime(1814, 03, 9)
			};

			var AndrewBooks = new List<Book>()
			{
				new Book()
				{
					Title = "Test",
					Genre = "Test",
					PageCount = 999
				},
				new Book()
				{
					Title = "Бакалаврська робота",
					Genre = "Публіцистична література",
					PageCount = 102
				}
			};

			var TarasBooks = new List<Book>()
			{
				new Book()
				{
					Title = "Кобзар",
					Genre = "Поезія",
					PageCount = 536
				},
				new Book()
				{
					Title = "Гайдамаки",
					Genre = "Література",
					PageCount = 668
				},
				new Book()
				{
					Title = "Заповіт",
					Genre = "Поезія",
					PageCount = 816
				}
			};

			Andrew.Books.AddRange(AndrewBooks);
			Taras.Books.AddRange(TarasBooks);

			DbContext.Authors.Add(Andrew);
			DbContext.Authors.Add(Taras);

			DbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
	}
}
