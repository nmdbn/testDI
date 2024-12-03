using testDI.Models;

namespace testDI.Services
{
    //public interface IBookService
    //{
    //    Task<List<Book>> GetAllBooksAsync();
    //    Task<Book> GetBookByIdAsync(int id);
    //    Task CreateBookAsync(Book book);
    //    Task UpdateBookAsync(Book book);
    //    Task DeleteBookAsync(int id);
    //}
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
