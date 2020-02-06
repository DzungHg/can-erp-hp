using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblSO_OrderStatus", Schema = "dbo")]
  public partial class TblSoOrderStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SOStatus_SEQ
    {
      get;
      set;
    }


    public ICollection<TblSoSalesOrder> TblSoSalesOrders { get; set; }
    public string SOStatus_ID
    {
      get;
      set;
    }
    public string SOStatusText
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
