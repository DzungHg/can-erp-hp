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
    public partial class TblGnIncotermsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblGnIncoterm> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnIncoterm> _getTblGnIncotermsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnIncoterm> getTblGnIncotermsResult
        {
            get
            {
                return _getTblGnIncotermsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnIncotermsResult, value))
                {
                    _getTblGnIncotermsResult = value;
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
            var dbAtVdc2GetTblGnIncotermsResult = await DbAtVdc2.GetTblGnIncoterms();
            getTblGnIncotermsResult = dbAtVdc2GetTblGnIncotermsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblGnIncoterm>("Add Tbl Gn Incoterm", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblGnIncoterm args)
        {
            var result = await DialogService.OpenAsync<EditTblGnIncoterm>("Edit Tbl Gn Incoterm", new Dictionary<string, object>() { {"Incoterm_ID", args.Incoterm_ID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblGnIncotermResult = await DbAtVdc2.DeleteTblGnIncoterm($"{data.Incoterm_ID}");
                if (dbAtVdc2DeleteTblGnIncotermResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblGnIncotermException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblGnIncoterm");
            }
        }
    }
}
