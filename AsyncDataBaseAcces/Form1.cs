using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Configuration;
using AsyncDataBaseAcces.Models;


namespace AsyncDataBaseAcces
{
    public partial class Form1 : Form
    {
        List<Book> books;
        string connectionString = "";
        DbConnection connection = null;
        DbProviderFactory factory= null;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            books = new List<Book>();   
            string providerName = "System.Data.SqlClient";
            factory = DbProviderFactories.GetFactory(providerName);
            connection = factory.CreateConnection();
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if(settings != null)
            {
                foreach(ConnectionStringSettings css in settings)
                {
                    if(css.ProviderName == providerName)
                    {
                        connectionString = css.ConnectionString;
                    }
                }
            }

            if(connectionString == null)
            {
                MessageBox.Show("Connection string not find!");
            }

            execute_button.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Your transaction is running...";
            count++;
        }

        private void sqlTransactionField_TextChanged(object sender, EventArgs e)
        {
            if (sqlTransactionField.Text.Length > 3)
            {
                execute_button.Enabled= true;
            }
            else
            {
                execute_button.Enabled= false;
            }
        }


        
        private async void execute_button_Click(object sender, EventArgs e)
        {
            authors_comboBox.Items.Clear();
            execute_button.Enabled = false;
            clean_button.Enabled = false;
            try
            {
                connection.ConnectionString = connectionString;
                await connection.OpenAsync();
                label1.Text = "Your transaction is proccesing";
                timer1.Start();
                
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"WAITFOR DELAY '00:00:2'; {sqlTransactionField.Text}";
                DataTable table = new DataTable();
                books.Clear();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    int line = 0;
                    do
                    {
                        while (await reader.ReadAsync())
                        {
                            if (line == 0)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    table.Columns.Add(reader.GetName(i));

                                }

                                line++;
                            }
                            DataRow row = table.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = await reader.GetFieldValueAsync<object>(i);
                                
                            }
                            Book book = new Book() { Id = int.Parse(row[0].ToString()), Name = row[1].ToString(),AuthorId = int.Parse(row[2].ToString()) };
                            Console.WriteLine(book.Name);
                            books.Add(book);
                            table.Rows.Add(row);
                        }
                    }
                     while (reader.NextResult()) ;
                    reader.Close();

                    if (sqlTransactionField.Text == "select * from books")
                    {
                        List<Author> authors = new List<Author>();
                        command.CommandText = $"select [Id], [AuthorName] from Authors";
                        DataTable new_table = new DataTable();
                        using (DbDataReader new_reader = await command.ExecuteReaderAsync())
                        {
                            while (new_reader.Read())
                            {
                                Author author = new Author() { Name = new_reader.GetString(1), Id = (int)new_reader.GetValue(0) };
                                authors.Add(author);
                            }
                        }
                        if (authors.Count > 0)
                        {
                            for (int i = 0; i < authors.Count; i++)
                            {
                                {
                                    int booksCount = 0;
                                    foreach (Book book in books)
                                    {
                                        if (book.AuthorId == authors[i].Id)
                                            booksCount++;
                                    }
                                    authors[i].BooksCount = booksCount;
                                }
                            }
                            foreach (Author author in authors)
                            {
                                authors_comboBox.Items.Add(author);
                            }
                            authors_comboBox.SelectedIndex = 0;
                            authors_comboBox.DisplayMember = "Name";

                        }
                    }
                    dataViewer.DataSource = null;
                    dataViewer.DataSource = table;
                    label1.Text = "Sql-Transaction:";
                    
                }
            }
            finally
            {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
                if (timer1.Enabled)
                    timer1.Stop();
                count = 0;
                clean_button.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            books_count.Value = 0;
            if (authors_comboBox.SelectedIndex != -1)
            {
                books_count.Value = ((Author)authors_comboBox.SelectedItem).BooksCount;
            }
        }
    }
}
