using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Manual_02_Task6
{
    internal class Program
    {
        static void LoadUsersFromFile(MUser[] users, ref int count)
        {
            string path = "users.txt";

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');

                    users[count] = new MUser();
                    users[count].username = parts[0];
                    users[count].password = parts[1];
                    users[count].role = parts[2];

                    count++;
                }
            }
        }
        static void Main(string[] args)
        {
            MUser[] users = new MUser[100];
            int count = 0;

            LoadUsersFromFile(users, ref count);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(users[i].username + " - " + users[i].role);
            }
        }
    }
}
