using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblIC_Inventory", Schema = "dbo")]
  public partial class TblIcInventory
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Inventory_SEQ
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrderDetail> TblPoPurchaseOrderDetails { get; set; }

    public ICollection<TblPoApInvoicesDetail> TblPoApInvoicesDetails { get; set; }

    public ICollection<TblPoRrOrderDetail> TblPoRrOrderDetails { get; set; }

    public ICollection<TblSoOrderDetail> TblSoOrderDetails { get; set; }
    public string Warehouse_FK
    {
      get;
      set;
    }
    public TblIcWarehouse TblIcWarehouse { get; set; }
    public string Category_FK
    {
      get;
      set;
    }
    public TblIcCategory TblIcCategory { get; set; }
    public string Classifi_FK
    {
      get;
      set;
    }
    public TblIcClassification TblIcClassification { get; set; }
    public int? Item_FK
    {
      get;
      set;
    }
    public TblGnProduct TblGnProduct { get; set; }
    public string Product_Code
    {
      get;
      set;
    }
    public string ProductDesc
    {
      get;
      set;
    }
    public bool? FixAsset
    {
      get;
      set;
    }
    public int? Unit_FK
    {
      get;
      set;
    }
    public TblIcUnit TblIcUnit { get; set; }
    public double? QuantityPerUnit
    {
      get;
      set;
    }
    public string Location
    {
      get;
      set;
    }
    public bool? Taxable
    {
      get;
      set;
    }
    public double? TaxRate
    {
      get;
      set;
    }
    public double? ROP
    {
      get;
      set;
    }
    public double? EOQ
    {
      get;
      set;
    }
    public decimal? UnitPrice
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
    public string GL_NonTaxSales
    {
      get;
      set;
    }
    public DateTime? LastSaleDate
    {
      get;
      set;
    }
    public DateTime? LastPODate
    {
      get;
      set;
    }
    public DateTime? LastReceiptDate
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? Leadtime
    {
      get;
      set;
    }
    public decimal? LastCost
    {
      get;
      set;
    }
    public decimal? EverageCost
    {
      get;
      set;
    }
    public double? Qty_On_Order
    {
      get;
      set;
    }
    public double? Qty_In_Stock
    {
      get;
      set;
    }
    public double? Qty_On_Hand
    {
      get;
      set;
    }
    public double? Qty_Allocated
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? TotalInventory
    {
      get;
      set;
    }
    public double? MTD_Qty_Sold
    {
      get;
      set;
    }
    public decimal? MTD_Gross_Sales
    {
      get;
      set;
    }
    public decimal? MTD_COGS
    {
      get;
      set;
    }
    public double? YTD_Qty_Sold
    {
      get;
      set;
    }
    public decimal? YTD_Gross_Sales
    {
      get;
      set;
    }
    public decimal? YTD_COGS
    {
      get;
      set;
    }
    public double? YTD_Qty_Returned
    {
      get;
      set;
    }
    public double? LTD_Qty_Sold
    {
      get;
      set;
    }
    public decimal? LTD_Gross_Sales
    {
      get;
      set;
    }
    public decimal? LTD_COGS
    {
      get;
      set;
    }
    public double? NetGrossRate
    {
      get;
      set;
    }
    public int? VendorNumber_FK
    {
      get;
      set;
    }
    public DateTime? LastUpdatedDate
    {
      get;
      set;
    }
    public int? LastUpdatedBy_FK
    {
      get;
      set;
    }
    public string Notes
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
