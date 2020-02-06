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
    public partial class TblHpTinhTpsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblHpTinhTp> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblHpTinhTp> _getTblHpTinhTpsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblHpTinhTp> getTblHpTinhTpsResult
        {
            get
            {
                return _getTblHpTinhTpsResult;
            }
            set
            {
                if(!object.Equals(_getTblHpTinhTpsResult, value))
                {
                    _getTblHpTinhTpsResult = value;
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
            var dbAtVdc2GetTblHpTinhTpsResult = await DbAtVdc2.GetTblHpTinhTps();
            getTblHpTinhTpsResult = dbAtVdc2GetTblHpTinhTpsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblHpTinhTp>("Add Tbl Hp Tinh Tp", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblHpTinhTp args)
        {
            var result = await DialogService.OpenAsync<EditTblHpTinhTp>("Edit Tbl Hp Tinh Tp", new Dictionary<string, object>() { {"TinhTP_ID", args.TinhTP_ID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblHpTinhTpResult = await DbAtVdc2.DeleteTblHpTinhTp($"{data.TinhTP_ID}");
                if (dbAtVdc2DeleteTblHpTinhTpResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblHpTinhTpException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblHpTinhTp");
            }
        }
    }
}
