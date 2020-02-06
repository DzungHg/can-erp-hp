using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblIC_Category", Schema = "dbo")]
  public partial class TblIcCategory
  {
    [Key]
    public string Category_ID
    {
      get;
      set;
    }


    public ICollection<TblIcInventory> TblIcInventories { get; set; }
    public string CategoryText
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
