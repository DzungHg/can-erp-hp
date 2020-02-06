using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_AccountsPayableAdjustments", Schema = "dbo")]
  public partial class TblPoAccountsPayableAdjustment
  {
    [Key]
    public string Voucher_No
    {
      get;
      set;
    }
    public DateTime? Voucher_Date
    {
      get;
      set;
    }
    public string Vendor_FK
    {
      get;
      set;
    }
    public string Transact_ID
    {
      get;
      set;
    }
    public string Record_Code
    {
      get;
      set;
    }
    public string PO_No
    {
      get;
      set;
    }
    public string Invoice_No
    {
      get;
      set;
    }
    public DateTime? Invoice_Date
    {
      get;
      set;
    }
    public string Debit_Account
    {
      get;
      set;
    }
    public string Credit_Account
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public decimal? Amount
    {
      get;
      set;
    }
    public int? Authorize_By
    {
      get;
      set;
    }
  }
}
