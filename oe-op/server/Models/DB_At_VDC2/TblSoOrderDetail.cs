using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblSO_OrderDetail", Schema = "dbo")]
  public partial class TblSoOrderDetail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SODetail_SEQ
    {
      get;
      set;
    }
    public int? SODetailStatus_FK
    {
      get;
      set;
    }
    public TblSoOrderDetailStatus TblSoOrderDetailStatus { get; set; }
    public int? SO_FK
    {
      get;
      set;
    }
    public TblSoSalesOrder TblSoSalesOrder { get; set; }
    public int? Inventory_FK
    {
      get;
      set;
    }
    public TblIcInventory TblIcInventory { get; set; }
    public decimal? UnitPrice
    {
      get;
      set;
    }
    public int? QtyOnHand
    {
      get;
      set;
    }
    public int? QtyOrdered
    {
      get;
      set;
    }
    public int? QtyOrderedNow
    {
      get;
      set;
    }
    public int? QtyBackOrdered
    {
      get;
      set;
    }
    public int? QtyPicked
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? SubTotal
    {
      get;
      set;
    }
    public decimal? DiscountPercent
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? Discount
    {
      get;
      set;
    }
    public decimal? TaxRate
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal? Tax
    {
      get;
      set;
    }
  }
}
