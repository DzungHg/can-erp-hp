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
    public partial class TblPoVendorsComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblPoVendor> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoVendor> _getTblPoVendorsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoVendor> getTblPoVendorsResult
        {
            get
            {
                return _getTblPoVendorsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoVendorsResult, value))
                {
                    _getTblPoVendorsResult = value;
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
            var dbAtVdc2GetTblPoVendorsResult = await DbAtVdc2.GetTblPoVendors();
            getTblPoVendorsResult = dbAtVdc2GetTblPoVendorsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblPoVendor>("Add Tbl Po Vendor", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblPoVendor args)
        {
            var result = await DialogService.OpenAsync<EditTblPoVendor>("Edit Tbl Po Vendor", new Dictionary<string, object>() { {"Vendor_ID", args.Vendor_ID} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblPoVendorResult = await DbAtVdc2.DeleteTblPoVendor($"{data.Vendor_ID}");
                if (dbAtVdc2DeleteTblPoVendorResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblPoVendorException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblPoVendor");
            }
        }
    }
}
