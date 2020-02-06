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
    public partial class TblPoCashDisbursementsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoCashDisbursement> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoCashDisbursement> _getTblPoCashDisbursementsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoCashDisbursement> getTblPoCashDisbursementsResult
        {
            get
            {
                return _getTblPoCashDisbursementsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoCashDisbursementsResult, value))
                {
                    _getTblPoCashDisbursementsResult = value;
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
            var dbAtVdc2GetTblPoCashDisbursementsResult = await DbAtVdc2.GetTblPoCashDisbursements();
            getTblPoCashDisbursementsResult = dbAtVdc2GetTblPoCashDisbursementsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoCashDisbursement>("Add Tbl Po Cash Disbursement", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoCashDisbursement args)
        {
            var result = await DialogService.OpenAsync<EditTblPoCashDisbursement>("Edit Tbl Po Cash Disbursement", new Dictionary<string, object>() { {"PO_CashDisb_No", args.PO_CashDisb_No} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoCashDisbursementResult = await DbAtVdc2.DeleteTblPoCashDisbursement($"{data.PO_CashDisb_No}");
                if (dbAtVdc2DeleteTblPoCashDisbursementResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoCashDisbursementException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoCashDisbursement");
            }
        }
    }
}
