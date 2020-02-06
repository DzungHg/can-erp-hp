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
    public partial class TblSoOrderStatusesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblSoOrderStatus> grid0;

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var dbAtVdc2GetTblSoOrderStatusesResult = await DbAtVdc2.GetTblSoOrderStatuses();
            getTblSoOrderStatusesResult = dbAtVdc2GetTblSoOrderStatusesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblSoOrderStatus>("Add Tbl So Order Status", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblSoOrderStatus args)
        {
            var result = await DialogService.OpenAsync<EditTblSoOrderStatus>("Edit Tbl So Order Status", new Dictionary<string, object>() { {"SOStatus_SEQ", args.SOStatus_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblSoOrderStatusResult = await DbAtVdc2.DeleteTblSoOrderStatus(data.SOStatus_SEQ);
                if (dbAtVdc2DeleteTblSoOrderStatusResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblSoOrderStatusException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblSoOrderStatus");
            }
        }
    }
}
