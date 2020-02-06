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
    public partial class TblGnPaymentTypesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblGnPaymentType> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentType> _getTblGnPaymentTypesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentType> getTblGnPaymentTypesResult
        {
            get
            {
                return _getTblGnPaymentTypesResult;
            }
            set
            {
                if(!object.Equals(_getTblGnPaymentTypesResult, value))
                {
                    _getTblGnPaymentTypesResult = value;
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
            var dbAtVdc2GetTblGnPaymentTypesResult = await DbAtVdc2.GetTblGnPaymentTypes();
            getTblGnPaymentTypesResult = dbAtVdc2GetTblGnPaymentTypesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblGnPaymentType>("Add Tbl Gn Payment Type", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblGnPaymentType args)
        {
            var result = await DialogService.OpenAsync<EditTblGnPaymentType>("Edit Tbl Gn Payment Type", new Dictionary<string, object>() { {"PaymentType_SEQ", args.PaymentType_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblGnPaymentTypeResult = await DbAtVdc2.DeleteTblGnPaymentType(data.PaymentType_SEQ);
                if (dbAtVdc2DeleteTblGnPaymentTypeResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblGnPaymentTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblGnPaymentType");
            }
        }
    }
}
