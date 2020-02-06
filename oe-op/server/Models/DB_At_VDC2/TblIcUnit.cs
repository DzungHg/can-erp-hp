using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblIC_Unit", Schema = "dbo")]
  public partial class TblIcUnit
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Unit_SEQ
    {
      get;
      set;
    }


    public ICollection<TblPoApInvoicesDetail> TblPoApInvoicesDetails { get; set; }

    public ICollection<TblIcInventory> TblIcInventories { get; set; }
    public string UnitText
    {
      get;
      set;
    }
    public string Unit_FK
    {
      get;
      set;
    }
  }
}
