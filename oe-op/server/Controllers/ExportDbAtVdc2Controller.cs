using Microsoft.AspNetCore.Mvc;
using CanErp2.Data;

namespace CanErp2
{
    public partial class ExportDbAtVdc2Controller : ExportController
    {
        private readonly DbAtVdc2Context context;

        public ExportDbAtVdc2Controller(DbAtVdc2Context context)
        {
            this.context = context;
        }

        [HttpGet("/export/DbAtVdc2/tblgnaddressbooks/csv")]
        public FileStreamResult ExportTblGnAddressBooksToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnAddressBooks, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnaddressbooks/excel")]
        public FileStreamResult ExportTblGnAddressBooksToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnAddressBooks, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnaddressbooktypes/csv")]
        public FileStreamResult ExportTblGnAddressBookTypesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnAddressBookTypes, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnaddressbooktypes/excel")]
        public FileStreamResult ExportTblGnAddressBookTypesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnAddressBookTypes, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgndepartments/csv")]
        public FileStreamResult ExportTblGnDepartmentsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnDepartments, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgndepartments/excel")]
        public FileStreamResult ExportTblGnDepartmentsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnDepartments, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgngenders/csv")]
        public FileStreamResult ExportTblGnGendersToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnGenders, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgngenders/excel")]
        public FileStreamResult ExportTblGnGendersToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnGenders, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnincoterms/csv")]
        public FileStreamResult ExportTblGnIncotermsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnIncoterms, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnincoterms/excel")]
        public FileStreamResult ExportTblGnIncotermsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnIncoterms, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnpaymentterms/csv")]
        public FileStreamResult ExportTblGnPaymentTermsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnPaymentTerms, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnpaymentterms/excel")]
        public FileStreamResult ExportTblGnPaymentTermsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnPaymentTerms, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnpaymenttypes/csv")]
        public FileStreamResult ExportTblGnPaymentTypesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnPaymentTypes, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnpaymenttypes/excel")]
        public FileStreamResult ExportTblGnPaymentTypesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnPaymentTypes, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnproducts/csv")]
        public FileStreamResult ExportTblGnProductsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnProducts, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnproducts/excel")]
        public FileStreamResult ExportTblGnProductsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnProducts, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnshipvia/csv")]
        public FileStreamResult ExportTblGnShipViaToCSV()
        {
            return ToCSV(ApplyQuery(context.TblGnShipVia, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblgnshipvia/excel")]
        public FileStreamResult ExportTblGnShipViaToExcel()
        {
            return ToExcel(ApplyQuery(context.TblGnShipVia, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblhptinhtps/csv")]
        public FileStreamResult ExportTblHpTinhTpsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblHpTinhTps, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblhptinhtps/excel")]
        public FileStreamResult ExportTblHpTinhTpsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblHpTinhTps, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tbliccategories/csv")]
        public FileStreamResult ExportTblIcCategoriesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcCategories, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tbliccategories/excel")]
        public FileStreamResult ExportTblIcCategoriesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcCategories, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicclassifications/csv")]
        public FileStreamResult ExportTblIcClassificationsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcClassifications, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicclassifications/excel")]
        public FileStreamResult ExportTblIcClassificationsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcClassifications, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicinventories/csv")]
        public FileStreamResult ExportTblIcInventoriesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcInventories, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicinventories/excel")]
        public FileStreamResult ExportTblIcInventoriesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcInventories, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblictransactions/csv")]
        public FileStreamResult ExportTblIcTransactionsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcTransactions, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblictransactions/excel")]
        public FileStreamResult ExportTblIcTransactionsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcTransactions, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblictransactiontypes/csv")]
        public FileStreamResult ExportTblIcTransactionTypesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcTransactionTypes, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblictransactiontypes/excel")]
        public FileStreamResult ExportTblIcTransactionTypesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcTransactionTypes, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicunits/csv")]
        public FileStreamResult ExportTblIcUnitsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcUnits, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicunits/excel")]
        public FileStreamResult ExportTblIcUnitsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcUnits, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicwarehouses/csv")]
        public FileStreamResult ExportTblIcWarehousesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblIcWarehouses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblicwarehouses/excel")]
        public FileStreamResult ExportTblIcWarehousesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblIcWarehouses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoaccountpayables/csv")]
        public FileStreamResult ExportTblPoAccountPayablesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoAccountPayables, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoaccountpayables/excel")]
        public FileStreamResult ExportTblPoAccountPayablesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoAccountPayables, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoaccountspayableadjustments/csv")]
        public FileStreamResult ExportTblPoAccountsPayableAdjustmentsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoAccountsPayableAdjustments, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoaccountspayableadjustments/excel")]
        public FileStreamResult ExportTblPoAccountsPayableAdjustmentsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoAccountsPayableAdjustments, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoapinvoices/csv")]
        public FileStreamResult ExportTblPoApInvoicesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoApInvoices, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoapinvoices/excel")]
        public FileStreamResult ExportTblPoApInvoicesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoApInvoices, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoapinvoicesdetails/csv")]
        public FileStreamResult ExportTblPoApInvoicesDetailsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoApInvoicesDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoapinvoicesdetails/excel")]
        public FileStreamResult ExportTblPoApInvoicesDetailsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoApInvoicesDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpocashdisbursements/csv")]
        public FileStreamResult ExportTblPoCashDisbursementsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoCashDisbursements, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpocashdisbursements/excel")]
        public FileStreamResult ExportTblPoCashDisbursementsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoCashDisbursements, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoorderstatuses/csv")]
        public FileStreamResult ExportTblPoOrderStatusesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoOrderStatuses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpoorderstatuses/excel")]
        public FileStreamResult ExportTblPoOrderStatusesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoOrderStatuses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpopurchaseorders/csv")]
        public FileStreamResult ExportTblPoPurchaseOrdersToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoPurchaseOrders, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpopurchaseorders/excel")]
        public FileStreamResult ExportTblPoPurchaseOrdersToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoPurchaseOrders, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpopurchaseorderdetails/csv")]
        public FileStreamResult ExportTblPoPurchaseOrderDetailsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoPurchaseOrderDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpopurchaseorderdetails/excel")]
        public FileStreamResult ExportTblPoPurchaseOrderDetailsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoPurchaseOrderDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblporecreports/csv")]
        public FileStreamResult ExportTblPoRecReportsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoRecReports, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblporecreports/excel")]
        public FileStreamResult ExportTblPoRecReportsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoRecReports, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblporrorderdetails/csv")]
        public FileStreamResult ExportTblPoRrOrderDetailsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoRrOrderDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblporrorderdetails/excel")]
        public FileStreamResult ExportTblPoRrOrderDetailsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoRrOrderDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpovendors/csv")]
        public FileStreamResult ExportTblPoVendorsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblPoVendors, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblpovendors/excel")]
        public FileStreamResult ExportTblPoVendorsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblPoVendors, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsocustomers/csv")]
        public FileStreamResult ExportTblSoCustomersToCSV()
        {
            return ToCSV(ApplyQuery(context.TblSoCustomers, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsocustomers/excel")]
        public FileStreamResult ExportTblSoCustomersToExcel()
        {
            return ToExcel(ApplyQuery(context.TblSoCustomers, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsoorderdetails/csv")]
        public FileStreamResult ExportTblSoOrderDetailsToCSV()
        {
            return ToCSV(ApplyQuery(context.TblSoOrderDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsoorderdetails/excel")]
        public FileStreamResult ExportTblSoOrderDetailsToExcel()
        {
            return ToExcel(ApplyQuery(context.TblSoOrderDetails, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsoorderdetailstatuses/csv")]
        public FileStreamResult ExportTblSoOrderDetailStatusesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblSoOrderDetailStatuses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsoorderdetailstatuses/excel")]
        public FileStreamResult ExportTblSoOrderDetailStatusesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblSoOrderDetailStatuses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsoorderstatuses/csv")]
        public FileStreamResult ExportTblSoOrderStatusesToCSV()
        {
            return ToCSV(ApplyQuery(context.TblSoOrderStatuses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsoorderstatuses/excel")]
        public FileStreamResult ExportTblSoOrderStatusesToExcel()
        {
            return ToExcel(ApplyQuery(context.TblSoOrderStatuses, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsosalesorders/csv")]
        public FileStreamResult ExportTblSoSalesOrdersToCSV()
        {
            return ToCSV(ApplyQuery(context.TblSoSalesOrders, Request.Query));
        }

        [HttpGet("/export/DbAtVdc2/tblsosalesorders/excel")]
        public FileStreamResult ExportTblSoSalesOrdersToExcel()
        {
            return ToExcel(ApplyQuery(context.TblSoSalesOrders, Request.Query));
        }
    }
}
