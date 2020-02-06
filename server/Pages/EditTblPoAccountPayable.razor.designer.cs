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
    public partial class EditTblPoAccountPayableComponent : ComponentBase
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
        public dynamic AP_No { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblPoAccountPayable _tblpoaccountpayable;
        protected CanErp2.Models.DbAtVdc2.TblPoAccountPayable tblpoaccountpayable
        {
            get
            {
                return _tblpoaccountpayable;
            }
            set
            {
                if(!object.Equals(_tblpoaccountpayable, value))
                {
                    _tblpoaccountpayable = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

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

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnDepartment> _getTblGnDepartmentsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnDepartment> getTblGnDepartmentsResult
        {
            get
            {
                return _getTblGnDepartmentsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnDepartmentsResult, value))
                {
                    _getTblGnDepartmentsResult = value;
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

            var dbAtVdc2GetTblPoAccountPayableByApNoResult = await DbAtVdc2.GetTblPoAccountPayableByApNo($"{AP_No}");
            tblpoaccountpayable = dbAtVdc2GetTblPoAccountPayableByApNoResult;

            var dbAtVdc2GetTblPoVendorsResult = await DbAtVdc2.GetTblPoVendors();
            getTblPoVendorsResult = dbAtVdc2GetTblPoVendorsResult;

            var dbAtVdc2GetTblGnDepartmentsResult = await DbAtVdc2.GetTblGnDepartments();
            getTblGnDepartmentsResult = dbAtVdc2GetTblGnDepartmentsResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoAccountPayable args)
        {
            try
            {
                var dbAtVdc2UpdateTblPoAccountPayableResult = await DbAtVdc2.UpdateTblPoAccountPayable($"{AP_No}", tblpoaccountpayable);
                DialogService.Close(tblpoaccountpayable);
            }
            catch (Exception dbAtVdc2UpdateTblPoAccountPayableException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblPoAccountPayable");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
