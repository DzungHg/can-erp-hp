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
    public partial class TblGnAddressBookTypesComponent : ComponentBase
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

        protected RadzenGrid<CanErp2.Models.DbAtVdc2.TblGnAddressBookType> grid0;

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBookType> _getTblGnAddressBookTypesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBookType> getTblGnAddressBookTypesResult
        {
            get
            {
                return _getTblGnAddressBookTypesResult;
            }
            set
            {
                if(!object.Equals(_getTblGnAddressBookTypesResult, value))
                {
                    _getTblGnAddressBookTypesResult = value;
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
            var dbAtVdc2GetTblGnAddressBookTypesResult = await DbAtVdc2.GetTblGnAddressBookTypes();
            getTblGnAddressBookTypesResult = dbAtVdc2GetTblGnAddressBookTypesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var result = await DialogService.OpenAsync<AddTblGnAddressBookType>("Add Tbl Gn Address Book Type", null);
              grid0.Reload();

              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(CanErp2.Models.DbAtVdc2.TblGnAddressBookType args)
        {
            var result = await DialogService.OpenAsync<EditTblGnAddressBookType>("Edit Tbl Gn Address Book Type", new Dictionary<string, object>() { {"AddressBookType_SEQ", args.AddressBookType_SEQ} });
              await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                var dbAtVdc2DeleteTblGnAddressBookTypeResult = await DbAtVdc2.DeleteTblGnAddressBookType(data.AddressBookType_SEQ);
                if (dbAtVdc2DeleteTblGnAddressBookTypeResult != null) {
                    grid0.Reload();
}
            }
            catch (Exception dbAtVdc2DeleteTblGnAddressBookTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to delete TblGnAddressBookType");
            }
        }
    }
}
