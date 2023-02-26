using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Money_Finder.Models;
using System;

namespace Money_Finder.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult adminlogin()
        //{
        //    using (SqlConnection sourceConnection = new SqlConnection("Data Source=SQL5061.site4now.net;Initial Catalog=db_a786af_sternsites;User Id=db_a786af_sternsites_admin;Password=lalamunir@20"))
        //    {
        //        sourceConnection.Open();

        //        // Connect to the target database
        //        using (SqlConnection targetConnection = new SqlConnection("Data Source=SQL5070.site4now.net;Initial Catalog=db_a81f4a_cosmotemplate;User Id=db_a81f4a_cosmotemplate_admin;Password=macodex@123"))
        //        {
        //            targetConnection.Open();

        //            // Query the source database
        //            using (SqlCommand sourceCommand = new SqlCommand("SELECT * FROM AdminLogin", sourceConnection))
        //            {
        //                // Execute the query
        //                using (SqlDataReader reader = sourceCommand.ExecuteReader())
        //                {
        //                    // Iterate over the results
        //                    while (reader.Read())
        //                    {
        //                        // Get the data from the source table
                              
        //                        string UserName = reader.GetString(1);
        //                        string Password = reader.GetString(2);
        //                        string Status = reader.GetString(3);
        //                        string Gmail = reader.GetString(4);
        //                        string SystemRoll = reader.GetString(5);
        //                        string Image = reader.GetString(6);
        //                        string SkypeAddress = reader.GetString(7);
        //                        string FirstName = reader.GetString(8);
        //                        string LastName  = reader.GetString(9);
        //                        string Contact  = reader.GetString(10);
        //                        string DateTime  = reader.GetString(11);
        //                        string TryCount  = reader.GetString(12);

        //                        // Insert the data into the target table
        //                        using (SqlCommand targetCommand = new SqlCommand("INSERT INTO AdminLogin (UserName,Password,Status,Gmail,SystemRoll,Image,SkypeAddress,FirstName,LastName,Contact,DateTime,TryCount) VALUES (@UserName,@Password,@Status,@Gmail,@SystemRoll,@Image,@SkypeAddress,@FirstName,@LastName,@Contact,@DateTime,@TryCount)", targetConnection))
        //                        {
                    
        //                            targetCommand.Parameters.AddWithValue("@UserName", UserName);
        //                            targetCommand.Parameters.AddWithValue("@Password", Password);
        //                            targetCommand.Parameters.AddWithValue("@Status", Status);
        //                            targetCommand.Parameters.AddWithValue("@Gmail", Gmail);
        //                            targetCommand.Parameters.AddWithValue("@SystemRoll", SystemRoll);
        //                            targetCommand.Parameters.AddWithValue("@Image", Image);
        //                            targetCommand.Parameters.AddWithValue("@SkypeAddress", SkypeAddress);
        //                            targetCommand.Parameters.AddWithValue("@FirstName", FirstName);
        //                            targetCommand.Parameters.AddWithValue("@LastName", LastName);
        //                            targetCommand.Parameters.AddWithValue("@Contact", Contact);
                                 
        //                            targetCommand.Parameters.AddWithValue("@DateTime", DateTime);
        //                            targetCommand.Parameters.AddWithValue("@TryCount", TryCount);

        //                            targetCommand.ExecuteNonQuery();
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return Ok();
        //}
        //}
        //}
        }
        }
    

