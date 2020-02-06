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
    public partial class TblIcClassificationsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblIcClassification> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcClassification> _getTblIcClassificationsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcClassification> getTblIcClassificationsResult
        {
            get
            {
                return _getTblIcClassificationsResult;
            }
            set
            {
                if(!object.Equals(_getTblIcClassificationsResult, value))
                {
                    _getTblIcClassificationsResult = value;
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
            var dbAtVdc2GetTblIcClassificationsResult = await DbAtVdc2.GetTblIcClassifications();
            getTblIcClassificationsResult = dbAtVdc2GetTblIcClassificationsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblIcClassification>("Add Tbl Ic Classification", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblIcClassification args)
        {
            var result = await DialogService.OpenAsync<EditTblIcClassification>("Edit Tbl Ic Classification", new Dictionary<string, object>() { {"Classifi_ID", args.Classifi_ID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblIcClassificationResult = await DbAtVdc2.DeleteTblIcClassification($"{data.Classifi_ID}");
                if (dbAtVdc2DeleteTblIcClassificationResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblIcClassificationException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblIcClassification");
            }
        }
    }
}
