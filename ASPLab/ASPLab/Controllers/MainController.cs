using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPLab.Models;
using ASPLab.DataAbstractionLayer;
using System.Web.UI;

namespace ASPLab.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View("LoginPage");
        }

        public string Test()
        {
            return "It's working";
        }
        public string GetBooksWithGenre()
        {
            string genre = Request.Params["genre"];
            DAL dal = new DAL();
            List<Book> slist = dal.GetBooksWithGenre(genre);
            ViewData["bookList"] = slist;

            string result = "<table><thead><th>Id</th><th>Author</th><th>Title</th><th>Genre</th><th>Pages</th></thead>";

            foreach (Book book in slist)
            {
                result += "<tr><td>" + book.Id + "</td><td>" + book.Author + "</td><td>" + book.Title + "</td><td>" + book.Genre + "</td><td>" + book.Pages + "</td></tr>";
            }

            result += "</table>";
            return result;
        }

        public string GetBooks()
        {
            DAL dal = new DAL();
            List<Book> slist = dal.GetBooks();
            ViewData["bookList"] = slist;

            string result = "<table ><thead><th>Id</th><th>Author</th><th>Title</th><th>Genre</th><th>Pages</th></thead>";

            foreach (Book book in slist)
            {
                result += "<tr><td>" + book.Id + "</td><td>" + book.Author + "</td><td>" + book.Title + "</td><td>" + book.Genre + "</td><td>" + book.Pages + "</td></tr>";
            }

            result += "</table>";
            return result;
        }

        public string GetRentals()
        {
            DAL dal = new DAL();
            List<Rental> slist = dal.GetRentals();
            ViewData["rentalList"] = slist;

            string result = "<table id = 'bookTable'><thead><th>Id</th><th>BookID</th><th>Customer Name</th></thead>";

            foreach (Rental rental in slist)
            {
                result += "<tr><td>" + rental.Id + "</td><td>" + rental.BookID + "</td><td>" + rental.Customer + "</td></tr>";
            }

            result += "</table>";
            return result;
        }

        public void insertBook()
        {
            string genre = Request.Params["bookgenre"];
            string title = Request.Params["title"];
            int pages = int.Parse(Request.Params["pages"]);
            string author = Request.Params["author"];
            DAL dal = new DAL();
            dal.InsertBook(author, title, genre, pages);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public void insertRental()
        {
            string customer = Request.Params["customer"];
            int bookid = int.Parse(Request.Params["bookrental"]);
            DAL dal = new DAL();
            dal.InsertRental(bookid, customer);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult login()
        {
            string username = Request.Params["user"];
            string password = Request.Params["password"];
            DAL dal = new DAL();
            string user = dal.login(username, password);
            if (user == "")
                return View("LoginPage");
            else
                Session["user"] = user;
                return View("LibraryPage");

        }

        public ActionResult logout()
        {
            Session.Abandon();
            return View("LoginPage");
        }

        public void updateBook()
        {
            int id = int.Parse(Request.Params["idupdate"]);
            string genre = Request.Params["genreupdate"];
            string title = Request.Params["titleupdate"];
            int pages = int.Parse(Request.Params["pagesupdate"]);
            string author = Request.Params["authorupdate"];
            DAL dal = new DAL();
            dal.UpdateBook(id, author, title, genre, pages);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public void deleteBook()
        {
            int id = int.Parse(Request.Params["bookid"]);
            DAL dal = new DAL();
            dal.DeleteBook(id);
            dal.DeleteRental(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        public void deleteRental()
        {
            int id = int.Parse(Request.Params["bookdelete"]);
            DAL dal = new DAL();
            dal.DeleteRental(id);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}