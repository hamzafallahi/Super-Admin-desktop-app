using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;
using MySql.Data.MySqlClient;

using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using FontAwesome.Sharp;
namespace PFA_Front
{
    class admin
    {

        DBconnect connect = new DBconnect();
        //public string Email;
        public bool insertAdmin(string fname, string lname, string email, string password, string phone, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `admin` (`name`, `lname`, `email`, `password`, `number`, `photo`) VALUES (@1, @2, @3, @4, @5, @7)", connect.con);
            command.Parameters.AddWithValue("@1", fname);
            command.Parameters.AddWithValue("@2", lname);
            command.Parameters.AddWithValue("@3", email);
            command.Parameters.AddWithValue("@4", password);
            command.Parameters.AddWithValue("@5", phone);
            command.Parameters.AddWithValue("@7", img);

            connect.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnection();
                return true;
            }
            else
            {
                connect.closeConnection();
                return false;
            }
        }

        public void UpdateUser(int id, string originalemail, string fname, string lname, string phone,string email, byte[] img)
        {
            if (!IsEmailAvailable(email, originalemail,"users"))
            {
                MessageBox.Show("Email already exists or wrong format, so update cannot be performed", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            StringBuilder queryBuilder = new StringBuilder("UPDATE `users` SET ");
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(fname))
            {
                queryBuilder.Append("`firstname` = @fname, ");
                parameters.Add(new MySqlParameter("@fname", fname));
            }
            if (!string.IsNullOrEmpty(lname))
            {
                queryBuilder.Append("`lastname` = @lname, ");
                parameters.Add(new MySqlParameter("@lname", lname));
            }
            if (!string.IsNullOrEmpty(email))
            {
                queryBuilder.Append("`email` = @email, ");
                parameters.Add(new MySqlParameter("@email", email));
            }
            
            if (!string.IsNullOrEmpty(phone))
            {
                queryBuilder.Append("`phone` = @phone, ");
                parameters.Add(new MySqlParameter("@phone", phone));
            }
            if (!(img ==null))
            {
                queryBuilder.Append("`img` = @img, ");
                parameters.Add(new MySqlParameter("@img", img));
            }

            // Remove the trailing comma and space
            queryBuilder.Remove(queryBuilder.Length - 2, 2);

            // Add the WHERE clause
            queryBuilder.Append(" WHERE `id` LIKE @id");

            // Add the original email parameter
            parameters.Add(new MySqlParameter("@id", id));

            // Create and execute the command
            MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connect.con);
            command.Parameters.AddRange(parameters.ToArray());

            connect.openConnection();
            command.ExecuteNonQuery();
            connect.closeConnection();
            MessageBox.Show("user updated succesfully", "admin", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        
    }
        public void UpdateAdmins(string fname, string lname,  string phone, string originalemail, string email = "")
        {
            // Check if the new email already exists in the database

            if (!IsEmailAvailable(email, originalemail, "admin"))
            {
                MessageBox.Show("Email already exists or wrong format, so update cannot be performed", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Email already exists, so update cannot be performed
                return ;
            }
      


                // Build the UPDATE query based on non-empty variables
                StringBuilder queryBuilder = new StringBuilder("UPDATE `admin` SET ");
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(fname))
                {
                    queryBuilder.Append("`name` = @fname, ");
                    parameters.Add(new MySqlParameter("@fname", fname));
                }
                if (!string.IsNullOrEmpty(lname))
                {
                    queryBuilder.Append("`lname` = @lname, ");
                    parameters.Add(new MySqlParameter("@lname", lname));
                }
                if (!string.IsNullOrEmpty(email))
                {
                    queryBuilder.Append("`email` = @email, ");
                    parameters.Add(new MySqlParameter("@email", email));
                }

                if (!string.IsNullOrEmpty(phone))
                {
                    queryBuilder.Append("`number` = @phone, ");
                    parameters.Add(new MySqlParameter("@phone", phone));
                }


                // Remove the trailing comma and space
                queryBuilder.Remove(queryBuilder.Length - 2, 2);

                // Add the WHERE clause
                queryBuilder.Append(" WHERE `email` LIKE @originalemail");

                // Add the original email parameter
                parameters.Add(new MySqlParameter("@originalemail", originalemail));

                // Create and execute the command
                MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connect.con);
                command.Parameters.AddRange(parameters.ToArray());

                connect.openConnection();
                command.ExecuteNonQuery();
                connect.closeConnection();
                MessageBox.Show("admin updated succesfully", "admin", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return ;
            
        }
        public string UpdateAdmin(string fname, string lname, string password, string phone, string originalemail, byte[] img, string email = "")
        {
            // Check if the new email already exists in the database
  
                if (!IsEmailAvailable(email, originalemail,"super admin"))
                {
                MessageBox.Show("Email already exists or wrong format, so update cannot be performed", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Email already exists, so update cannot be performed
                return originalemail;
            }
            else { 
    

            // Build the UPDATE query based on non-empty variables
            StringBuilder queryBuilder = new StringBuilder("UPDATE `super admin` SET ");
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(fname))
            {
                queryBuilder.Append("`name` = @fname, ");
                parameters.Add(new MySqlParameter("@fname", fname));
            }
            if (!string.IsNullOrEmpty(lname))
            {
                queryBuilder.Append("`lname` = @lname, ");
                parameters.Add(new MySqlParameter("@lname", lname));
            }
                if (!string.IsNullOrEmpty(email))
                {
                    queryBuilder.Append("`email` = @email, ");
                    parameters.Add(new MySqlParameter("@email", email));
                }
                if (!string.IsNullOrEmpty(password))
            {
                queryBuilder.Append("`password` = @password, ");
                parameters.Add(new MySqlParameter("@password", password));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                queryBuilder.Append("`number` = @phone, ");
                parameters.Add(new MySqlParameter("@phone", phone));
            }
                if (!(img == null))
                {
                    queryBuilder.Append("`photo` = @img, ");
                    parameters.Add(new MySqlParameter("@img", img));
                }

                // Remove the trailing comma and space
                queryBuilder.Remove(queryBuilder.Length - 2, 2);

            // Add the WHERE clause
            queryBuilder.Append(" WHERE `email` LIKE @originalemail");

            // Add the original email parameter
            parameters.Add(new MySqlParameter("@originalemail", originalemail));

            // Create and execute the command
            MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connect.con);
            command.Parameters.AddRange(parameters.ToArray());

            connect.openConnection();
            command.ExecuteNonQuery();
            connect.closeConnection();
            MessageBox.Show("admin updated succesfully", "admin", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return email;
            }
        }

        // Check if the new email is available (not already in use)
        private bool IsEmailAvailable(string newEmail, string originalEmail,string table)
        {
            if (newEmail == originalEmail)
            {
                return true; // Email is the same, so it's available
            }

            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) FROM `{table}` WHERE `email` = @email", connect.con);
            command.Parameters.AddWithValue("@email", newEmail);
            //command.Parameters.AddWithValue("@table", table);

            connect.openConnection();
            long count = (long)command.ExecuteScalar();
            connect.closeConnection();

            return count == 0; // Email is available if count is zero
        }



        public MySqlCommand GetCurrentInfo(string email)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT name, lname, email, number,photo FROM `super admin` WHERE email LIKE @email", connect.con))
            {
                command.Parameters.AddWithValue("@email", email);
                connect.openConnection();
                return command; // Return the command object without executing it yet
            }
        }
        public int LoginAdmin(string email, string password)
        {
            MySqlCommand command = new MySqlCommand("SELECT `id` FROM `super admin` WHERE `email` = @Email AND `password` = @Password", connect.con);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);

            connect.openConnection(); // Corrected method name to OpenConnection from openConnection

            MySqlDataReader reader = command.ExecuteReader(); // Execute the query and get the reader

            if (reader.Read()) // Check if any rows are returned
            {
                int adminId = reader.GetInt32("id"); // Get the value of 'id' column as an int
                reader.Close(); // Close the reader when done
                connect.closeConnection(); // Corrected method name to CloseConnection from closeConnection
                return adminId;
            }
            else
            {
                reader.Close(); // Close the reader when no rows are returned
                connect.closeConnection(); // Corrected method name to CloseConnection from closeConnection
                return -1; // Return -1 if no matching admin is found
            }
        }
        public DataTable getstudentslist(string srch = "")
        {
            using (MySqlCommand command = new MySqlCommand("SELECT id,firstname, lastname,email,phone,img FROM `users` WHERE role LIKE '%student%' AND (firstname LIKE @searchTerm OR lastname LIKE @searchTerm)", connect.con))
            {
                command.Parameters.AddWithValue("@searchTerm", $"%{srch}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        public DataTable getsubstudentslist(int searchTerm)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT users.id,users.firstname, users.lastname,users.email,users.phone,users.img FROM `users`,`courses`,`enrollments` WHERE courses.id=enrollments.courseID AND enrollments.UserID=users.id AND courses.id=@searchTerm", connect.con))
            {
                command.Parameters.AddWithValue("@searchTerm", searchTerm);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }



        public DataTable getadminlist()
        {
            using (MySqlCommand command = new MySqlCommand("SELECT id,email,name,lname,number,photo FROM `admin`", connect.con))
            {
                //command.Parameters.AddWithValue("@searchTerm", $"%{srch}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }


        // Function to get instructor list with search term
        public DataTable getstinstructorlist(string srch = "")
        {
            using (MySqlCommand command = new MySqlCommand("SELECT id,firstname, lastname,email,phone,img FROM `users` WHERE role LIKE '%instructor%' AND (firstname LIKE @searchTerm OR lastname LIKE @searchTerm)", connect.con))
            {
                command.Parameters.AddWithValue("@searchTerm", $"%{srch}%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }
        public void deleteUser(int id)
        {


            using (MySqlCommand command = new MySqlCommand("DELETE FROM users WHERE id = @id", connect.con))
            {
                command.Parameters.AddWithValue("@id", id);
                connect.openConnection();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("user deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
                connect.closeConnection();
            }
        }
        public void deleteAdmin(int id)
        {


            using (MySqlCommand command = new MySqlCommand("DELETE FROM admin WHERE id = @id", connect.con))
            {
                command.Parameters.AddWithValue("@id", id);
                connect.openConnection();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("user deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
                connect.closeConnection();
            }
        }
        public class CourseData
        {
            public int id { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public string description { get; set; }
            public string category { get; set; }
            public int courseprice { get; set; }
            public byte[] ImageData { get; set; }


        }
        public List<CourseData> RetrieveCourseDataFromDatabase(string srch="")
        {
            List<CourseData> courseDataList = new List<CourseData>();

            try
            {
                
                    
                    

                using (MySqlCommand command = new MySqlCommand("SELECT `id`,`title`, `subtitle`, `description`,  `category`, `courseprice`, `img` FROM `courses` WHERE title LIKE @searchTerm", connect.con))
                    {
                    command.Parameters.AddWithValue("@searchTerm", $"%{srch}%");
                    connect.openConnection(); 
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CourseData courseData = new CourseData();
                                courseData.id = (int)reader["id"];
                                courseData.Title = reader["title"].ToString();
                                Console.WriteLine("Retrieved title: " + courseData.Title);
                                courseData.Subtitle= reader["subtitle"].ToString();
                                courseData.description = reader["description"].ToString();
                                courseData.category = reader["category"].ToString();
                                courseData.courseprice = (int)reader["courseprice"];
                                courseData.ImageData = (byte[])reader["img"];

                                courseDataList.Add(courseData);
                            }
                        }
                    }
                 connect.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving course data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return courseDataList;
        }

        // Other code in your form...
    }


}

