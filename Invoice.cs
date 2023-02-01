using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlummerCompany
{
    class Invoice
    {   /// <summary>
        /// Owner is an owner of real estate, RealEstate Class.)
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Address is the whole address of the real estate ownwer.
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Date is the time when the work was done.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Work is the work done for the real estate owner.
        /// </summary>
        public string Work{ get; set; }

        /// <summary>
        /// Cost is the amount to be charged to the real estate owner for the work done.
        /// </summary>
        public int Cost { get; set; }

    }
}
