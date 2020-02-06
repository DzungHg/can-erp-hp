using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_RROrderDetail", Schema = "dbo")]
  public partial class TblPoRrOrderDetail
  {
    [Key]
    public string RR_FK
    {
      get;
      set;
    }
    public TblPoRecReport TblPoRecReport { get; set; }
    [Key]
    public int Inventory_FK
    {
      get;
      set;
    }
    public TblIcInventory TblIcInventory { get; set; }
    public decimal? Unit_Price
    {
      get;
      set;
    }
    public double? QtyOrdered
    {
      get;
      set;
    }
    public double? QtyReceived
    {
      get;
      set;
    }
  }
}
