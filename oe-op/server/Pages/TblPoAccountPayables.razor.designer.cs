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
    public partial class TblPoAccountPayablesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoAccountPayable> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoAccountPayable> _getTblPoAccountPayablesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoAccountPayable> getTblPoAccountPayablesResult
        {
            get
            {
                return _getTblPoAccountPayablesResult;
            }
            set
            {
                if(!object.Equals(_getTblPoAccountPayablesResult, value))
                {
                    _getTblPoAccountPayablesResult = value;
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
            var dbAtVdc2GetTblPoAccountPayablesResult = await DbAtVdc2.GetTblPoAccountPayables();
            getTblPoAccountPayablesResult = dbAtVdc2GetTblPoAccountPayablesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoAccountPayable>("Add Tbl Po Account Payable", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoAccountPayable args)
        {
            var result = await DialogService.OpenAsync<EditTblPoAccountPayable>("Edit Tbl Po Account Payable", new Dictionary<string, object>() { {"AP_No", args.AP_No} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoAccountPayableResult = await DbAtVdc2.DeleteTblPoAccountPayable($"{data.AP_No}");
                if (dbAtVdc2DeleteTblPoAccountPayableResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoAccountPayableException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoAccountPayable");
            }
        }
    }
}
