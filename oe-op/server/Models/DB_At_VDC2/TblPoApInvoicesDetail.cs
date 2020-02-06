using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_APInvoicesDetail", Schema = "dbo")]
  public partial class TblPoApInvoicesDetail
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
    public int? Inventory_FK
    {
      get;
      set;
    }
    public TblIcInventory TblIcInventory { get; set; }
    public int? Unit_FK
    {
      get;
      set;
    }
    public TblIcUnit TblIcUnit { get; set; }
    public decimal? Unit_Price
    {
      get;
      set;
    }
    public double? Qty_Ordered
    {
      get;
      set;
    }
  }
}
