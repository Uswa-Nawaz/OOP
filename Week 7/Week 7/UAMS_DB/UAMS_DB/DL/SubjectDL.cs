using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_DB.BL;
using Microsoft.Data.SqlClient;
using System.Net.Http.Headers;

namespace UAMS_DB.DL
{
    internal class SubjectDL
    {

        //connection string 
        public static string connectionString = @"Server=.\SQLEXPRESS;Database=UMS;Trusted_Connection=True;TrustServerCertificate=True;";

        //static list to store all subjects
        private static List<Subject> subjectList=new List<Subject>();


        // CRUD's Create
        //method to add subject to the static list (applying database here)
        public static void addSubjectIntoList(Subject s)
        {
            //creating query
            string query = "INSERT INTO Subjects(SubjectCode, SubjectType, CreditHours, SubjectFee) VALUES(@Code, @Type, @CH, @Fee)";

            //using block used so it closes connection automatically if  there is an error
            using(SqlConnection  connection=new SqlConnection(connectionString))
            {
                //creating command object
                SqlCommand command=new SqlCommand(query, connection);
                //link @ to actual data
                command.Parameters.AddWithValue("@Code", s.getcode());
                command.Parameters.AddWithValue("@Type", s.getType());
                command.Parameters.AddWithValue("@CH", s.getcredithours());
                command.Parameters.AddWithValue("@Fee", s.getsubjectfee());
                //open connection and run command
                connection.Open();
                command.ExecuteNonQuery();

            }
            //keeping this
            subjectList.Add(s);
        }


        //CRUD's read
        //method to load the data , this fetch all subjects fom sql and put in list as program starts
        public static void loadSubjectsFromDB()
        {
            string query = "SELECT * FROM Subjects";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // SqlDataReader is used to READ data from the database
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Extract data from each column
                    string code = reader["SubjectCode"].ToString();
                    string type = reader["SubjectType"].ToString();
                    int ch = Convert.ToInt32(reader["CreditHours"]);
                    int fee = Convert.ToInt32(reader["SubjectFee"]);

                    // Create a new Subject object and add it to our list
                    Subject s = new Subject(code, type, ch, fee);
                    subjectList.Add(s);
                }
            }
        }



        //getter for the subject list
        public static List<Subject> getSubjectList()
        {
            return subjectList;
        }

        //method to search from this list
        public static Subject isSubjectExists(string type)
        {
            foreach (Subject subj in subjectList)
            { 
                if(subj.getType()==type)
                {
                    return subj;
                }
            }
            return null;
        }


    }
}
