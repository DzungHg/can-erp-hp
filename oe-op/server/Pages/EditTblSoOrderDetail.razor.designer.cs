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
    public partial class EditTblSoOrderDetailComponent : ComponentBase
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
        public dynamic SODetail_SEQ { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblSoOrderDetail _tblsoorderdetail;
        protected CanErp2.Models.DbAtVdc2.TblSoOrderDetail tblsoorderdetail
        {
            get
            {
                return _tblsoorderdetail;
            }
            set
            {
                if(!object.Equals(_tblsoorderdetail, value))
                {
                    _tblsoorderdetail = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus> _getTblSoOrderDetailStatusesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus> getTblSoOrderDetailStatusesResult
        {
            get
            {
                return _getTblSoOrderDetailStatusesResult;
            }
            set
            {
                if(!object.Equals(_getTblSoOrderDetailStatusesResult, value))
                {
                    _getTblSoOrderDetailStatusesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblSoSalesOrder> _getTblSoSalesOrdersResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblSoSalesOrder> getTblSoSalesOrdersResult
        {
            get
            {
                return _getTblSoSalesOrdersResult;
            }
            set
            {
                if(!object.Equals(_getTblSoSalesOrdersResult, value))
                {
                    _getTblSoSalesOrdersResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcInventory> _getTblIcInventoriesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcInventory> getTblIcInventoriesResult
        {
            get
            {
                return _getTblIcInventoriesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcInventoriesResult, value))
                {
                    _getTblIcInventoriesResult = value;
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

            var dbAtVdc2GetTblSoOrderDetailBySoDetailSeqResult = await DbAtVdc2.GetTblSoOrderDetailBySoDetailSeq(int.Parse($"{SODetail_SEQ}"));
            tblsoorderdetail = dbAtVdc2GetTblSoOrderDetailBySoDetailSeqResult;

            var dbAtVdc2GetTblSoOrderDetailStatusesResult = await DbAtVdc2.GetTblSoOrderDetailStatuses();
            getTblSoOrderDetailStatusesResult = dbAtVdc2GetTblSoOrderDetailStatusesResult;

            var dbAtVdc2GetTblSoSalesOrdersResult = await DbAtVdc2.GetTblSoSalesOrders();
            getTblSoSalesOrdersResult = dbAtVdc2GetTblSoSalesOrdersResult;

            var dbAtVdc2GetTblIcInventoriesResult = await DbAtVdc2.GetTblIcInventories();
            getTblIcInventoriesResult = dbAtVdc2GetTblIcInventoriesResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblSoOrderDetail args)
        {
            try
            {
                var dbAtVdc2UpdateTblSoOrderDetailResult = await DbAtVdc2.UpdateTblSoOrderDetail(int.Parse($"{SODetail_SEQ}"), tblsoorderdetail);
                DialogService.Close(tblsoorderdetail);
            }
            catch (Exception dbAtVdc2UpdateTblSoOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblSoOrderDetail");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
