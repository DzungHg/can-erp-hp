using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_ShipVia", Schema = "dbo")]
  public partial class TblGnShipVium
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ShipVia_SEQ
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders { get; set; }

    public ICollection<TblSoSalesOrder> TblSoSalesOrders { get; set; }
    public string ShipVia_ID
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
  }
}
