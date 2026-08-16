using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_DB.BL;

namespace UAMS_DB.DL
{
    internal class DegreeProgramDL
    {

        // connection of database
        public static string connectionString = @"Server=.\SQLEXPRESS;Database=UMS;Trusted_Connection=True;TrustServerCertificate=True;";

        //static list of all the degree program
        public static List<DegreeProgram> programList=new List<DegreeProgram>();


        //CRUD's Create
        //function to add a degree to the list (added database here)
        public static void addIntoDegreeList(DegreeProgram d)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string queryDegree = "INSERT INTO DegreePrograms(DegreeName, Duration, Seats) VALUES (@Name, @Dur, @Seats)";

                SqlCommand cmd1 = new SqlCommand(queryDegree, connection);

                cmd1.Parameters.AddWithValue("@Name", d.getDegreename());
                cmd1.Parameters.AddWithValue("@Dur", d.getDegreeduration());
                cmd1.Parameters.AddWithValue("@Seats", d.getseats());

                cmd1.ExecuteNonQuery();

                //insert link for each subject in this degree
                foreach (Subject s in d.getSubjects())
                {
                    string queryLink = "INSERT INTO DegreeSubjectLink (DegreeName, SubjectCode) VALUES (@DName, @SCode)";

                    SqlCommand cmd2 = new SqlCommand(queryLink, connection);
                    cmd2.Parameters.AddWithValue("@DName", d.getDegreename());
                    cmd2.Parameters.AddWithValue("@SCode", s.getcode());
                    cmd2.ExecuteNonQuery();
                }
            }

            programList.Add(d);
        }



        //CRUD's Read
        //method to load the data , this fetch all subjects fom sql and put in list as program starts
        public static void loadDegreesFromDB()
        {
            string query = "SELECT * FROM DegreePrograms";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["DegreeName"].ToString();
                    int duration = Convert.ToInt32(reader["Duration"]);
                    int seats = Convert.ToInt32(reader["Seats"]);

                    //degree object
                    DegreeProgram d = new DegreeProgram(name, duration, seats);

                    //Now, find all subjects linked to THIS specific degree
                    loadLinkedSubjects(d);

                    programList.Add(d);
                }
            }
        }

        //method that fill the subject list inside that degree
        private static void loadLinkedSubjects(DegreeProgram d)
        {
            //join th linked table with subject table
            string query = "SELECT s.SubjectCode, s.SubjectType, s.CreditHours, s.SubjectFee " +
                           "FROM Subjects s " +
                           "JOIN DegreeSubjectLink dsl " +
                           "ON s.SubjectCode = dsl.SubjectCode " +  //Only match rows where the Subject Code is the same.
                           "WHERE dsl.DegreeName = @DegreeName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DegreeName", d.getDegreename());
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string code = reader["SubjectCode"].ToString();
                    string type = reader["SubjectType"].ToString();
                    int ch = Convert.ToInt32(reader["CreditHours"]);
                    int fee = Convert.ToInt32(reader["SubjectFee"]);

                    Subject s = new Subject(code, type, ch, fee);
                    d.addsubjectToList(s); // Add it into the degree's own list
                }
            }
        }


        //search for the degree
        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach (DegreeProgram d in programList)
            {
                if (d.getDegreename() == degreeName)
                {
                    return d;
                }
            }
            return null;
        }

        //to get the list
        public static List<DegreeProgram> getProgramList()
        {
            return programList;
        }
    }
}
