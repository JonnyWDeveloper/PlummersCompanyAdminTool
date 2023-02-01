using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlummerCompany
{
    class RealEstate
    {
        /// <summary>
        /// Type is the type of real estate, e.g. apartmenthouse, townhouse association, 
        /// housing society, etc.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///Code is the code for a Title Deed, Cadastral: Real Property, Apartment Designation, Address, etc.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Date is the time when the work was done.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Work is the work done for the real estate owner.
        /// </summary>
        public string Work { get; set; }
    }
}
