using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_Gender", Schema = "dbo")]
  public partial class TblGnGender
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Gender_SEQ
    {
      get;
      set;
    }


    public ICollection<TblGnAddressBook> TblGnAddressBooks { get; set; }
    public string Gender_ID
    {
      get;
      set;
    }
    public string Gender
    {
      get;
      set;
    }
  }
}
