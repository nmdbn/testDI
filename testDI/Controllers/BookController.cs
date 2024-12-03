using Microsoft.AspNetCore.Mvc;
using testDI.Models;
using testDI.Services;

namespace testDI.Controllers
{
    //public class BookController : Controller
    //{
    //    private readonly IBookService _bookService;

    //    public BookController(IBookService bookService)
    //    {
    //        _bookService = bookService;
    //    }

    //    // Index: Hiển thị danh sách sách
    //    public async Task<IActionResult> Index()
    //    {
    //        var books = await _bookService.GetAllBooksAsync();
    //        return View(books);
    //    }

    //    // Details: Hiển thị thông tin chi tiết một quyển sách
    //    public async Task<IActionResult> Details(int id)
    //    {
    //        var book = await _bookService.GetBookByIdAsync(id);
    //        if (book == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(book);
    //    }

    //    // GET: Book/Create
    //    public IActionResult Create()
    //    {
    //        // Trả về một thể hiện mới của Book để form có thể bind với các trường
    //        return View(new Book());
    //    }

    //    // POST: Book/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(Book book)
    //    {
    //        // Kiểm tra nếu Model hợp lệ
    //        if (ModelState.IsValid)
    //        {
    //            // Kiểm tra nếu Image không được nhập (null hoặc rỗng)
    //            if (string.IsNullOrEmpty(book.Image))
    //            {
    //                // Nếu Image không có giá trị, có thể gán giá trị mặc định hoặc để nó là null
    //                book.Image = null;
    //            }

    //            // Gọi service để lưu thông tin sách
    //            await _bookService.CreateBookAsync(book);

    //            // Sau khi lưu, chuyển hướng đến trang danh sách sách (Index)
    //            return RedirectToAction(nameof(Index));
    //        }

    //        // Nếu Model không hợp lệ, trả về lại form với thông tin đã nhập
    //        return View(book);
    //    }


    //    // Edit: Hiển thị form chỉnh sửa thông tin sách
    //    public async Task<IActionResult> Edit(int id)
    //    {
    //        var book = await _bookService.GetBookByIdAsync(id);
    //        if (book == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(book);
    //    }

    //    // POST Edit: Xử lý việc chỉnh sửa thông tin sách
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, Book book)
    //    {
    //        if (id != book.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            await _bookService.UpdateBookAsync(book);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(book);
    //    }

    //    // Delete: Xác nhận xoá sách
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var book = await _bookService.GetBookByIdAsync(id);
    //        if (book == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(book);
    //    }

    //    // POST Delete: Xử lý việc xoá sách
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        await _bookService.DeleteBookAsync(id);
    //        return RedirectToAction(nameof(Index));
    //    }
    //}
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        //public IActionResult Create() => View();

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _bookService.AddBook(book);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    // Nếu dữ liệu không hợp lệ, trả lại view để hiển thị lỗi
        //    return View(book);
        //}

        // GET: Book/Create
        public IActionResult Create()
        {
            // Trả về một thể hiện mới của Book để form có thể bind với các trường
            return View(new Book());
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            // Kiểm tra nếu Model hợp lệ
            if (ModelState.IsValid)
            {
                // Kiểm tra nếu Image không được nhập (null hoặc rỗng)
                if (string.IsNullOrEmpty(book.Image))
                {
                    // Nếu Image không có giá trị, có thể gán giá trị mặc định hoặc để nó là null
                    book.Image = null;
                }

                // Gọi service để lưu thông tin sách
                _bookService.AddBook(book);

                // Sau khi lưu, chuyển hướng đến trang danh sách sách (Index)
                return RedirectToAction(nameof(Index));
            }

            // Nếu Model không hợp lệ, trả về lại form với thông tin đã nhập
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
