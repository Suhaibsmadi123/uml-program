using program;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace program
{
    [Serializable]
    class Person
    {
        private string name;
        private string username;
        private string password;
        private string email;
        private double fees = 0;
        private char Type;
        private List<string> inbox = new List<string>();
        public void ADD_2inbox(string massage)
        {
            inbox.Add(massage);
        }
        public Person()
        {
            name = "";
            username = "";
            password = "";
            email = "";
        }
        public Person(string n, string p)
        {
            username = n;
            password = p;
        }
        public Person(string n, string u, string p, string e, char Type)
        {
            name = n;
            username = u;
            password = p;
            email = e;
            this.Type = Type;
        }
        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }
        public string Username
        {
            get { return this.username; }
            set { username = value; }
        }
        public double Fees
        {
            get { return this.fees; }
            set { fees = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { password = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { email = value; }
        }

        public char Type1
        {
            get { return this.Type; }
            set { Type = value; }
        }

        public void Print()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("name : " + name);
            Console.WriteLine("username : " + username);
            Console.WriteLine("password : " + password);
            Console.WriteLine("email : " + email);
            Console.WriteLine("fees  = " + fees);
            if (Type == 'L')
                Console.WriteLine("Type  : Liberian ");
            else
                Console.WriteLine("Type  : Patron");
            Console.WriteLine("*******************************************");
        }
        public void PrintM()
        {
            for (int i = 0; i < inbox.Count; i++)
                Console.WriteLine(i + 1 + ")  " + inbox[i] + "\n\n");
        }

    }
    [Serializable]
    class Book
    {
        private string bookname;
        private string author;
        private string genre;
        private int isbn;
        private int year;
        private bool states;
        private int return_date = 0;
        private int taken_date = 0;

        public Book(string bookname, string author, string genre, int isbn, int year, bool states)
        {
            this.bookname = bookname;
            this.author = author;
            this.genre = genre;
            this.isbn = isbn;
            this.year = year;
            this.states = states;
        }
        public Book()
        {
            this.bookname = "";
            this.author = "";
            this.genre = "";
            this.isbn = 0;
            this.year = 0;
            this.states = true;
        }
        public string BOOKN
        {
            get { return this.bookname; }
            set { bookname = value; }

        }
        public string ATHUOR
        {
            get { return this.author; }
            set { author = value; }

        }

        public string GNERE
        {
            get { return this.genre; }
            set { genre = value; }

        }
        public int YEAR
        {
            get { return this.year; }
            set { year = value; }

        }
        public int ISBN
        {
            get { return this.isbn; }
            set { isbn = value; }

        }
        public bool STATES
        {
            get { return this.states; }
            set { states = value; }

        }
        public int Return_date
        {
            get { return this.return_date; }
            set { return_date = value; }

        }
        public int Taken_date
        {
            get { return this.taken_date; }
            set { taken_date = value; }

        }
        public void print()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("book title = " + bookname);
            Console.WriteLine("book author = " + author);
            Console.WriteLine("book publication year = " + year);
            Console.WriteLine("book genre = " + genre);
            Console.WriteLine("book ISBN = " + isbn);
            Console.WriteLine("book status = " + states);
            Console.WriteLine("***************************************");
        }

    }
    [Serializable]
    class request
    {
        public string book_name;
        public string username;

        public request(string book_name, string username)
        {
            this.book_name = book_name;
            this.username = username;
        }
        public string Book_name
        {
            get { return this.book_name; }
            set { book_name = value; }

        }
        public string Username
        {
            get { return this.username; }
            set { username = value; }

        }
    }
    [Serializable]
    class libary
    {
        List<Person> users = new List<Person>();
        List<Book> books = new List<Book>();
        List<string> category = new List<string>();
        List<request> requests = new List<request>();
        List<request> borrowed = new List<request>();
        List<double> money = new List<double>();
        public libary()
        {
            this.users = new List<Person>();
            this.books = new List<Book>();
            this.category = new List<string>();
            this.requests = new List<request>();
            this.borrowed = new List<request>();
            this.money = new List<double>();
           // money.Add(0);
           //money.Add(0);
        }

        public void registration()
        {
            Console.WriteLine("Regestration new account ");
            Console.WriteLine("enter the name ");
            string name = Console.ReadLine();
            Console.WriteLine("enter the username ");
            string username = Console.ReadLine();
            for (int i = 0; i < users.Count; i++)
            {
                if (username == users[i].Username)
                {
                    Console.WriteLine("invalid username  ");
                    Console.WriteLine("re-enter username ");
                    username = Console.ReadLine();
                    i = 0;
                }
            }
            Console.WriteLine("enter password ");
            string password = Console.ReadLine();
            Console.WriteLine("enter the email address ");
            string email = Console.ReadLine();
            Person new_Acc = new Person(name, username, password, email, 'P');
            users.Add(new_Acc);
        }
        public void AddBook()
        {
            Console.WriteLine("enter the book title ");
            string title = Console.ReadLine();
            Console.WriteLine("enter the author ");
            string author = Console.ReadLine();
            Console.WriteLine("enter publication year ");
            int publication_year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the  genre ");
            string genre = Console.ReadLine();
            Console.WriteLine("enter  ISBN (Int number ) ");
            int ISBN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the book status (T,F)");
            string status = Console.ReadLine();
            bool fstatus = true;
            for (int i = 0; i < 1; i++)
            {
                if (status == "T" || status == "t" || status == "1")
                {
                    fstatus = true;
                }
                else if (status == "F" || status == "f" || status == "0")
                {
                    fstatus = false;
                }
                else
                {
                    Console.WriteLine("invalid input  ");
                    Console.WriteLine("re-enter book status (T,F) ");
                    status = Console.ReadLine();
                    i = 0;
                }
            }
            if (category.Count == 0)
                category.Add(genre);


            for (int i = 0; i < category.Count; i++)
            {
                if (genre != category[i] && i == category.Count - 1)
                {
                    category.Add(genre);
                }
                else if (genre == category[i])
                    break;
            }
            Book new_book = new Book(title, author, genre, ISBN, publication_year, fstatus);
            books.Add(new_book);


        }
        public void searchforbook()
        {
            bool flage = true;
            while (flage)
            {
                Console.WriteLine("enter you what to search for the book (1-4)");
                Console.WriteLine("1) by title");
                Console.WriteLine("2) author");
                Console.WriteLine("3) ISBN");
                Console.WriteLine("4) genre");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("enter the book title ");
                    string title = Console.ReadLine();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (title == books[i].BOOKN)
                        {
                            books[i].print();
                            flage = false;
                        }
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("enter the book author ");
                    string author = Console.ReadLine();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (author == books[i].ATHUOR)
                        {
                            books[i].print();
                            flage = false;

                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("enter the book ISBN ");
                    int ISBN = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (ISBN == books[i].ISBN)
                        {
                            books[i].print();
                            flage = false;
                        }
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("enter the book genre ");
                    string genre = Console.ReadLine();
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (genre == books[i].GNERE)
                        {
                            books[i].print();
                            flage = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("***************************************");
                    Console.WriteLine("invalid input");
                    Console.WriteLine("***************************************");
                }
            }
        }
        public void ViewAllBooks()
        {

            int count = 0;
            Console.WriteLine("total number of books = " + books.Count);
            for (int j = 0; j < category.Count; j++)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].GNERE == category[j])
                    {
                        books[i].print();
                        count++;
                    }
                }
                Console.WriteLine("total number of  " + category[j] + "  books  = " + count);
                count = 0;
            }

            count = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].STATES == false)
                    count++;
            }
            Console.WriteLine("total number of books in loan = " + count);

        }
        public void Borrowing(string username)
        {
            Console.WriteLine("All Availble books ");
            Console.WriteLine("********************************************");
            for (int j = 0; j < category.Count; j++)
            {
                Console.WriteLine(" books of " + category[j]);
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].GNERE == category[j] && books[i].STATES == true)
                        books[i].print();
                }
                Console.WriteLine("=======================================");
            }
            Console.WriteLine("********************************************");
            Console.WriteLine("please enter name of the book you want to borrow");
            string book_name = Console.ReadLine();
            for (int i = 0; i < books.Count; i++)
            {
                if (book_name == books[i].BOOKN)
                {
                    request r = new request(book_name, username);
                    requests.Add(r);
                }
            }
        }
        public void CheckOut()
        {
            Console.WriteLine(borrowed.Count + "   " + requests.Count);

            if (requests.Count > 0)
            {
                for (int j = 0; j < requests.Count; j++)
                {
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].STATES == true && requests[j].book_name == books[i].BOOKN)
                        {
                            Console.WriteLine("Enter the current date ");
                            Console.Write("year = ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("month = ");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.Write("day = ");
                            int day = Convert.ToInt32(Console.ReadLine());
                            int current = year * 365 + month * 30 + day;
                            int Return = 0;
                            while (true)
                            {
                                Console.WriteLine("Enter the return date ");
                                Console.Write("year = ");
                                year = Convert.ToInt32(Console.ReadLine());
                                Console.Write("month = ");
                                month = Convert.ToInt32(Console.ReadLine());
                                Console.Write("day = ");
                                day = Convert.ToInt32(Console.ReadLine());
                                Return = year * 365 + month * 30 + day;
                                if (Return > current)
                                    break;
                                else
                                {
                                    Console.WriteLine("**********************************");
                                    Console.WriteLine("invalid input");
                                    Console.WriteLine("**********************************");
                                }
                            }
                            books[i].Taken_date = current;
                            books[i].Return_date = Return;
                            books[i].STATES = false;
                            borrowed.Add(requests[j]);
                            requests.Remove(requests[j]);
                            i = books.Count;
                            j = requests.Count;

                        }
                        else if (requests[j].book_name != books[i].BOOKN && i == books.Count - 1)
                        {
                            Console.WriteLine("we don't have this book in our liberary ");

                        }
                    }
                }
            }
            else {
                Console.WriteLine("you do not have any requests book ");
               }
        }
        public void CheckIn()
        {
           
            if (borrowed.Count > 0)
            {
                Console.WriteLine("Enter the book name  ");
                string Book_name = Console.ReadLine();
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].BOOKN == Book_name && books[i].STATES == false)
                    {

                        books[i].STATES = true;
                        Console.WriteLine("Enter the current date ");
                        Console.Write("year = ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("month = ");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("day = ");
                        int day = Convert.ToInt32(Console.ReadLine());
                        int current = year * 365 + month * 30 + day;
                        if (current > books[i].Return_date)
                        {
                            for (int x = 0; x < borrowed.Count; x++)
                            {
                                if (borrowed[x].Book_name == Book_name)
                                {
                                    for (int y = 0; y < users.Count; y++)
                                    {
                                        if (users[y].Username == borrowed[x].Username)
                                        {
                                            users[y].Fees += Convert.ToInt32(current - books[i].Return_date) * 0.3;
                                            Console.WriteLine(users[y].Username + " total fees =  " + users[y].Fees);
                                            money[0] += users[y].Fees;
                                            books[i].Return_date = 0;
                                            books[i].Taken_date = 0;

                                            for (int xr = 0; xr < requests.Count; xr++)
                                            {
                                                if (requests[xr].Book_name == Book_name)
                                                {
                                                    for (int yr = 0; yr < users.Count; yr++)
                                                    {
                                                        if (users[yr].Username == requests[xr].Username)
                                                        {
                                                            string s = "this book is availble " + Book_name;
                                                            users[yr].ADD_2inbox(s);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine("555555555555555555555555");

                                    borrowed.Remove(borrowed[x]);
                                    x = borrowed.Count;
                                }
                            }

                        }
                        else if (current < books[i].Taken_date)
                        {
                            Console.WriteLine("*****Invalid Input********* ");
                            i--;
                        }
                        else
                        {
                            int k = 0;
                            for (int x = 0; x < borrowed.Count; x++) {
                                if (borrowed[x].Book_name == Book_name)
                                {
                                    k = x; break;


                                }
                            }
                            borrowed.Remove(borrowed[k]);

                            Console.WriteLine("no fees has been added to the user ");

                        }

                        break;
                    }
                    
                }
            }
            else { Console.WriteLine("There is no borrowed book "); }
        }
        public void SendMassage()
        {
            Console.WriteLine("please enter username ");
            string username = Console.ReadLine();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {
                    Console.WriteLine("please write your massage ");
                    string massage = Console.ReadLine();
                    users[i].ADD_2inbox(massage);
                    break;
                }
                if (users[i].Username != username && i == users.Count - 1)
                {
                    Console.WriteLine("user not found");
                }
            }
        }
        public void pay(string username)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (username == users[i].Username)
                {
                    Console.WriteLine("total fees = " + users[i].Fees);
                    double z = 0;
                    Console.WriteLine("how much do u want to pay ? ");
                    Console.Write("Amount = ");
                    double d = Convert.ToDouble(Console.ReadLine());
                    if (d >= z && d <= users[i].Fees)
                    {
                        users[i].Fees = users[i].Fees - d;
                        Console.WriteLine("YOUR CURRENT  fees = " + users[i].Fees);
                        money[1] += d;
                        money[0] -= d;
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
            }
        }
        public void financial()
        {
            Console.WriteLine("****************************************************");
            Console.WriteLine("total collected fines = " + money[1]);
            Console.WriteLine("total uncollected fines = " + money[0]);
            Console.WriteLine("****************************************************");
        }
        public void ViewAllUsers()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("Liberians");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Type1 == 'L')
                    users[i].Print();
            }
            Console.WriteLine("=====================================================");
            Console.WriteLine("Patrons");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Type1 == 'P')
                    users[i].Print();
            }
            Console.WriteLine("=====================================================");
        }
        public void DeleteUser()
        {
            for (int i = 0; i < users.Count; i++)
                Console.WriteLine(users[i].Username);
            Console.Write("******************************************************");
            Console.Write("Enter username that you want to delete : \n");
            string user_name = Console.ReadLine();
            for (int i = 0; i < users.Count; i++)
                if (users[i].Username == user_name)
                    users.Remove(users[i]);
        }
        public void DeleteBook()
        {
            for (int i = 0; i < books.Count; i++)
                Console.WriteLine(books[i].BOOKN);
            Console.Write("******************************************************");
            Console.Write("Enter Book Name that you want to delete : \n");
            string book_name = Console.ReadLine();
            for (int j = 0; j < books.Count; j++)
                if (books[j].BOOKN == book_name)
                    books.Remove(books[j]);
        }
        public void modifyUsers()
        {
            Console.Write("******************************************************");
            Console.Write("Enter username that you want mdify : ");
            string user_name = Console.ReadLine();
            for (int i = 0; i < users.Count; i++)
                if (users[i].Username == user_name)
                {
                    string choice = "";
                    while (choice != "5")
                    {
                        Console.WriteLine("**** modify list ******");
                        Console.WriteLine();
                        Console.WriteLine("1) username");
                        Console.WriteLine("2) name");
                        Console.WriteLine("3) password");
                        Console.WriteLine("4) email");
                        Console.WriteLine("5) exit");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.Write("Enter new username  : ");
                            string newuser_name = Console.ReadLine();
                            for (int j = 0; j < users.Count; j++)
                            {
                                if (users[j].Username != newuser_name && j == users.Count - 1)
                                    users[i].Username = newuser_name;
                               else if (users[j].Username == newuser_name)
                                {
                                    Console.Write("Invalid Input enter new username ");
                                    newuser_name = Console.ReadLine();
                                    j = 0;

                                }
                            }

                        }
                        else if (choice == "2")
                        {
                            Console.Write("Enter new name  : ");
                            string newuser_name = Console.ReadLine();
                            users[i].Name = newuser_name;
                        }
                        else if (choice == "3")
                        {
                            Console.Write("Enter new password  : ");
                            string newuser_name = Console.ReadLine();
                            users[i].Password = newuser_name;
                        }
                        else if (choice == "4")
                        {
                            Console.Write("Enter new email  : ");
                            string newuser_name = Console.ReadLine();
                            users[i].Email = newuser_name;
                        }
                        else if (choice == "5")
                            Console.WriteLine("\n\nEnd of modiying\n\n");
                        else
                            Console.WriteLine("Invalid Input (1-5)");

                    }
                }
                else if (users[i].Username != user_name && i == users.Count - 1)
                    Console.Write("there isn't such a user");
        }
        public bool authintication(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
                if (users[i].Username == username && users[i].Type1 == 'L' && users[i].Password == password)
                    return true;
            return false;
        }
        public bool authintication2(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
                if (users[i].Username == username && users[i].Type1 == 'P' && users[i].Password == password)
                    return true;
            return false;
        }
        public void AddNewUser()
        {
            Console.WriteLine("enter the name ");
            string name = Console.ReadLine();
            Console.WriteLine("enter the username ");
            string username = Console.ReadLine();
            for (int i = 0; i < users.Count; i++)
            {
                if (username == users[i].Username)
                {
                    Console.WriteLine("invalid username  ");
                    Console.WriteLine("re-enter username ");
                    username = Console.ReadLine();
                    i = 0;
                }
            }
            Console.WriteLine("enter password ");
            string password = Console.ReadLine();
            Console.WriteLine("enter the email address ");
            string email = Console.ReadLine();
            char T;
            while (true)
            {
                Console.WriteLine("enter the user type (L:liberian,P:patron)");
                string Type = Console.ReadLine();
                if (Type[0] == 'P' || Type[0] == 'p')
                {
                    T = 'P';
                    break;
                }
                else if (Type[0] == 'L' || Type[0] == 'l')
                {
                    T = 'L';
                    break;
                }
                else
                    Console.WriteLine("\n\nInvalid Input (L,P)\n");
            }
            Person new_Acc = new Person(name, username, password, email, T);
            users.Add(new_Acc);
            Save();
        }

        public void Load()
        {
            FileStream fs0 = new FileStream("users.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            while (fs0.Position < fs0.Length)
            {
                users.Add((Person)bf.Deserialize(fs0));
            }
            fs0.Close();



            FileStream fs1 = new FileStream("books.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf1 = new BinaryFormatter();

            while (fs1.Position < fs1.Length)
            {
                books.Add((Book)bf1.Deserialize(fs1));
            }
            fs1.Close();



            FileStream fs2 = new FileStream("category.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf2 = new BinaryFormatter();

            while (fs2.Position < fs2.Length)
            {
                category.Add((string)bf2.Deserialize(fs2));
            }
            fs2.Close();



            FileStream fs3 = new FileStream("requests.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf3 = new BinaryFormatter();

            while (fs3.Position < fs3.Length)
            {
                requests.Add((request)bf3.Deserialize(fs3));
            }
            fs3.Close();



            FileStream fs4 = new FileStream("borrowed.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf4 = new BinaryFormatter();

            while (fs4.Position < fs4.Length)
            {
                borrowed.Add((request)bf4.Deserialize(fs4));
            }
            fs4.Close();

            FileStream fs5 = new FileStream("money.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf5 = new BinaryFormatter();

            while (fs5.Position < fs5.Length)
            {
                money.Add((double)bf5.Deserialize(fs5));
            }
            fs5.Close();
        }
        public void Save()
        {
            FileStream fs0 = new FileStream("users.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            for (int i = 0; i < users.Count; i++)
            {
                bf.Serialize(fs0, users[i]);
            }
            fs0.Close();

            FileStream fs1 = new FileStream("books.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf1 = new BinaryFormatter();
            for (int i = 0; i < books.Count; i++)
            {
                bf1.Serialize(fs1, books[i]);
            }
            fs1.Close();

            FileStream fs2 = new FileStream("category.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf2 = new BinaryFormatter();
            for (int i = 0; i < category.Count; i++)
            {
                bf2.Serialize(fs2, category[i]);
            }
            fs2.Close();
            FileStream fs3 = new FileStream("requests.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf3 = new BinaryFormatter();
            for (int i = 0; i < requests.Count; i++)
            {
                bf3.Serialize(fs3, requests[i]);
            }
            fs3.Close();
            FileStream fs4 = new FileStream("borrowed.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf4 = new BinaryFormatter();
            for (int i = 0; i < borrowed.Count; i++)
            {
                bf4.Serialize(fs4, borrowed[i]);
            }
            fs4.Close();
            FileStream fs5 = new FileStream("money.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf5 = new BinaryFormatter();
            for (int i = 0; i < money.Count; i++)
            {
                bf5.Serialize(fs5, money[i]);
            }
            fs5.Close();
        }
        public void PrintMassages(string username)
        {
            for (int i = 0; i < users.Count; i++)
                if (users[i].Username == username)
                    users[i].PrintM();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            libary Liberary1 = new libary();
            Liberary1.Load();
            string Login = "";
            while (Login != "5")
            {
                Console.WriteLine("1) Login as Admin \n2) Login as Liberian  \n3) Login as Patron \n4) Regester new Patron \n5) Exit\n\nPlease Enter Your Choice\n");
                Login = System.Console.ReadLine();
                string Username, password;
                if (Login == "1")
                {
                    Console.WriteLine("Enter Username : \n");
                    Username = Console.ReadLine();
                    Console.WriteLine("\nEnter Password\n");
                    password = Console.ReadLine();
                    if (Username == "admin" && password == "1234")
                    {
                        string choice = "";
                        while (choice != "9")
                        {
                            Console.WriteLine("**** HI , Welcome Administrator ****");
                            Console.WriteLine();
                            Console.WriteLine("1) Add a user");
                            Console.WriteLine("2) modify user");
                            Console.WriteLine("3) add book");
                            Console.WriteLine("4) view all Books");
                            Console.WriteLine("5) view all users");
                            Console.WriteLine("6) financial report");
                            Console.WriteLine("7) delete user");
                            Console.WriteLine("8) delete a book");
                            Console.WriteLine("9) Logout");
                            Console.WriteLine();
                            Console.WriteLine("please Enter Your Choice : ");
                            choice = Console.ReadLine();


                            if (choice == "1")
                                Liberary1.AddNewUser();
                            else if (choice == "2")
                                Liberary1.modifyUsers();
                            else if (choice == "3")
                                Liberary1.AddBook();
                            else if (choice == "4")
                                Liberary1.ViewAllBooks();
                            else if (choice == "5")
                                Liberary1.ViewAllUsers();
                            else if (choice == "6")
                                Liberary1.financial();
                            else if (choice == "7")
                                Liberary1.DeleteUser();
                            else if (choice == "8")
                                Liberary1.DeleteBook();
                            else if (choice == "9")
                                Console.WriteLine("*********Good bye ADMIN*************");
                            else
                                Console.WriteLine("Invalid Input (1-9)");
                        }
                    }
                    else
                        Console.WriteLine("Wrong name Or Password\n");

                }
                else if (Login == "2")
                {
                    Console.Write("Enter Username : ");
                    Username = Console.ReadLine();
                    System.Console.Write("\nEnter Password : ");
                    password = Console.ReadLine();
                    if (Liberary1.authintication(Username, password))
                    {
                        string choice = "";
                        while (choice != "8")
                        {



                            Console.WriteLine("**** HI , Welcome " + Username + " ******");
                            Console.WriteLine();
                            Console.WriteLine("1) add book");
                            Console.WriteLine("2) view all Books");
                            Console.WriteLine("3) send a personal massage");
                            Console.WriteLine("4) financial report");
                            Console.WriteLine("5) check out");
                            Console.WriteLine("6) checkin");
                            Console.WriteLine("7) search for a specific book");
                            Console.WriteLine("8) exit");
                            choice = Console.ReadLine();
                            if (choice == "1")
                                Liberary1.AddBook();
                            else if (choice == "2")
                                Liberary1.ViewAllBooks();
                            else if (choice == "3")
                                Liberary1.SendMassage();

                            else if (choice == "4")
                                Liberary1.financial();
                            else if (choice == "5")
                                Liberary1.CheckOut();
                            else if (choice == "6")
                                Liberary1.CheckIn();
                            else if (choice == "7")
                                Liberary1.searchforbook();
                            else if (choice == "8")
                                Console.WriteLine("******Good bye liberian********");
                            else
                                Console.WriteLine("Invalid input (1-8)");
                        }
                    }
                    else
                        Console.WriteLine("******you can't access********");



                }
                else if (Login == "3")
                {
                    Console.Write("Enter Username : ");
                    Username = Console.ReadLine();
                    Console.Write("\nEnter Password : ");
                    password = Console.ReadLine();
                    if (Liberary1.authintication2(Username, password))
                    {
                        string choice = "";
                        while (choice != "5")
                        {



                            Console.WriteLine("**** HI , Welcome " + Username + " ******");
                            Console.WriteLine();
                            Console.WriteLine("1) Borrow a book");
                            Console.WriteLine("2) pay fees");
                            Console.WriteLine("3) view massages");
                            Console.WriteLine("4) search for a specific book");
                            Console.WriteLine("5) exit");
                            choice = Console.ReadLine();
                            if (choice == "1")
                                Liberary1.Borrowing(Username);
                            else if (choice == "2")
                                Liberary1.pay(Username);
                            else if (choice == "3")
                                Liberary1.PrintMassages(Username);
                            else if (choice == "4")
                                Liberary1.searchforbook();
                            else if (choice == "5")
                                Console.WriteLine("****** Good bye ********");
                            else
                                Console.WriteLine("Invalid input (1-8)");
                        }
                    }
                    else
                        Console.WriteLine("****** Invalid access ********");

                }
                else if (Login == "4")
                    Liberary1.registration();
                else if (Login == "5")
                    Console.WriteLine("\n.....thanks for visiting our liberary .....");
                else
                    Console.WriteLine("Invalid Input please enter a number from (1-4)");
                Liberary1.Save();
            }
            Liberary1.Save();
        }
    }

}
