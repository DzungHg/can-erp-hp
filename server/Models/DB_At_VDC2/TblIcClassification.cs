using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblIC_Classification", Schema = "dbo")]
  public partial class TblIcClassification
  {
    [Key]
    public string Classifi_ID
    {
      get;
      set;
    }


    public ICollection<TblIcInventory> TblIcInventories { get; set; }
    public string Classifi_Name
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
