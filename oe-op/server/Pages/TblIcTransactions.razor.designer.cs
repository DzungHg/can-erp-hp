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
    public partial class TblIcTransactionsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblIcTransaction> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcTransaction> _getTblIcTransactionsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcTransaction> getTblIcTransactionsResult
        {
            get
            {
                return _getTblIcTransactionsResult;
            }
            set
            {
                if(!object.Equals(_getTblIcTransactionsResult, value))
                {
                    _getTblIcTransactionsResult = value;
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
            var dbAtVdc2GetTblIcTransactionsResult = await DbAtVdc2.GetTblIcTransactions();
            getTblIcTransactionsResult = dbAtVdc2GetTblIcTransactionsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblIcTransaction>("Add Tbl Ic Transaction", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblIcTransaction args)
        {
            var result = await DialogService.OpenAsync<EditTblIcTransaction>("Edit Tbl Ic Transaction", new Dictionary<string, object>() { {"Trans_No", args.Trans_No} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblIcTransactionResult = await DbAtVdc2.DeleteTblIcTransaction($"{data.Trans_No}");
                if (dbAtVdc2DeleteTblIcTransactionResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblIcTransactionException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblIcTransaction");
            }
        }
    }
}
