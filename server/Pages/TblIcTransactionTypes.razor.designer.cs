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
    public partial class TblIcTransactionTypesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblIcTransactionType> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcTransactionType> _getTblIcTransactionTypesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcTransactionType> getTblIcTransactionTypesResult
        {
            get
            {
                return _getTblIcTransactionTypesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcTransactionTypesResult, value))
                {
                    _getTblIcTransactionTypesResult = value;
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
            var dbAtVdc2GetTblIcTransactionTypesResult = await DbAtVdc2.GetTblIcTransactionTypes();
            getTblIcTransactionTypesResult = dbAtVdc2GetTblIcTransactionTypesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblIcTransactionType>("Add Tbl Ic Transaction Type", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblIcTransactionType args)
        {
            var result = await DialogService.OpenAsync<EditTblIcTransactionType>("Edit Tbl Ic Transaction Type", new Dictionary<string, object>() { {"Transaction_ID", args.Transaction_ID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblIcTransactionTypeResult = await DbAtVdc2.DeleteTblIcTransactionType($"{data.Transaction_ID}");
                if (dbAtVdc2DeleteTblIcTransactionTypeResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblIcTransactionTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblIcTransactionType");
            }
        }
    }
}
