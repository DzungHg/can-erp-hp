using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_Product", Schema = "dbo")]
  public partial class TblGnProduct
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Product_SEQ
    {
      get;
      set;
    }


    public ICollection<TblIcTransaction> TblIcTransactions { get; set; }

    public ICollection<TblIcInventory> TblIcInventories { get; set; }
    public string Product_ID
    {
      get;
      set;
    }
    public string ProductName
    {
      get;
      set;
    }
  }
}
