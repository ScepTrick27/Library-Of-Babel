using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Logic.Managers;
using DataLogic.Interfaces;
using Logic;
using DataLogic.DBs;

namespace Library_Of_Babel_Destop_Application
{
    public partial class Form1 : Form
    {
        private readonly BookManager bookManager;
        private readonly IBookDB bookDB = new BookDB();
        private Book book = new Book();
        private List<Book> books = new List<Book>();
        public Form1()
        {
            InitializeComponent();

            bookManager = new BookManager(bookDB);

            foreach (Book b in bookManager.GetAllBooks())
            {
                listBox1.Items.Add(b);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename;
            OpenFileDialog sfd = new OpenFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = System.IO.Path.GetFullPath(sfd.FileName);
                using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using MemoryStream memoryStream = new MemoryStream();
                fs.CopyTo(memoryStream);
                //photo = br.ReadBytes((int)fs.Length);
                book.BookImage = memoryStream.ToArray();

                //MemoryStream stmBLOBData = new MemoryStream(photo);
                //pictureBox1.Image = Image.FromStream(stmBLOBData);
            }
            else { MessageBox.Show("You canceled"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bookManager.AddBook(new Book(tbxTitle.Text, tbxDescription.Text, tbxAuthor.Text, dtpPublishDate.Value, "1", book.BookImage));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book selectedBook = (Book)listBox1.SelectedItem;
            MemoryStream stmBLOBData = new MemoryStream(selectedBook.BookImage);
            pictureBox1.Image = Image.FromStream(stmBLOBData);
        }
    }
}