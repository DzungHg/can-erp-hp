using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_AccountPayable", Schema = "dbo")]
  public partial class TblPoAccountPayable
  {
    [Key]
    public string AP_No
    {
      get;
      set;
    }
    public string Vendor_FK
    {
      get;
      set;
    }
    public TblPoVendor TblPoVendor { get; set; }
    public string Transact_No
    {
      get;
      set;
    }
    public string Record_Code
    {
      get;
      set;
    }
    public string PO_No
    {
      get;
      set;
    }
    public DateTime? Transact_Date
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public decimal? Amount
    {
      get;
      set;
    }
    public string Department_FK
    {
      get;
      set;
    }
    public TblGnDepartment TblGnDepartment { get; set; }
  }
}
