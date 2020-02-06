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
    public partial class EditTblSoSalesOrderComponent : ComponentBase
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
        public dynamic SO_SEQ { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblSoSalesOrder _tblsosalesorder;
        protected CanErp2.Models.DbAtVdc2.TblSoSalesOrder tblsosalesorder
        {
            get
            {
                return _tblsosalesorder;
            }
            set
            {
                if(!object.Equals(_tblsosalesorder, value))
                {
                    _tblsosalesorder = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblSoOrderStatus> _getTblSoOrderStatusesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblSoOrderStatus> getTblSoOrderStatusesResult
        {
            get
            {
                return _getTblSoOrderStatusesResult;
            }
            set
            {
                if(!object.Equals(_getTblSoOrderStatusesResult, value))
                {
                    _getTblSoOrderStatusesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblSoCustomer> _getTblSoCustomersResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblSoCustomer> getTblSoCustomersResult
        {
            get
            {
                return _getTblSoCustomersResult;
            }
            set
            {
                if(!object.Equals(_getTblSoCustomersResult, value))
                {
                    _getTblSoCustomersResult = value;
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            canEdit = true;

            var dbAtVdc2GetTblSoSalesOrderBySoSeqResult = await DbAtVdc2.GetTblSoSalesOrderBySoSeq(int.Parse($"{SO_SEQ}"));
            tblsosalesorder = dbAtVdc2GetTblSoSalesOrderBySoSeqResult;

            var dbAtVdc2GetTblSoOrderStatusesResult = await DbAtVdc2.GetTblSoOrderStatuses();
            getTblSoOrderStatusesResult = dbAtVdc2GetTblSoOrderStatusesResult;

            var dbAtVdc2GetTblSoCustomersResult = await DbAtVdc2.GetTblSoCustomers();
            getTblSoCustomersResult = dbAtVdc2GetTblSoCustomersResult;

            var dbAtVdc2GetTblGnShipViaResult = await DbAtVdc2.GetTblGnShipVia();
            getTblGnShipViaResult = dbAtVdc2GetTblGnShipViaResult;

            var dbAtVdc2GetTblGnPaymentTermsResult = await DbAtVdc2.GetTblGnPaymentTerms();
            getTblGnPaymentTermsResult = dbAtVdc2GetTblGnPaymentTermsResult;

            var dbAtVdc2GetTblGnPaymentTypesResult = await DbAtVdc2.GetTblGnPaymentTypes();
            getTblGnPaymentTypesResult = dbAtVdc2GetTblGnPaymentTypesResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblSoSalesOrder args)
        {
            try
            {
                var dbAtVdc2UpdateTblSoSalesOrderResult = await DbAtVdc2.UpdateTblSoSalesOrder(int.Parse($"{SO_SEQ}"), tblsosalesorder);
                DialogService.Close(tblsosalesorder);
            }
            catch (Exception dbAtVdc2UpdateTblSoSalesOrderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblSoSalesOrder");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
