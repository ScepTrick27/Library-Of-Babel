namespace Library_Of_Babel_Destop_Application
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddPhoto = new Button();
            pictureBox1 = new PictureBox();
            tbxTitle = new TextBox();
            tbxDescription = new TextBox();
            tbxAuthor = new TextBox();
            dtpPublishDate = new DateTimePicker();
            lbBooks = new ListBox();
            btnAddBook = new Button();
            lblBookTitle = new Label();
            lblBookDescription = new Label();
            lblBookAuthor = new Label();
            lblPublishDate = new Label();
            lblPhotoStatus = new Label();
            cmbGenres = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.Location = new Point(42, 280);
            btnAddPhoto.Margin = new Padding(2);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(78, 20);
            btnAddPhoto.TabIndex = 0;
            btnAddPhoto.Text = "Add Photo";
            btnAddPhoto.UseVisualStyleBackColor = true;
            btnAddPhoto.Click += btnAddPhoto_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(318, 16);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(401, 392);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tbxTitle
            // 
            tbxTitle.Location = new Point(42, 26);
            tbxTitle.Margin = new Padding(2);
            tbxTitle.Name = "tbxTitle";
            tbxTitle.Size = new Size(106, 23);
            tbxTitle.TabIndex = 2;
            // 
            // tbxDescription
            // 
            tbxDescription.Location = new Point(42, 72);
            tbxDescription.Margin = new Padding(2);
            tbxDescription.Name = "tbxDescription";
            tbxDescription.Size = new Size(106, 23);
            tbxDescription.TabIndex = 3;
            // 
            // tbxAuthor
            // 
            tbxAuthor.Location = new Point(42, 116);
            tbxAuthor.Margin = new Padding(2);
            tbxAuthor.Name = "tbxAuthor";
            tbxAuthor.Size = new Size(106, 23);
            tbxAuthor.TabIndex = 4;
            // 
            // dtpPublishDate
            // 
            dtpPublishDate.Location = new Point(42, 169);
            dtpPublishDate.Margin = new Padding(2);
            dtpPublishDate.Name = "dtpPublishDate";
            dtpPublishDate.Size = new Size(211, 23);
            dtpPublishDate.TabIndex = 5;
            // 
            // lbBooks
            // 
            lbBooks.FormattingEnabled = true;
            lbBooks.ItemHeight = 15;
            lbBooks.Location = new Point(755, 16);
            lbBooks.Margin = new Padding(2);
            lbBooks.Name = "lbBooks";
            lbBooks.Size = new Size(353, 394);
            lbBooks.TabIndex = 6;
            lbBooks.SelectedIndexChanged += lbBooks_SelectedIndexChanged;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(42, 344);
            btnAddBook.Margin = new Padding(2);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(78, 20);
            btnAddBook.TabIndex = 7;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(42, 10);
            lblBookTitle.Margin = new Padding(2, 0, 2, 0);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(59, 15);
            lblBookTitle.TabIndex = 8;
            lblBookTitle.Text = "Book Title";
            // 
            // lblBookDescription
            // 
            lblBookDescription.AutoSize = true;
            lblBookDescription.Location = new Point(42, 55);
            lblBookDescription.Margin = new Padding(2, 0, 2, 0);
            lblBookDescription.Name = "lblBookDescription";
            lblBookDescription.Size = new Size(97, 15);
            lblBookDescription.TabIndex = 9;
            lblBookDescription.Text = "Book Description";
            // 
            // lblBookAuthor
            // 
            lblBookAuthor.AutoSize = true;
            lblBookAuthor.Location = new Point(42, 100);
            lblBookAuthor.Margin = new Padding(2, 0, 2, 0);
            lblBookAuthor.Name = "lblBookAuthor";
            lblBookAuthor.Size = new Size(74, 15);
            lblBookAuthor.TabIndex = 10;
            lblBookAuthor.Text = "Book Author";
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Location = new Point(42, 152);
            lblPublishDate.Margin = new Padding(2, 0, 2, 0);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(73, 15);
            lblPublishDate.TabIndex = 11;
            lblPublishDate.Text = "Publish Date";
            // 
            // lblPhotoStatus
            // 
            lblPhotoStatus.AutoSize = true;
            lblPhotoStatus.ForeColor = Color.Red;
            lblPhotoStatus.Location = new Point(42, 302);
            lblPhotoStatus.Margin = new Padding(2, 0, 2, 0);
            lblPhotoStatus.Name = "lblPhotoStatus";
            lblPhotoStatus.Size = new Size(111, 15);
            lblPhotoStatus.TabIndex = 12;
            lblPhotoStatus.Text = "No photo uploaded";
            // 
            // cmbGenres
            // 
            cmbGenres.FormattingEnabled = true;
            cmbGenres.Location = new Point(42, 225);
            cmbGenres.Name = "cmbGenres";
            cmbGenres.Size = new Size(121, 23);
            cmbGenres.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 462);
            Controls.Add(cmbGenres);
            Controls.Add(lblPhotoStatus);
            Controls.Add(lblPublishDate);
            Controls.Add(lblBookAuthor);
            Controls.Add(lblBookDescription);
            Controls.Add(lblBookTitle);
            Controls.Add(btnAddBook);
            Controls.Add(lbBooks);
            Controls.Add(dtpPublishDate);
            Controls.Add(tbxAuthor);
            Controls.Add(tbxDescription);
            Controls.Add(tbxTitle);
            Controls.Add(pictureBox1);
            Controls.Add(btnAddPhoto);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddPhoto;
        private PictureBox pictureBox1;
        private TextBox tbxTitle;
        private TextBox tbxDescription;
        private TextBox tbxAuthor;
        private DateTimePicker dtpPublishDate;
        private ListBox lbBooks;
        private Button btnAddBook;
        private Label lblBookTitle;
        private Label lblBookDescription;
        private Label lblBookAuthor;
        private Label lblPublishDate;
        private Label lblPhotoStatus;
        private ComboBox cmbGenres;
    }
}