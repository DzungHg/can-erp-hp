using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanErp2.Models.DbAtVdc2
{
  [Table("tblGN_PaymentTerms", Schema = "dbo")]
  public partial class TblGnPaymentTerm
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PaymentTerm_SEQ
    {
      get;
      set;
    }


    public ICollection<TblPoPurchaseOrder> TblPoPurchaseOrders { get; set; }

    public ICollection<TblSoCustomer> TblSoCustomers { get; set; }

    public ICollection<TblSoSalesOrder> TblSoSalesOrders { get; set; }
    public string PaymentTerm_ID
    {
      get;
      set;
    }
    public string PaymentTermText
    {
      get;
      set;
    }
  }
}
