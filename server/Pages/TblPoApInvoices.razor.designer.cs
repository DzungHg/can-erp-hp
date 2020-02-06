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
    public partial class TblPoApInvoicesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoApInvoice> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoApInvoice> _getTblPoApInvoicesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoApInvoice> getTblPoApInvoicesResult
        {
            get
            {
                return _getTblPoApInvoicesResult;
            }
            set
            {
                if(!object.Equals(_getTblPoApInvoicesResult, value))
                {
                    _getTblPoApInvoicesResult = value;
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
            var dbAtVdc2GetTblPoApInvoicesResult = await DbAtVdc2.GetTblPoApInvoices();
            getTblPoApInvoicesResult = dbAtVdc2GetTblPoApInvoicesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoApInvoice>("Add Tbl Po Ap Invoice", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoApInvoice args)
        {
            var result = await DialogService.OpenAsync<EditTblPoApInvoice>("Edit Tbl Po Ap Invoice", new Dictionary<string, object>() { {"Vendor_ID", args.Vendor_ID}, {"Invoice_No", args.Invoice_No} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoApInvoiceResult = await DbAtVdc2.DeleteTblPoApInvoice($"{data.Vendor_ID}", $"{data.Invoice_No}");
                if (dbAtVdc2DeleteTblPoApInvoiceResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoApInvoiceException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoApInvoice");
            }
        }
    }
}
