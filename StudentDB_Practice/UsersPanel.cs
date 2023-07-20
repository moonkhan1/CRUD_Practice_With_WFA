using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace StudentDB_Practice
{
    public partial class UsersPanel : Form
    {

        public UsersPanel()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Surname", "Surname");
            dataGridView1.Columns.Add("DateOfBirth", "DateOfBirth");

            InitializeDataGrid();
            InitializeDatabase();
            CleanInputFields(textBox1, textBox2);

        }
        public static void InitializeDatabase()
            {
            string connectionString = @"Server=\\SQL;Database=Students;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True";
                try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Check if the database already exists
                        string checkDatabaseQuery = "SELECT COUNT(*) FROM sys.databases WHERE name = Students ";
                        using (var command = new SqlCommand(checkDatabaseQuery, connection))
                        {
                            int existingDatabaseCount = (int)command.ExecuteScalar();

                            if (existingDatabaseCount == 0)
                            {
                                // Database doesn't exist, create it
                                string createDatabaseQuery = "CREATE DATABASE Students";
                                using (var createCommand = new SqlCommand(createDatabaseQuery, connection))
                                {
                                    createCommand.ExecuteNonQuery();
                                }
                            connection.ChangeDatabase("Students");

                            // Create tblStudent table
                            string createTblStudentQuery = "CREATE TABLE tblStudent (Id INT PRIMARY KEY, Name VARCHAR(50), Surname VARCHAR(50), DateOfBirth DATE)";
                            using (var createTblStudentCommand = new SqlCommand(createTblStudentQuery, connection))
                            {
                                createTblStudentCommand.ExecuteNonQuery();
                            }

                            // Create tblCourse table
                            string createTblCourseQuery = "CREATE TABLE tblCourse (Id INT PRIMARY KEY, CourseName VARCHAR(100))";
                            using (var createTblCourseCommand = new SqlCommand(createTblCourseQuery, connection))
                            {
                                createTblCourseCommand.ExecuteNonQuery();
                            }

                            // Create tblStudentCourses table
                            string createTblStudentCoursesQuery = "CREATE TABLE tblStudentCourses (Id INT PRIMARY KEY, StudentId INT, CourseId INT, FOREIGN KEY (StudentId) REFERENCES tblStudent(Id), FOREIGN KEY (CourseId) REFERENCES tblCourse(Id))";
                            using (var createTblStudentCoursesCommand = new SqlCommand(createTblStudentCoursesQuery, connection))
                            {
                                createTblStudentCoursesCommand.ExecuteNonQuery();
                            }
                        }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database initialization failed: " + ex.Message);
                }
            }

        private void InitializeDataGrid()
        {
            dataGridView1.Rows.Clear();

            var students = GetAllStudentsFromSQLDB();

            students.ForEach(student =>
            {
                dataGridView1.Rows.Add(student.Id, student.Name, student.Surname, student.DateOfBirth);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectStudent();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectStudent();

        }
        private void AddStudent()
        {
            var name = textBox1.Text;
            var surname = textBox2.Text;
            var dateOfBirth = dateTimePicker1.Value;

            var connectionString = @"Server=DESKTOP-J45QUA4\SQL;Database=Students;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO dbo.tblStudent (Name, Surname, DateOfBirth) VALUES (@Name, @Surname, @DateOfBirth)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.ExecuteNonQuery();
                }
            }

            var dialogResult = MessageBox.Show("Student added.\r\nDo you want to close?", null,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                InitializeDataGrid();
                CleanInputFields(textBox1, textBox2);
            }

        }


        private DataGridViewRow? SelectStudent()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {

                    string name = row.Cells[1].Value.ToString();
                    string surname = row.Cells[2].Value.ToString();
                    DateTime date = Convert.ToDateTime(row.Cells[3].Value);

                    textBox1.Text = name;
                    textBox2.Text = surname;
                    dateTimePicker1.Value = date;
                    if (name != textBox1.Text || surname != textBox2.Text || date != dateTimePicker1.Value)
                    {
                        EditStudents();
                    }
                    return row;
                }
            }
            return null;
        }
        private List<Student> GetAllStudentsFromSQLDB()
        {
            var result = new List<Student>();

            var connectionString = @"Server=DESKTOP-J45QUA4\SQL;Database=Students;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT Id, Name, Surname, DateOfBirth FROM dbo.tblStudent";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Student()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"])
                            };
                            result.Add(student);
                        }
                    }
                }
                return result;
            }
        }

        private List<Course> GetCoursesFromSQLDB(int studentId)
        {
            var result = new List<Course>();

            var connection = new SqlConnection(@"Server=DESKTOP-J45QUA4\SQL;Database=Students;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True");

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT c.Name, c.CreationTime from dbo.tblStudent s JOIN tblStudentCourses sc ON sc.StudentId = s.Id JOIN tblCourse c ON c.Id = sc.CourseId WHERE s.Id =" + studentId;

            connection.Open();
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                var courseName = dataReader.GetString(0);
                var creationTime = dataReader.GetDateTime(1);

                var course = new Course
                {
                    CourseName = courseName,
                    CreationTime = creationTime
                };

                result.Add(course);
            }
            connection.Close();

            return result;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var studentId = int.Parse(textBox3.Text);
            var courses = GetCoursesFromSQLDB(studentId);

            if (courses.Any())
            {
                label3.Text = string.Join(", ", courses.Select(c => c.CourseName));
            }
            else
            {
                label3.Text = "No courses found";
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditStudents();
        }

        private void EditStudents()
        {
            string currentName = textBox1.Text;
            string currentSurname = textBox2.Text;
            DateTime currentDateOfBirth = dateTimePicker1.Value;

            string selectedStudentName = SelectStudent().Cells[1].Value.ToString();
            string selectedStudentSurname = SelectStudent().Cells[2].Value.ToString();
            DateTime selectedDateOfBirth = Convert.ToDateTime(SelectStudent().Cells[3].Value);

            var connectionString = @"Server=DESKTOP-J45QUA4\SQL;Database=Students;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "UPDATE dbo.tblStudent SET Name = @Name, Surname = @Surname, DateOfBirth = @DateOfBirth WHERE Name = @CurrentName AND Surname = @CurrentSurname AND DateOfBirth = @CurrentDateOfBirth";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", currentName);
                    command.Parameters.AddWithValue("@Surname", currentSurname);
                    command.Parameters.AddWithValue("@DateOfBirth", currentDateOfBirth);
                    command.Parameters.AddWithValue("@CurrentName", selectedStudentName);
                    command.Parameters.AddWithValue("@CurrentSurname", selectedStudentSurname);
                    command.Parameters.AddWithValue("@CurrentDateOfBirth", selectedDateOfBirth);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student data updated.");
                        InitializeDataGrid();
                        CleanInputFields(textBox1, textBox2);
                    }
                    else
                    {
                        MessageBox.Show("No matching student found to update.");
                        InitializeDataGrid();
                        CleanInputFields(textBox1, textBox2);
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void DeleteStudent()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int studentId = Convert.ToInt32(SelectStudent().Cells[0].Value);
                var connectionString = @"Server=DESKTOP-J45QUA4\SQL;Database=Students;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "DELETE FROM dbo.tblStudent WHERE Id = @StudentId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        var dialogResult = MessageBox.Show("\r\nDo you want to delete student?", null,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                        if (dialogResult == DialogResult.Yes)
                        {
                            command.Parameters.AddWithValue("@StudentId", studentId);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Student record deleted.");
                                InitializeDataGrid();
                                CleanInputFields(textBox1, textBox2);
                            }
                            else
                            {
                                MessageBox.Show("No matching student record found to delete.");
                                InitializeDataGrid();
                                CleanInputFields(textBox1, textBox2);
                            }
                        }
                        else
                        {
                            InitializeDataGrid();
                            CleanInputFields(textBox1, textBox2);
                        }
                        

                        
                    }
                }
            }
        }

        private void CleanInputFields(params TextBox[] Boxes)
        {
            Boxes.ToList().ForEach(u => u.Text = String.Empty);
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Salary { get; set; }
    }

    public class Course
    {
        public string CourseName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
