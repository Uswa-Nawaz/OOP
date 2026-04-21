using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Challenge_03.BL;

namespace Challenge_03.DL
{
    internal class DegreeProgramDL
    {
        // list to store all degree programs
        private static List<DegreeProgram> programList = new List<DegreeProgram>();

        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }

        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach (DegreeProgram d in programList)
            {
                if (d.Degreename() == degreeName)
                {
                    return d;
                }
            }
            return null;
        }
        public static List<DegreeProgram> getProgramList()
        {
            return programList;
        }
    }
}
