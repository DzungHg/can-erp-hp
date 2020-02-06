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
    public partial class EditTblPoPurchaseOrderDetailComponent : ComponentBase
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
        public dynamic PO_FK { get; set; }

        [Parameter]
        public dynamic Inventory_FK { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail _tblpopurchaseorderdetail;
        protected CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail tblpopurchaseorderdetail
        {
            get
            {
                return _tblpopurchaseorderdetail;
            }
            set
            {
                if(!object.Equals(_tblpopurchaseorderdetail, value))
                {
                    _tblpopurchaseorderdetail = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoPurchaseOrder> _getTblPoPurchaseOrdersResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoPurchaseOrder> getTblPoPurchaseOrdersResult
        {
            get
            {
                return _getTblPoPurchaseOrdersResult;
            }
            set
            {
                if(!object.Equals(_getTblPoPurchaseOrdersResult, value))
                {
                    _getTblPoPurchaseOrdersResult = value;
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

            var dbAtVdc2GetTblPoPurchaseOrderDetailByPoFkAndInventoryFkResult = await DbAtVdc2.GetTblPoPurchaseOrderDetailByPoFkAndInventoryFk($"{PO_FK}", int.Parse($"{Inventory_FK}"));
            tblpopurchaseorderdetail = dbAtVdc2GetTblPoPurchaseOrderDetailByPoFkAndInventoryFkResult;

            var dbAtVdc2GetTblPoPurchaseOrdersResult = await DbAtVdc2.GetTblPoPurchaseOrders();
            getTblPoPurchaseOrdersResult = dbAtVdc2GetTblPoPurchaseOrdersResult;

            var dbAtVdc2GetTblIcInventoriesResult = await DbAtVdc2.GetTblIcInventories();
            getTblIcInventoriesResult = dbAtVdc2GetTblIcInventoriesResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail args)
        {
            try
            {
                var dbAtVdc2UpdateTblPoPurchaseOrderDetailResult = await DbAtVdc2.UpdateTblPoPurchaseOrderDetail($"{PO_FK}", int.Parse($"{Inventory_FK}"), tblpopurchaseorderdetail);
                DialogService.Close(tblpopurchaseorderdetail);
            }
            catch (Exception dbAtVdc2UpdateTblPoPurchaseOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblPoPurchaseOrderDetail");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
