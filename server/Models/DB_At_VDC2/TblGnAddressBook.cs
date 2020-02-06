using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_AddressBook", Schema = "dbo")]
  public partial class TblGnAddressBook
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressBook_SEQ
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders { get; set; }

    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders1 { get; set; }

    public ICollection<TblPoRecReport> TblPoRecReports { get; set; }

    public ICollection<TblPoCashDisbursement> TblPoCashDisbursements { get; set; }

    public ICollection<TblSoCustomer> TblSoCustomers { get; set; }

    public ICollection<TblPoVendor> TblPoVendors { get; set; }
    public string AddressBook_ID
    {
      get;
      set;
    }
    public int? AddressBookType_FK
    {
      get;
      set;
    }
    public TblGnAddressBookType TblGnAddressBookType { get; set; }
    public string LastName
    {
      get;
      set;
    }
    public string FirstName
    {
      get;
      set;
    }
    public int? Gender_FK
    {
      get;
      set;
    }
    public TblGnGender TblGnGender { get; set; }
    public DateTime? DOB
    {
      get;
      set;
    }
    public string Origin
    {
      get;
      set;
    }
    public string IDNumber
    {
      get;
      set;
    }
    public string TaxIDNumber
    {
      get;
      set;
    }
    public string OrganizationName
    {
      get;
      set;
    }
    public string JobPosition
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public string City_FK
    {
      get;
      set;
    }
    public TblHpTinhTp TblHpTinhTp { get; set; }
  }
}
