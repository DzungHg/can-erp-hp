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
    public partial class TblPoRrOrderDetailsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail> _getTblPoRrOrderDetailsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail> getTblPoRrOrderDetailsResult
        {
            get
            {
                return _getTblPoRrOrderDetailsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoRrOrderDetailsResult, value))
                {
                    _getTblPoRrOrderDetailsResult = value;
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
            var dbAtVdc2GetTblPoRrOrderDetailsResult = await DbAtVdc2.GetTblPoRrOrderDetails();
            getTblPoRrOrderDetailsResult = dbAtVdc2GetTblPoRrOrderDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoRrOrderDetail>("Add Tbl Po Rr Order Detail", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail args)
        {
            var result = await DialogService.OpenAsync<EditTblPoRrOrderDetail>("Edit Tbl Po Rr Order Detail", new Dictionary<string, object>() { {"RR_FK", args.RR_FK}, {"Inventory_FK", args.Inventory_FK} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoRrOrderDetailResult = await DbAtVdc2.DeleteTblPoRrOrderDetail($"{data.RR_FK}", data.Inventory_FK);
                if (dbAtVdc2DeleteTblPoRrOrderDetailResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoRrOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoRrOrderDetail");
            }
        }
    }
}
