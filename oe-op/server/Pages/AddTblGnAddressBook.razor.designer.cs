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
    public partial class AddTblGnAddressBookComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblGnAddressBook _tblgnaddressbook;
        protected CanErp2.Models.DbAtVdc2.TblGnAddressBook tblgnaddressbook
        {
            get
            {
                return _tblgnaddressbook;
            }
            set
            {
                if(!object.Equals(_tblgnaddressbook, value))
                {
                    _tblgnaddressbook = value;
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

            var dbAtVdc2GetTblGnGendersResult = await DbAtVdc2.GetTblGnGenders();
            getTblGnGendersResult = dbAtVdc2GetTblGnGendersResult;

            var dbAtVdc2GetTblHpTinhTpsResult = await DbAtVdc2.GetTblHpTinhTps();
            getTblHpTinhTpsResult = dbAtVdc2GetTblHpTinhTpsResult;

            tblgnaddressbook = new CanErp2.Models.DbAtVdc2.TblGnAddressBook();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnAddressBook args)
        {
            try
            {
                var dbAtVdc2CreateTblGnAddressBookResult = await DbAtVdc2.CreateTblGnAddressBook(tblgnaddressbook);
                DialogService.Close(tblgnaddressbook);
            }
            catch (Exception dbAtVdc2CreateTblGnAddressBookException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblGnAddressBook!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
