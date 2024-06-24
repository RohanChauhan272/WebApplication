using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebAppPort.Data.IRepository;
using WebAppPort.Entities.MainModel;

namespace WebAppPort.Data.Repository
{
    public class MainRepo : IMainRepo
    {
        private readonly string _connectionString;

        public MainRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public MainModel GetMainData()
        {
            try
            {
                List<Main> users = new List<Main>();
                List<Project> Project = new List<Project>();
                MainModel mainData = new MainModel();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Main user = new Main
                                {
                                    IndustryTitle = reader["IndustryTitle"].ToString(),
                                    ImageName = reader["ImageName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    ImageData = (byte[])reader["ImageData"]
                                    // Populate other properties as needed
                                };

                                users.Add(user);
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesProjectData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Project user = new Project
                                {
                                    ProjectTitle = reader["ProjectTitle"].ToString(),
                                    ProjectImageName = reader["ProjectImageName"].ToString(),
                                    ProjectDescription = reader["ProjectDescription"].ToString(),
                                    ProjectImageData = (byte[])reader["ProjectImageData"]
                                    // Populate other properties as needed
                                };

                                Project.Add(user);
                            }
                        }
                    }
                }

                mainData = new MainModel { mainModels = users, projects = Project };

                return mainData;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }


        public MainAboutModel GetAboutMainData()
        {
            try
            {
                List<About> users = new List<About>();
                List<About> aboutDet = new List<About>();
                List<Team> teams = new List<Team>();
                MainAboutModel mainData = new MainAboutModel();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesAboutData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                About user = new About
                                {
                                    AboutTitle = reader["AboutTitle"].ToString(),
                                    AboutImageName = reader["AboutImageName"].ToString(),
                                    AboutDescription = reader["AboutDescription"].ToString(),
                                    AboutImageData = (byte[])reader["AboutImageData"]
                                    // Populate other properties as needed
                                };

                                users.Add(user);
                            }
                            
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesAboutDetData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                About user = new About
                                {
                                    AboutTitle = reader["AboutTitle"].ToString(),
                                    AboutDescription = reader["AboutDescription"].ToString()
                                };

                                aboutDet.Add(user);
                            }

                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesTeamData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Team user = new Team
                                {
                                    TeamName = reader["TeamName"].ToString(),
                                    TeamPosition = reader["TeamPosition"].ToString()
                                };

                                teams.Add(user);
                            }

                        }
                    }
                }

                mainData = new MainAboutModel { about = users, aboutdet = aboutDet,TeamDet=teams };

                return mainData;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public MainServiceModel GetServiceMainData()
        {
            try
            {
                List<Service> users = new List<Service>();
                MainServiceModel mainData = new MainServiceModel();


                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesServiceData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Service user = new Service
                                {
                                    ServiceTitle = reader["ServiceTitle"].ToString(),
                                    ServiceDescription = reader["ServiceDescription"].ToString()
                                };

                                users.Add(user);
                            }

                        }
                    }
                }

                mainData = new MainServiceModel { mainService = users };

                return mainData;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public void SaveImageToDatabase(string imageName, byte[] imageData)
        {
            string connectionString = _connectionString; // Replace with your actual SQL Server connection string
            string insertSql = "INSERT INTO IndustriesAboutMst (AboutImageName, AboutImageData) VALUES (@ImageName, @ImageData)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertSql, connection))
                {
                    cmd.Parameters.AddWithValue("@ImageName", imageName);
                    cmd.Parameters.AddWithValue("@ImageData", imageData);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public ContactDet GetContactData()
        {
            try
            {
                ContactDetail user = new ContactDetail();
                ContactDet mainData = new ContactDet();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "sp_getIndustriesContactData"; // Name of your stored procedure

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user = new ContactDetail
                                {
                                    Name = reader["Name"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Website = reader["Website"].ToString()
                                    // Populate other properties as needed
                                };
                                mainData = new ContactDet { contactDetail = user };

                                return mainData;
                            }

                        }
                    }
                    return mainData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
