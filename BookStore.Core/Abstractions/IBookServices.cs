



using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBookServices
{
     Task<List<Book>> GetAllBooks();


     Task<Guid> CreateBook(Book book);


     Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);


     Task<Guid> DeleteBook(Guid id);

}















