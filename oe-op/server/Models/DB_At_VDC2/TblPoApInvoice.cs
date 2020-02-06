using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_APInvoice", Schema = "dbo")]
  public partial class TblPoApInvoice
  {
    [Key]
    public string Vendor_ID
    {
      get;
      set;
    }
    public TblPoVendor TblPoVendor { get; set; }
    [Key]
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
    public string PO_ID
    {
      get;
      set;
    }
    public DateTime? PO_Date
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public decimal? Invoice_Amount
    {
      get;
      set;
    }
    public decimal? Discount_Amount
    {
      get;
      set;
    }
    public DateTime? Due_Date
    {
      get;
      set;
    }
    public bool? Paid
    {
      get;
      set;
    }
  }
}
