using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_Incoterms", Schema = "dbo")]
  public partial class TblGnIncoterm
  {
    [Key]
    public string Incoterm_ID
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders { get; set; }
    public string Incoterm_Name
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
