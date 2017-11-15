using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleeteInvoicing.Entities
{
    public class Expanded
    {
        public string CUSTID { get; set; }

        [Display(Name = "CORP CD")]
        public string CORP_CD { get; set; }

        [Display(Name = "CNTC NO")]
        public string CNTC_NO { get; set; }

        [Display(Name = "ADDRESS 1")]
        public string ADDRESS1 { get; set; }

        [Display(Name = "ADDRESS 2")]
        public string ADDRESS2 { get; set; }

        [Display(Name = "ADDRESS 3")]
        public string ADDRESS3 { get; set; }

        public string CITY { get; set; }

        public string STATE { get; set; }

        public string ZIP { get; set; }

        [Display(Name = "CUSTUMER")]
        public string CUSTNAME { get; set; }

        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Display(Name = "PAYMENT METHOD TYPE")]
        public string PAYMENT_METHOD_TYPE { get; set; }
    }
}