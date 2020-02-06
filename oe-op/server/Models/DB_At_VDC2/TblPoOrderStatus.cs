using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_OrderStatus", Schema = "dbo")]
  public partial class TblPoOrderStatus
  {
    [Key]
    public string POStatus_ID
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders { get; set; }
    public string POStatusText
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
