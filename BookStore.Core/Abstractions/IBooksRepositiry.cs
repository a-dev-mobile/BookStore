



using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBooksRepository
{
    Task<Guid> Create(Book book);

    Task<List<Book>> Get();


    Task<Guid> Update(Guid id, string title, string description, decimal price);


    Task<Guid> Delete(Guid id);
}











