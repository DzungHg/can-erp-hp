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
    public partial class TblSoSalesOrdersComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblSoSalesOrder> grid0;

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var dbAtVdc2GetTblSoSalesOrdersResult = await DbAtVdc2.GetTblSoSalesOrders();
            getTblSoSalesOrdersResult = dbAtVdc2GetTblSoSalesOrdersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblSoSalesOrder>("Add Tbl So Sales Order", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblSoSalesOrder args)
        {
            var result = await DialogService.OpenAsync<EditTblSoSalesOrder>("Edit Tbl So Sales Order", new Dictionary<string, object>() { {"SO_SEQ", args.SO_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblSoSalesOrderResult = await DbAtVdc2.DeleteTblSoSalesOrder(data.SO_SEQ);
                if (dbAtVdc2DeleteTblSoSalesOrderResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblSoSalesOrderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblSoSalesOrder");
            }
        }
    }
}
