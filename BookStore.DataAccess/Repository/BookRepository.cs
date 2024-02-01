using BookStore.Core.Models;
using BookStore.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess;

public class BookRepository
{
    private readonly BookStoreDbContext _context;

    public BookRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> Get()
    {
        var bookEntities = await _context.Books.AsNoTracking().ToListAsync();

        // Use Select to transform entities to (Book, Error) tuples, then filter out those with errors, and finally select just the Book part.
        var books = bookEntities.Select(b => Book.Create(id: b.Id, title: b.Title, description: b.Description, price: b.Price))
                                .Where(tuple => string.IsNullOrEmpty(tuple.Error)) // Filter out tuples with errors
                                .Select(tuple => tuple.Item1) // Select only the Book part of the tuple
                                .ToList();

        return books;
    }


    public async Task<Guid> Create(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Price = book.Price
        };
        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();

        return bookEntity.Id;



    }


    public async Task<Guid> Update(Guid id, string title, string description, decimal price)

    {

        await _context.Books.Where(b => b.Id == id).ExecuteUpdateAsync(s => s
        .SetProperty(b => b.Title, b => title)
        .SetProperty(b => b.Description, b => description)
        .SetProperty(b => b.Price, b => price)

        );



        return id;
    }



    public async Task<Guid> Delete(Guid id)
    {
        await _context.Books
        .Where(b => b.Id == id)
        .ExecuteDeleteAsync();
        return id;
    }
}
