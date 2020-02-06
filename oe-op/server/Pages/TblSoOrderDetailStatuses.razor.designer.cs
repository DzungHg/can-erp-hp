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
    public partial class TblSoOrderDetailStatusesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus> grid0;

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var dbAtVdc2GetTblSoOrderDetailStatusesResult = await DbAtVdc2.GetTblSoOrderDetailStatuses();
            getTblSoOrderDetailStatusesResult = dbAtVdc2GetTblSoOrderDetailStatusesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblSoOrderDetailStatus>("Add Tbl So Order Detail Status", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus args)
        {
            var result = await DialogService.OpenAsync<EditTblSoOrderDetailStatus>("Edit Tbl So Order Detail Status", new Dictionary<string, object>() { {"SODetailStatus_SEQ", args.SODetailStatus_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblSoOrderDetailStatusResult = await DbAtVdc2.DeleteTblSoOrderDetailStatus(data.SODetailStatus_SEQ);
                if (dbAtVdc2DeleteTblSoOrderDetailStatusResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblSoOrderDetailStatusException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblSoOrderDetailStatus");
            }
        }
    }
}
