﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.App.BillDetails
{
    public class TotalCategoryViewModel
    {
        public int CategoryId { get; set; }
        public decimal Money { get; set; }
        public string CategoryName { get; set; }
    }
}
