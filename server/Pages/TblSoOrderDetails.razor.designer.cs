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
    public partial class TblSoOrderDetailsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblSoOrderDetail> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblSoOrderDetail> _getTblSoOrderDetailsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblSoOrderDetail> getTblSoOrderDetailsResult
        {
            get
            {
                return _getTblSoOrderDetailsResult;
            }
            set
            {
                if(!object.Equals(_getTblSoOrderDetailsResult, value))
                {
                    _getTblSoOrderDetailsResult = value;
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
            var dbAtVdc2GetTblSoOrderDetailsResult = await DbAtVdc2.GetTblSoOrderDetails();
            getTblSoOrderDetailsResult = dbAtVdc2GetTblSoOrderDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblSoOrderDetail>("Add Tbl So Order Detail", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblSoOrderDetail args)
        {
            var result = await DialogService.OpenAsync<EditTblSoOrderDetail>("Edit Tbl So Order Detail", new Dictionary<string, object>() { {"SODetail_SEQ", args.SODetail_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblSoOrderDetailResult = await DbAtVdc2.DeleteTblSoOrderDetail(data.SODetail_SEQ);
                if (dbAtVdc2DeleteTblSoOrderDetailResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblSoOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblSoOrderDetail");
            }
        }
    }
}
