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
    public partial class TblPoApInvoicesDetailsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail> _getTblPoApInvoicesDetailsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail> getTblPoApInvoicesDetailsResult
        {
            get
            {
                return _getTblPoApInvoicesDetailsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoApInvoicesDetailsResult, value))
                {
                    _getTblPoApInvoicesDetailsResult = value;
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
            var dbAtVdc2GetTblPoApInvoicesDetailsResult = await DbAtVdc2.GetTblPoApInvoicesDetails();
            getTblPoApInvoicesDetailsResult = dbAtVdc2GetTblPoApInvoicesDetailsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoApInvoicesDetail>("Add Tbl Po Ap Invoices Detail", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail args)
        {
            var result = await DialogService.OpenAsync<EditTblPoApInvoicesDetail>("Edit Tbl Po Ap Invoices Detail", new Dictionary<string, object>() { {"Vendor_ID", args.Vendor_ID}, {"Invoice_No", args.Invoice_No} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoApInvoicesDetailResult = await DbAtVdc2.DeleteTblPoApInvoicesDetail($"{data.Vendor_ID}", $"{data.Invoice_No}");
                if (dbAtVdc2DeleteTblPoApInvoicesDetailResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoApInvoicesDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoApInvoicesDetail");
            }
        }
    }
}
