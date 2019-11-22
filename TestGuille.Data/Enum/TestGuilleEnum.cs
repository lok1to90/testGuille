using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGuille.Data.Enum
{
        public enum StatusEnum
        {
            A,
            R,
            D
        }

        public enum StatusCvsEnum
        {
            Approved,
            Failed,
            Finished
        }

        public enum StatusXmlEnum
        {
            Approved,
            Rejected,
            Done
        }

    public enum FormatTypeEnum
        {
            CSV,
            XML,
            OTHER
        }
}
