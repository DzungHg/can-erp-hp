using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblPO_PurchaseOrder", Schema = "dbo")]
  public partial class TblPoPurchaseOrder
  {
    [Key]
    public string PO_ID
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrderDetail> TblPoPurchaseOrderDetails { get; set; }
    public DateTime? PODate
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
    public string POStatus_FK
    {
      get;
      set;
    }
    public TblPoOrderStatus TblPoOrderStatus { get; set; }
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
    public string Incoterm_FK
    {
      get;
      set;
    }
    public TblGnIncoterm TblGnIncoterm { get; set; }
    public int? ShipVia_FK
    {
      get;
      set;
    }
    public TblGnShipVium TblGnShipVium { get; set; }
    public int? PaymentTerm_FK
    {
      get;
      set;
    }
    public TblGnPaymentTerm TblGnPaymentTerm { get; set; }
    public int? PaymentType_FK
    {
      get;
      set;
    }
    public TblGnPaymentType TblGnPaymentType { get; set; }
    public int? Buyer_FK
    {
      get;
      set;
    }
    public TblGnAddressBook TblGnAddressBook1 { get; set; }
    public bool? TaxYN
    {
      get;
      set;
    }
    public double? TaxtRate
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
    public decimal? PO_Amount
    {
      get;
      set;
    }
  }
}
