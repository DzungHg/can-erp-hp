using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_RecReport", Schema = "dbo")]
  public partial class TblPoRecReport
  {
    [Key]
    public string RR_No
    {
      get;
      set;
    }


    public ICollection<TblPoRrOrderDetail> TblPoRrOrderDetails { get; set; }
    public DateTime? RRDate
    {
      get;
      set;
    }
    public int? CreatedBy_FK
    {
      get;
      set;
    }
    public TblGnAddressBook TblGnAddressBook { get; set; }
    public string PO_ID
    {
      get;
      set;
    }
    public int? POStatus_FK
    {
      get;
      set;
    }
    public DateTime? PODate
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
    public string Description
    {
      get;
      set;
    }
    public string Invoice_No
    {
      get;
      set;
    }
    public DateTime? Invoice_Date
    {
      get;
      set;
    }
    public string Ship_No
    {
      get;
      set;
    }
    public DateTime? Ship_Date
    {
      get;
      set;
    }
    public int? Receiver_FK
    {
      get;
      set;
    }
    public string BillOf_Loading_No
    {
      get;
      set;
    }
    public decimal? PO_Amount
    {
      get;
      set;
    }
    public bool? Inactive
    {
      get;
      set;
    }
    public bool? Warhoused
    {
      get;
      set;
    }
  }
}
