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
    public partial class AddTblGnAddressBookTypeComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblGnAddressBookType _tblgnaddressbooktype;
        protected CanErp2.Models.DbAtVdc2.TblGnAddressBookType tblgnaddressbooktype
        {
            get
            {
                return _tblgnaddressbooktype;
            }
            set
            {
                if(!object.Equals(_tblgnaddressbooktype, value))
                {
                    _tblgnaddressbooktype = value;
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
            tblgnaddressbooktype = new CanErp2.Models.DbAtVdc2.TblGnAddressBookType();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnAddressBookType args)
        {
            try
            {
                var dbAtVdc2CreateTblGnAddressBookTypeResult = await DbAtVdc2.CreateTblGnAddressBookType(tblgnaddressbooktype);
                DialogService.Close(tblgnaddressbooktype);
            }
            catch (Exception dbAtVdc2CreateTblGnAddressBookTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblGnAddressBookType!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
