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
    public partial class TblPoPurchaseOrderDetailsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail> _getTblPoPurchaseOrderDetailsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail> getTblPoPurchaseOrderDetailsResult
        {
            get
            {
                return _getTblPoPurchaseOrderDetailsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoPurchaseOrderDetailsResult, value))
                {
                    _getTblPoPurchaseOrderDetailsResult = value;
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
            var dbAtVdc2GetTblPoPurchaseOrderDetailsResult = await DbAtVdc2.GetTblPoPurchaseOrderDetails();
            getTblPoPurchaseOrderDetailsResult = dbAtVdc2GetTblPoPurchaseOrderDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoPurchaseOrderDetail>("Add Tbl Po Purchase Order Detail", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoPurchaseOrderDetail args)
        {
            var result = await DialogService.OpenAsync<EditTblPoPurchaseOrderDetail>("Edit Tbl Po Purchase Order Detail", new Dictionary<string, object>() { {"PO_FK", args.PO_FK}, {"Inventory_FK", args.Inventory_FK} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoPurchaseOrderDetailResult = await DbAtVdc2.DeleteTblPoPurchaseOrderDetail($"{data.PO_FK}", data.Inventory_FK);
                if (dbAtVdc2DeleteTblPoPurchaseOrderDetailResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoPurchaseOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoPurchaseOrderDetail");
            }
        }
    }
}
