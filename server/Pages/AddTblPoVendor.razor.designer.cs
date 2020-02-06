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
    public partial class AddTblPoVendorComponent : ComponentBase
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

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBook> _getTblGnAddressBooksResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBook> getTblGnAddressBooksResult
        {
            get
            {
                return _getTblGnAddressBooksResult;
            }
            set
            {
                if(!object.Equals(_getTblGnAddressBooksResult, value))
                {
                    _getTblGnAddressBooksResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        CanErp2.Models.DbAtVdc2.TblPoVendor _tblpovendor;
        protected CanErp2.Models.DbAtVdc2.TblPoVendor tblpovendor
        {
            get
            {
                return _tblpovendor;
            }
            set
            {
                if(!object.Equals(_tblpovendor, value))
                {
                    _tblpovendor = value;
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
            var dbAtVdc2GetTblGnAddressBooksResult = await DbAtVdc2.GetTblGnAddressBooks();
            getTblGnAddressBooksResult = dbAtVdc2GetTblGnAddressBooksResult;

            tblpovendor = new CanErp2.Models.DbAtVdc2.TblPoVendor();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoVendor args)
        {
            try
            {
                var dbAtVdc2CreateTblPoVendorResult = await DbAtVdc2.CreateTblPoVendor(tblpovendor);
                DialogService.Close(tblpovendor);
            }
            catch (Exception dbAtVdc2CreateTblPoVendorException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblPoVendor!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
