using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblHP_TinhTP", Schema = "dbo")]
  public partial class TblHpTinhTp
  {
    [Key]
    public string TinhTP_ID
    {
      get;
      set;
    }


    public ICollection<TblGnAddressBook> TblGnAddressBooks { get; set; }
    public string TinhTP_Name
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
