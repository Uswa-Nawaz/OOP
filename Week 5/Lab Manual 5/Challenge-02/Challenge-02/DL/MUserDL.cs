using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_02.BL;

namespace Challenge_02.DL
{
    internal class MUserDL
    {
        private static List<MUserBL> usersList = new List<MUserBL>();

        public static void addUserIntoList(MUserBL user)
        {
            usersList.Add(user);
        }

        // The logic to verify a user during login
        public static MUserBL SignIn(MUserBL user)
        {
            foreach (MUserBL storedUser in usersList)
            {
                if (storedUser.getUsername() == user.getUsername() && storedUser.getPassword() == user.getPassword())
                {
                    return storedUser;
                }
            }
            return null;
        }
    }
}
