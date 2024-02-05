using BookStore.API.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
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


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BookRequest request)
        {

            var (book, error) = Book.Create(Guid.NewGuid(), request.Title, request.Description, request.price);


            if (!string.IsNullOrWhiteSpace(error))
            {
                return BadRequest(error);
            }
            var bookId = await _bookServices.CreateBook(book);

            return Ok(bookId);

        }
    }
}
