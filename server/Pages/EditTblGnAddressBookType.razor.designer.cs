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
    public partial class EditTblGnAddressBookTypeComponent : ComponentBase
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

        [Parameter]
        public dynamic AddressBookType_SEQ { get; set; }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if(!object.Equals(_canEdit, value))
                {
                    _canEdit = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

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
            canEdit = true;

            var dbAtVdc2GetTblGnAddressBookTypeByAddressBookTypeSeqResult = await DbAtVdc2.GetTblGnAddressBookTypeByAddressBookTypeSeq(int.Parse($"{AddressBookType_SEQ}"));
            tblgnaddressbooktype = dbAtVdc2GetTblGnAddressBookTypeByAddressBookTypeSeqResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnAddressBookType args)
        {
            try
            {
                var dbAtVdc2UpdateTblGnAddressBookTypeResult = await DbAtVdc2.UpdateTblGnAddressBookType(int.Parse($"{AddressBookType_SEQ}"), tblgnaddressbooktype);
                DialogService.Close(tblgnaddressbooktype);
            }
            catch (Exception dbAtVdc2UpdateTblGnAddressBookTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblGnAddressBookType");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
