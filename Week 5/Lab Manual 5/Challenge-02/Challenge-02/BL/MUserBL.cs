using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.BL
{
    internal class MUserBL
    {
        private string username;
        private string password;
        private string role;

        // Constructors
        public MUserBL(string username, string password, string role)
        {
            setUsername(username);
            setPassword(password);
            setRole(role);
        }

        public MUserBL(string username, string password)
        {
            setUsername(username);
            setPassword(password);
            this.role = "Customer"; // Default role for sign-in
        }

        // Getters
        public string getUsername()
        {
            return username;
        }
        public string getPassword()
        {
            return password;
        }
        public string getRole()
        {
            return role;
        }

        // Setters with Validation Logic
        public void setUsername(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                username = name;
            }
            else
            {
                username = "Unknown_User";
            }
        }

        public void setPassword(string pass)
        {
            if (!string.IsNullOrEmpty(pass))
            {
                password = pass;
            }
            else
            {
                password = "Default_Password";
            }
        }

        public void setRole(string r)
        {
            // Logic: Only allow specific roles, otherwise default to Customer
            if (!string.IsNullOrEmpty(r) && (r.ToLower() == "admin" || r.ToLower() == "customer"))
            {
                role = r;
            }
            else
            {
                role = "Customer";
            }
        }

        // Logical Check
        public bool isAdmin()
        {
            return role != null && role.ToLower() == "admin";
        }
    }
}
