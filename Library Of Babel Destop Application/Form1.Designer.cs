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
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.tbxAuthor = new System.Windows.Forms.TextBox();
            this.dtpPublishDate = new System.Windows.Forms.DateTimePicker();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblBookDescription = new System.Windows.Forms.Label();
            this.lblBookAuthor = new System.Windows.Forms.Label();
            this.lblPublishDate = new System.Windows.Forms.Label();
            this.lblPhotoStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(60, 367);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(112, 34);
            this.btnAddPhoto.TabIndex = 0;
            this.btnAddPhoto.Text = "Add Photo";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(454, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(573, 654);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(60, 44);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(150, 31);
            this.tbxTitle.TabIndex = 2;
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(60, 120);
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(150, 31);
            this.tbxDescription.TabIndex = 3;
            // 
            // tbxAuthor
            // 
            this.tbxAuthor.Location = new System.Drawing.Point(60, 194);
            this.tbxAuthor.Name = "tbxAuthor";
            this.tbxAuthor.Size = new System.Drawing.Size(150, 31);
            this.tbxAuthor.TabIndex = 4;
            // 
            // dtpPublishDate
            // 
            this.dtpPublishDate.Location = new System.Drawing.Point(60, 282);
            this.dtpPublishDate.Name = "dtpPublishDate";
            this.dtpPublishDate.Size = new System.Drawing.Size(300, 31);
            this.dtpPublishDate.TabIndex = 5;
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.ItemHeight = 25;
            this.lbBooks.Location = new System.Drawing.Point(1078, 26);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(502, 654);
            this.lbBooks.TabIndex = 6;
            this.lbBooks.SelectedIndexChanged += new System.EventHandler(this.lbBooks_SelectedIndexChanged);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(60, 474);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(112, 34);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Location = new System.Drawing.Point(60, 16);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(90, 25);
            this.lblBookTitle.TabIndex = 8;
            this.lblBookTitle.Text = "Book Title";
            // 
            // lblBookDescription
            // 
            this.lblBookDescription.AutoSize = true;
            this.lblBookDescription.Location = new System.Drawing.Point(60, 92);
            this.lblBookDescription.Name = "lblBookDescription";
            this.lblBookDescription.Size = new System.Drawing.Size(148, 25);
            this.lblBookDescription.TabIndex = 9;
            this.lblBookDescription.Text = "Book Description";
            // 
            // lblBookAuthor
            // 
            this.lblBookAuthor.AutoSize = true;
            this.lblBookAuthor.Location = new System.Drawing.Point(60, 166);
            this.lblBookAuthor.Name = "lblBookAuthor";
            this.lblBookAuthor.Size = new System.Drawing.Size(113, 25);
            this.lblBookAuthor.TabIndex = 10;
            this.lblBookAuthor.Text = "Book Author";
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.AutoSize = true;
            this.lblPublishDate.Location = new System.Drawing.Point(60, 254);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(111, 25);
            this.lblPublishDate.TabIndex = 11;
            this.lblPublishDate.Text = "Publish Date";
            // 
            // lblPhotoStatus
            // 
            this.lblPhotoStatus.AutoSize = true;
            this.lblPhotoStatus.ForeColor = System.Drawing.Color.Red;
            this.lblPhotoStatus.Location = new System.Drawing.Point(60, 404);
            this.lblPhotoStatus.Name = "lblPhotoStatus";
            this.lblPhotoStatus.Size = new System.Drawing.Size(171, 25);
            this.lblPhotoStatus.TabIndex = 12;
            this.lblPhotoStatus.Text = "No photo uploaded";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1630, 775);
            this.Controls.Add(this.lblPhotoStatus);
            this.Controls.Add(this.lblPublishDate);
            this.Controls.Add(this.lblBookAuthor);
            this.Controls.Add(this.lblBookDescription);
            this.Controls.Add(this.lblBookTitle);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lbBooks);
            this.Controls.Add(this.dtpPublishDate);
            this.Controls.Add(this.tbxAuthor);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAddPhoto);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}