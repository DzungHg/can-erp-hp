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
    public partial class TblGnGendersComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblGnGender> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnGender> _getTblGnGendersResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnGender> getTblGnGendersResult
        {
            get
            {
                return _getTblGnGendersResult;
            }
            set
            {
                if(!object.Equals(_getTblGnGendersResult, value))
                {
                    _getTblGnGendersResult = value;
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
            var dbAtVdc2GetTblGnGendersResult = await DbAtVdc2.GetTblGnGenders();
            getTblGnGendersResult = dbAtVdc2GetTblGnGendersResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblGnGender>("Add Tbl Gn Gender", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblGnGender args)
        {
            var result = await DialogService.OpenAsync<EditTblGnGender>("Edit Tbl Gn Gender", new Dictionary<string, object>() { {"Gender_SEQ", args.Gender_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblGnGenderResult = await DbAtVdc2.DeleteTblGnGender(data.Gender_SEQ);
                if (dbAtVdc2DeleteTblGnGenderResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblGnGenderException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblGnGender");
            }
        }
    }
}
