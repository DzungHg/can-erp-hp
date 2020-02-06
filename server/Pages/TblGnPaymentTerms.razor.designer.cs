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
    public partial class TblGnPaymentTermsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> _getTblGnPaymentTermsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> getTblGnPaymentTermsResult
        {
            get
            {
                return _getTblGnPaymentTermsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnPaymentTermsResult, value))
                {
                    _getTblGnPaymentTermsResult = value;
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
            var dbAtVdc2GetTblGnPaymentTermsResult = await DbAtVdc2.GetTblGnPaymentTerms();
            getTblGnPaymentTermsResult = dbAtVdc2GetTblGnPaymentTermsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblGnPaymentTerm>("Add Tbl Gn Payment Term", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblGnPaymentTerm args)
        {
            var result = await DialogService.OpenAsync<EditTblGnPaymentTerm>("Edit Tbl Gn Payment Term", new Dictionary<string, object>() { {"PaymentTerm_SEQ", args.PaymentTerm_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblGnPaymentTermResult = await DbAtVdc2.DeleteTblGnPaymentTerm(data.PaymentTerm_SEQ);
                if (dbAtVdc2DeleteTblGnPaymentTermResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblGnPaymentTermException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblGnPaymentTerm");
            }
        }
    }
}
