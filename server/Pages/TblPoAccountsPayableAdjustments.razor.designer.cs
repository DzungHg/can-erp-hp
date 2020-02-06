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
    public partial class TblPoAccountsPayableAdjustmentsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment> _getTblPoAccountsPayableAdjustmentsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment> getTblPoAccountsPayableAdjustmentsResult
        {
            get
            {
                return _getTblPoAccountsPayableAdjustmentsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoAccountsPayableAdjustmentsResult, value))
                {
                    _getTblPoAccountsPayableAdjustmentsResult = value;
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
            var dbAtVdc2GetTblPoAccountsPayableAdjustmentsResult = await DbAtVdc2.GetTblPoAccountsPayableAdjustments();
            getTblPoAccountsPayableAdjustmentsResult = dbAtVdc2GetTblPoAccountsPayableAdjustmentsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoAccountsPayableAdjustment>("Add Tbl Po Accounts Payable Adjustment", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment args)
        {
            var result = await DialogService.OpenAsync<EditTblPoAccountsPayableAdjustment>("Edit Tbl Po Accounts Payable Adjustment", new Dictionary<string, object>() { {"Voucher_No", args.Voucher_No} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoAccountsPayableAdjustmentResult = await DbAtVdc2.DeleteTblPoAccountsPayableAdjustment($"{data.Voucher_No}");
                if (dbAtVdc2DeleteTblPoAccountsPayableAdjustmentResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoAccountsPayableAdjustmentException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoAccountsPayableAdjustment");
            }
        }
    }
}
