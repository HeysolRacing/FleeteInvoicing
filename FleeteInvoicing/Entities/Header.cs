using System;
using System.ComponentModel.DataAnnotations;

namespace FleeteInvoicing.Entities
{
    public class Header
    {
        public string CFDUniqueID { get; set; }
        public string registryType { get; set; }

        [Display(Name = "SERIE")]
        public string headerSeries { get; set; }

        [Display(Name = "FOLIO")]
        public string headerFolio { get; set; }

        [Display(Name = "FECHA FOLIO")]
        public Nullable<System.DateTime> headerDate { get; set; }

        [Display(Name = "SUBTOTAL")]
        public Nullable<decimal> headerSubtotal { get; set; }

        [Display(Name = "TOTAL")]
        public Nullable<decimal> headerTotal { get; set; }

        [Display(Name = "IMPUESTOS")]
        public Nullable<decimal> headerTaxes { get; set; }

        [Display(Name = "IMPUESTOS 2")]
        public Nullable<decimal> headerTaxes2 { get; set; }

        [Display(Name = "DESCUENTO")]
        public Nullable<decimal> headerDiscount { get; set; }

        [Display(Name = "DESC DESCUENTO")]
        public string headerDiscountExplanation { get; set; }

        [Display(Name = "CANTIDAD")]
        public string headerAmountLegend { get; set; }

        [Display(Name = "MONEDA")]
        public string headerCurrency { get; set; }

        [Display(Name = "TIPO CAMBIO")]
        public Nullable<decimal> headerExchangeRate { get; set; }

        [Display(Name = "REFERENCIA")]
        public string headerReference { get; set; }

        [Display(Name = "OBSERVACION 1")]
        public string headerObs1 { get; set; }

        [Display(Name = "OBSERVACION 2")]
        public string headerObs2 { get; set; }

        [Display(Name = "OBSERVACION 3")]
        [DataType(DataType.MultilineText)]
        public string headerObs3 { get; set; }

        [Display(Name = "FLOTA")]
        public string headerFleet { get; set; }

        [Display(Name = "DIVISION")]
        public string headerDivision { get; set; }

        [Display(Name = "CREDITO/DEBITO")]
        public string headerCreditDebitInd { get; set; }

        [Display(Name = "CORP CD")]
        public string headerCorpCd { get; set; }

        public string headerInvTypeInd { get; set; }
        public string headerDocumentType { get; set; }
        public string headerPaymentMethodType { get; set; }
        public string headerZipCode { get; set; }
        public string headerConfirmation { get; set; }
        public string headerPaymentMethod { get; set; }
        public string headerPaymentConditions { get; set; }

        [Display(Name = "UUID")]
        public string headerUUID { get; set; }

        [Display(Name = "COMENTARIOS")]
        public string headerComments { get; set; }

        public string headerParentSeries { get; set; }
        public string headerParentFolio { get; set; }

        [Display(Name = "TIPO")]
        public string headerPeriodicity { get; set; }
        public string headerTralixStatus { get; set; }
        public string headerInternalStatus { get; set; }
        public Nullable<System.DateTime> headerTralixStatusDate { get; set; }


    }
}