using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Models.ViewModels
{
    public class SalesRecordFormViewModel
    {
        public SalesRecord SalesRecord { get; set; }

        public IEnumerable<Seller> Sellers { get; set; }

    }
}
