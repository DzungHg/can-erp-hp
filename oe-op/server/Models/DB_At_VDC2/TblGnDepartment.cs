using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_Department", Schema = "dbo")]
  public partial class TblGnDepartment
  {
    [Key]
    public string Department_ID
    {
      get;
      set;
    }


    public ICollection<TblPoAccountPayable> TblPoAccountPayables { get; set; }

    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders { get; set; }
    public string Deparment_Name
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
