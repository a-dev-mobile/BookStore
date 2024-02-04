using BookStore.API.Contracts;
using BookStore.Core.Abstractions;

using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _bookServices.GetAllBooks();
            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));


            return Ok(response);


        }
    }
}
