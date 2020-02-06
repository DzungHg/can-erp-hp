using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblSO_Customer", Schema = "dbo")]
  public partial class TblSoCustomer
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Customer_SEQ
    {
      get;
      set;
    }


    public ICollection<TblSoSalesOrder> TblSoSalesOrders { get; set; }
    public string Customer_ID
    {
      get;
      set;
    }
    public string LastName
    {
      get;
      set;
    }
    public string FirstName
    {
      get;
      set;
    }
    public int? CustomerAdressBook_FK
    {
      get;
      set;
    }
    public TblGnAddressBook TblGnAddressBook { get; set; }
    public decimal? CreditLimit
    {
      get;
      set;
    }
    public DateTime? LastRevisedCreditLimitDate
    {
      get;
      set;
    }
    public int? PaymentTerm_FK
    {
      get;
      set;
    }
    public TblGnPaymentTerm TblGnPaymentTerm { get; set; }
    public int? PaymentType_FK
    {
      get;
      set;
    }
    public TblGnPaymentType TblGnPaymentType { get; set; }
    public int? DiscountPercent
    {
      get;
      set;
    }
    public decimal? Current_MTD_Sales
    {
      get;
      set;
    }
    public decimal? Current_MTD_Returns
    {
      get;
      set;
    }
    public decimal? YTD_GrossSales
    {
      get;
      set;
    }
    public decimal? YTD_Returns
    {
      get;
      set;
    }
    public decimal? YTD_COGS
    {
      get;
      set;
    }
    public decimal? LYR_GrossSales
    {
      get;
      set;
    }
    public decimal? LYR_COGS
    {
      get;
      set;
    }
    public decimal? LastAmountSales
    {
      get;
      set;
    }
    public int? SalesPersonAdressBook_FK
    {
      get;
      set;
    }
    public decimal? CommissionPercent
    {
      get;
      set;
    }
    public decimal? SalesPerson_MTD_Goal
    {
      get;
      set;
    }
    public decimal? SalesPerson_YTD_Goal
    {
      get;
      set;
    }
    public bool? ChargeInterest
    {
      get;
      set;
    }
    public bool? Statement
    {
      get;
      set;
    }
    public decimal? Aging30DayAmout
    {
      get;
      set;
    }
    public decimal? Aging60DayAmout
    {
      get;
      set;
    }
    public decimal? Aging90DayAmout
    {
      get;
      set;
    }
    public string Notes
    {
      get;
      set;
    }
    public DateTime? LastUpdatedDate
    {
      get;
      set;
    }
    public int? LastUdpatedBy
    {
      get;
      set;
    }
    public bool? Inactive
    {
      get;
      set;
    }
  }
}
