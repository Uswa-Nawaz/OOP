using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    internal class Subject
    {
        public string SubjCode; // unique code to identify the subject
        public int CRH;  // credit hours of subj
        public string SubjType;  // like  core, elective
        public float SubjFee; // fee charged for this subject

        // parameterized constructor to set subject info
        public Subject(string SubjCode, int CRH, string SubjType, float SubjFee)
        {
            this.SubjCode = SubjCode;
            this.CRH = CRH;
            this.SubjType = SubjType;
            this.SubjFee = SubjFee;

        }
    }
}
