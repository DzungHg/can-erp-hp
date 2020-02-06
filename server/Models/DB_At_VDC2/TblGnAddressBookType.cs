using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_AddressBookType", Schema = "dbo")]
  public partial class TblGnAddressBookType
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressBookType_SEQ
    {
      get;
      set;
    }


    public ICollection<TblGnAddressBook> TblGnAddressBooks { get; set; }
    public string AddressBookType_ID
    {
      get;
      set;
    }
    public string AddressBookTypeText
    {
      get;
      set;
    }
  }
}
