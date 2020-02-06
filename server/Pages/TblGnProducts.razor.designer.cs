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
    public partial class TblGnProductsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblGnProduct> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnProduct> _getTblGnProductsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnProduct> getTblGnProductsResult
        {
            get
            {
                return _getTblGnProductsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnProductsResult, value))
                {
                    _getTblGnProductsResult = value;
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
            var dbAtVdc2GetTblGnProductsResult = await DbAtVdc2.GetTblGnProducts();
            getTblGnProductsResult = dbAtVdc2GetTblGnProductsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblGnProduct>("Add Tbl Gn Product", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblGnProduct args)
        {
            var result = await DialogService.OpenAsync<EditTblGnProduct>("Edit Tbl Gn Product", new Dictionary<string, object>() { {"Product_SEQ", args.Product_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblGnProductResult = await DbAtVdc2.DeleteTblGnProduct(data.Product_SEQ);
                if (dbAtVdc2DeleteTblGnProductResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblGnProductException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblGnProduct");
            }
        }
    }
}
