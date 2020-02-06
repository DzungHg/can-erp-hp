using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_CashDisbursement", Schema = "dbo")]
  public partial class TblPoCashDisbursement
  {
    [Key]
    public string PO_CashDisb_No
    {
      get;
      set;
    }
    public DateTime? PO_CashDisb_Date
    {
      get;
      set;
    }
    public int? Customer_FK
    {
      get;
      set;
    }
    public TblGnAddressBook TblGnAddressBook { get; set; }
    public string Description
    {
      get;
      set;
    }
    public string Disbursement_Type
    {
      get;
      set;
    }
    public decimal? Gross_Invt_Amt
    {
      get;
      set;
    }
    public decimal? Discount_Invt_Amt
    {
      get;
      set;
    }
    public string Check_No
    {
      get;
      set;
    }
    public DateTime? Check_Date
    {
      get;
      set;
    }
    public decimal? Check_Amount
    {
      get;
      set;
    }
    public string DebiAccount
    {
      get;
      set;
    }
    public string CreditAccount
    {
      get;
      set;
    }
    public bool? Payment
    {
      get;
      set;
    }
  }
}
