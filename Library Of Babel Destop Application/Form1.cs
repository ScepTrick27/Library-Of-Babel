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
        private List<Book> books = new List<Book>();
        private byte[] image;
        public Form1()
        {
            InitializeComponent();

            bookManager = new BookManager(bookDB);

            foreach (Book b in bookManager.GetAllBooks())
            {
                lbBooks.Items.Add(b);
            }
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(sfd.FileName);
                using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                using MemoryStream memoryStream = new MemoryStream();
                fs.CopyTo(memoryStream);
                image = memoryStream.ToArray();
                lblPhotoStatus.Text = "Photo Added";
                lblPhotoStatus.ForeColor= Color.Green;
                MemoryStream stmBLOBData = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(stmBLOBData);
            }
            else { MessageBox.Show("You canceled"); }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbxTitle.Text) && !String.IsNullOrWhiteSpace(tbxDescription.Text) && !String.IsNullOrWhiteSpace(tbxAuthor.Text) && image != null)
            {
                bookManager.AddBook(new Book(tbxTitle.Text, tbxDescription.Text, tbxAuthor.Text, dtpPublishDate.Value, image));

                tbxTitle.Clear();
                tbxAuthor.Clear();
                tbxDescription.Clear();
                lblPhotoStatus.Text = "Please upload a photo";
                lblPhotoStatus.ForeColor= Color.Red;
                dtpPublishDate.Value = DateTime.Now;
                pictureBox1.Image = null;

                lbBooks.Items.Clear();

                foreach (Book b in bookManager.GetAllBooks())
                {
                    lbBooks.Items.Add(b);
                }

            }
            else
            {
                MessageBox.Show("Please add all the required information");
            }
        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book selectedBook = (Book)lbBooks.SelectedItem;
            MemoryStream stmBLOBData = new MemoryStream(selectedBook.BookImage);
            pictureBox1.Image = Image.FromStream(stmBLOBData);
        }
    }
}