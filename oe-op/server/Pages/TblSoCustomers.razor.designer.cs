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
    public partial class TblSoCustomersComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblSoCustomer> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblSoCustomer> _getTblSoCustomersResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblSoCustomer> getTblSoCustomersResult
        {
            get
            {
                return _getTblSoCustomersResult;
            }
            set
            {
                if(!object.Equals(_getTblSoCustomersResult, value))
                {
                    _getTblSoCustomersResult = value;
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
            var dbAtVdc2GetTblSoCustomersResult = await DbAtVdc2.GetTblSoCustomers();
            getTblSoCustomersResult = dbAtVdc2GetTblSoCustomersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblSoCustomer>("Add Tbl So Customer", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblSoCustomer args)
        {
            var result = await DialogService.OpenAsync<EditTblSoCustomer>("Edit Tbl So Customer", new Dictionary<string, object>() { {"Customer_SEQ", args.Customer_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblSoCustomerResult = await DbAtVdc2.DeleteTblSoCustomer(data.Customer_SEQ);
                if (dbAtVdc2DeleteTblSoCustomerResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblSoCustomerException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblSoCustomer");
            }
        }
    }
}
