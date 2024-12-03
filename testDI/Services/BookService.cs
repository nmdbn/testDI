using testDI.Models;

namespace testDI.Services
{
    //public class BookService : IBookService
    //{
    //    private readonly List<Book> _books = new List<Book>(); // List giả lập (nên thay bằng DB trong thực tế)

    //    public async Task<List<Book>> GetAllBooksAsync()
    //    {
    //        return await Task.FromResult(_books);
    //    }

    //    public async Task<Book> GetBookByIdAsync(int id)
    //    {
    //        return await Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
    //    }

    //    private readonly ApplicationDbContext _context;

    //    public BookService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task CreateBookAsync(Book book)
    //    {
    //        if (book == null)
    //        {
    //            throw new ArgumentNullException(nameof(book), "Book cannot be null");
    //        }

    //        // Thêm sách vào cơ sở dữ liệu
    //        await _context.Books.AddAsync(book);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task UpdateBookAsync(Book book)
    //    {
    //        var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
    //        if (existingBook != null)
    //        {
    //            existingBook.Title = book.Title;
    //            existingBook.Author = book.Author;
    //            existingBook.Description = book.Description;
    //            existingBook.Price = book.Price;
    //            existingBook.Image = book.Image;
    //        }
    //        await Task.CompletedTask;
    //    }

    //    public async Task DeleteBookAsync(int id)
    //    {
    //        var book = _books.FirstOrDefault(b => b.Id == id);
    //        if (book != null)
    //        {
    //            _books.Remove(book);
    //        }
    //        await Task.CompletedTask;
    //    }
    //}
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new();

        public List<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Price = book.Price;
                existingBook.Image = book.Image;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
