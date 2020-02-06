using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblIC_Transaction", Schema = "dbo")]
  public partial class TblIcTransaction
  {
    [Key]
    public string Trans_No
    {
      get;
      set;
    }
    public string Trans_Code
    {
      get;
      set;
    }
    public TblIcTransactionType TblIcTransactionType { get; set; }
    public DateTime? Trans_Date
    {
      get;
      set;
    }
    public string Warehouse_ID
    {
      get;
      set;
    }
    public TblIcWarehouse TblIcWarehouse { get; set; }
    public int? Item_FK
    {
      get;
      set;
    }
    public TblGnProduct TblGnProduct { get; set; }
    public string Reference_No
    {
      get;
      set;
    }
    public DateTime? Reference_Date
    {
      get;
      set;
    }
    public bool? Taxable
    {
      get;
      set;
    }
    public string Cust_Vend_WarID
    {
      get;
      set;
    }
    public double? Trans_Qty
    {
      get;
      set;
    }
    public string UOM
    {
      get;
      set;
    }
    public decimal? Trans_Amount
    {
      get;
      set;
    }
    public double? Qty_On_Hand_EOB
    {
      get;
      set;
    }
    public double? Qty_On_Order_EOB
    {
      get;
      set;
    }
    public double? Qty_On_Allowed_EOB
    {
      get;
      set;
    }
    public string GL_Asset
    {
      get;
      set;
    }
    public string GL_COGS
    {
      get;
      set;
    }
    public string GL_Sales
    {
      get;
      set;
    }
  }
}
