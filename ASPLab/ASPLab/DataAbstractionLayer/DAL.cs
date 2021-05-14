using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ASPLab.Models;
using MySql.Data.MySqlClient;

namespace ASPLab.DataAbstractionLayer
{
    public class DAL
    {
        string myConnectionString;

        public void InsertBook(string author, string title, string genre, int pages)
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string cmdText = "INSERT INTO books VALUES (null, @author, @title, @genre, @pages)";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@pages", pages);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void InsertRental(int bookid, string customer)
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string cmdText = "INSERT INTO rentals VALUES (null, @bookid, @customer)";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@bookid", bookid);
                cmd.Parameters.AddWithValue("@customer", customer);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public String login(string username, string password)
        {
            MySqlConnection conn;
            string user = "";

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username = '" + username + "' and password = '" + password + "'"; ;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    user = myreader.GetString("username");
                }
                myreader.Close();

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return user;
        }

        public void UpdateBook(int id, string author, string title, string genre, int pages)
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string cmdText = "update books set author = @author, title = @title, pages = @pages, genre = @genre where id = @id";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@pages", pages);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void DeleteBook(int id)
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string cmdText = "delete from books where id = @id";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void DeleteRental(int id)
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                string cmdText = "delete from rentals where bookid = @id";
                MySqlCommand cmd = new MySqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public List<Book> GetBooksWithGenre(string genre)
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            List<Book> slist = new List<Book>();

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from books where genre = '" + genre + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Book book = new Book();
                    book.Id = myreader.GetInt32("id");
                    book.Author = myreader.GetString("author");
                    book.Title = myreader.GetString("title");
                    book.Pages = myreader.GetInt32("pages");
                    book.Genre = myreader.GetString("genre");
                    slist.Add(book);
                }
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return slist;
        }

        public List<Book> GetBooks()
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            List<Book> slist = new List<Book>();

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from books";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Book book = new Book();
                    book.Id = myreader.GetInt32("id");
                    book.Author = myreader.GetString("author");
                    book.Title = myreader.GetString("title");
                    book.Pages = myreader.GetInt32("pages");
                    book.Genre = myreader.GetString("genre");
                    slist.Add(book);
                }
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return slist;
        }

        public List<Rental> GetRentals()
        {
            MySqlConnection conn;

            myConnectionString = "server=localhost;uid=root;pwd=1234;database=library;";
            List<Rental> slist = new List<Rental>();

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from rentals";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Rental rental = new Rental();
                    rental.Id = myreader.GetInt32("id");
                    rental.Customer = myreader.GetString("customer");
                    rental.BookID = myreader.GetInt32("bookid");
                    slist.Add(rental);
                }
                myreader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return slist;
        }
    }
}