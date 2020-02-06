using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using CanErp2.Models.DbAtVdc2;
using Microsoft.EntityFrameworkCore;

namespace CanErp2.Pages
{
    public partial class EditTblPoPurchaseOrderComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected DbAtVdc2Service DbAtVdc2 { get; set; }

        [Parameter]
        public dynamic PO_ID { get; set; }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if(!object.Equals(_canEdit, value))
                {
                    _canEdit = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        CanErp2.Models.DbAtVdc2.TblPoPurchaseOrder _tblpopurchaseorder;
        protected CanErp2.Models.DbAtVdc2.TblPoPurchaseOrder tblpopurchaseorder
        {
            get
            {
                return _tblpopurchaseorder;
            }
            set
            {
                if(!object.Equals(_tblpopurchaseorder, value))
                {
                    _tblpopurchaseorder = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBook> _getTblGnAddressBooksResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBook> getTblGnAddressBooksResult
        {
            get
            {
                return _getTblGnAddressBooksResult;
            }
            set
            {
                if(!object.Equals(_getTblGnAddressBooksResult, value))
                {
                    _getTblGnAddressBooksResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoOrderStatus> _getTblPoOrderStatusesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoOrderStatus> getTblPoOrderStatusesResult
        {
            get
            {
                return _getTblPoOrderStatusesResult;
            }
            set
            {
                if(!object.Equals(_getTblPoOrderStatusesResult, value))
                {
                    _getTblPoOrderStatusesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoVendor> _getTblPoVendorsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoVendor> getTblPoVendorsResult
        {
            get
            {
                return _getTblPoVendorsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoVendorsResult, value))
                {
                    _getTblPoVendorsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnIncoterm> _getTblGnIncotermsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnIncoterm> getTblGnIncotermsResult
        {
            get
            {
                return _getTblGnIncotermsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnIncotermsResult, value))
                {
                    _getTblGnIncotermsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnShipVium> _getTblGnShipViaResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnShipVium> getTblGnShipViaResult
        {
            get
            {
                return _getTblGnShipViaResult;
            }
            set
            {
                if(!object.Equals(_getTblGnShipViaResult, value))
                {
                    _getTblGnShipViaResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> _getTblGnPaymentTermsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> getTblGnPaymentTermsResult
        {
            get
            {
                return _getTblGnPaymentTermsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnPaymentTermsResult, value))
                {
                    _getTblGnPaymentTermsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentType> _getTblGnPaymentTypesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentType> getTblGnPaymentTypesResult
        {
            get
            {
                return _getTblGnPaymentTypesResult;
            }
            set
            {
                if(!object.Equals(_getTblGnPaymentTypesResult, value))
                {
                    _getTblGnPaymentTypesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnDepartment> _getTblGnDepartmentsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnDepartment> getTblGnDepartmentsResult
        {
            get
            {
                return _getTblGnDepartmentsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnDepartmentsResult, value))
                {
                    _getTblGnDepartmentsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            canEdit = true;

            var dbAtVdc2GetTblPoPurchaseOrderByPoIdResult = await DbAtVdc2.GetTblPoPurchaseOrderByPoId($"{PO_ID}");
            tblpopurchaseorder = dbAtVdc2GetTblPoPurchaseOrderByPoIdResult;

            var dbAtVdc2GetTblGnAddressBooksResult = await DbAtVdc2.GetTblGnAddressBooks();
            getTblGnAddressBooksResult = dbAtVdc2GetTblGnAddressBooksResult;

            var dbAtVdc2GetTblPoOrderStatusesResult = await DbAtVdc2.GetTblPoOrderStatuses();
            getTblPoOrderStatusesResult = dbAtVdc2GetTblPoOrderStatusesResult;

            var dbAtVdc2GetTblPoVendorsResult = await DbAtVdc2.GetTblPoVendors();
            getTblPoVendorsResult = dbAtVdc2GetTblPoVendorsResult;

            var dbAtVdc2GetTblGnIncotermsResult = await DbAtVdc2.GetTblGnIncoterms();
            getTblGnIncotermsResult = dbAtVdc2GetTblGnIncotermsResult;

            var dbAtVdc2GetTblGnShipViaResult = await DbAtVdc2.GetTblGnShipVia();
            getTblGnShipViaResult = dbAtVdc2GetTblGnShipViaResult;

            var dbAtVdc2GetTblGnPaymentTermsResult = await DbAtVdc2.GetTblGnPaymentTerms();
            getTblGnPaymentTermsResult = dbAtVdc2GetTblGnPaymentTermsResult;

            var dbAtVdc2GetTblGnPaymentTypesResult = await DbAtVdc2.GetTblGnPaymentTypes();
            getTblGnPaymentTypesResult = dbAtVdc2GetTblGnPaymentTypesResult;

            var dbAtVdc2GetTblGnDepartmentsResult = await DbAtVdc2.GetTblGnDepartments();
            getTblGnDepartmentsResult = dbAtVdc2GetTblGnDepartmentsResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoPurchaseOrder args)
        {
            try
            {
                var dbAtVdc2UpdateTblPoPurchaseOrderResult = await DbAtVdc2.UpdateTblPoPurchaseOrder($"{PO_ID}", tblpopurchaseorder);
                DialogService.Close(tblpopurchaseorder);
            }
            catch (Exception dbAtVdc2UpdateTblPoPurchaseOrderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblPoPurchaseOrder");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
