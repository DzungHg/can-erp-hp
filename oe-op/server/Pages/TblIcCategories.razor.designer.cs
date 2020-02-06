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
    public partial class TblIcCategoriesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblIcCategory> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcCategory> _getTblIcCategoriesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcCategory> getTblIcCategoriesResult
        {
            get
            {
                return _getTblIcCategoriesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcCategoriesResult, value))
                {
                    _getTblIcCategoriesResult = value;
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
            var dbAtVdc2GetTblIcCategoriesResult = await DbAtVdc2.GetTblIcCategories();
            getTblIcCategoriesResult = dbAtVdc2GetTblIcCategoriesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblIcCategory>("Add Tbl Ic Category", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblIcCategory args)
        {
            var result = await DialogService.OpenAsync<EditTblIcCategory>("Edit Tbl Ic Category", new Dictionary<string, object>() { {"Category_ID", args.Category_ID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblIcCategoryResult = await DbAtVdc2.DeleteTblIcCategory($"{data.Category_ID}");
                if (dbAtVdc2DeleteTblIcCategoryResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblIcCategoryException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblIcCategory");
            }
        }
    }
}
