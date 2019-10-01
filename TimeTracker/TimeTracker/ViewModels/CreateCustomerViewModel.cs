using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracker.ViewModels
{
    public class CreateCustomerViewModel
    {
        public int ClientID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyPOC { get; set; }
    }
}
