namespace task1
{
    internal class Program
    {
        public struct Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }

        }

        public class LibraryItem
        {
            public int ItemId { get; set; }
            public bool IsAvailable { get; set; }

            public LibraryItem(int itemId)
            {
                ItemId = itemId;
                IsAvailable = true; // suppose all items are available by default
            }

            public void CheckOut()
            {
                if (IsAvailable)
                {
                    IsAvailable = false;
                    Console.WriteLine($"Item {ItemId} has been checked out.");
                }
                else
                {
                    Console.WriteLine($"Item {ItemId} is already checked out.");
                }
            }

            public void ReturnItem()
            {
                if (!IsAvailable)
                {
                    IsAvailable = true;
                    Console.WriteLine($"Item {ItemId} has been returned.");
                }
                else
                {
                    Console.WriteLine($"Item {ItemId} is available.");
                }
            }
        }

        public class BorrowedBook : LibraryItem
        {
            public Book BookDetails { get; set; }
            public string BorrowerName { get; set; }
            public DateTime BorrowedDate { get; set; }

            public BorrowedBook(int itemId, Book bookDetails, string borrowerName, DateTime borrowedDate): base(itemId)
            {
                BookDetails = bookDetails;
                BorrowerName = borrowerName;
                BorrowedDate = borrowedDate;
            }

            public int CalculateBorrowDuration()
            {
                return (DateTime.Now - BorrowedDate).Days;
            }

        }
        static void Main(string[] args)
        {
            // Create an instance of the Book struct
            Book book = new Book();
            book.Title = "Animal Farm";
            book.Author = "George Orwell";
            book.ISBN = "123456";

            // Create an instance of the BorrowedBook class
            BorrowedBook borrowedBook = new BorrowedBook(1, book, "Mahmoud", new DateTime(2025, 1, 6));

            /*
             * Use the CheckOut and ReturnItem methods to simulate borrowing and returning a book.
             */
            borrowedBook.CheckOut();
            borrowedBook.ReturnItem();

            // Calculate and display the borrow duration
            int borrowDuration = borrowedBook.CalculateBorrowDuration();
            Console.WriteLine($"The book has been borrowed for {borrowDuration} days.");

        }
    }
}
