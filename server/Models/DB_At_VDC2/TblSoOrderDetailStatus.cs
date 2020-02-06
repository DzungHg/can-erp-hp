using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblSO_OrderDetailStatus", Schema = "dbo")]
  public partial class TblSoOrderDetailStatus
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SODetailStatus_SEQ
    {
      get;
      set;
    }


    public ICollection<TblSoOrderDetail> TblSoOrderDetails { get; set; }
    public int? SODetailStatus_ID
    {
      get;
      set;
    }
    public string SODetailStatusText
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
