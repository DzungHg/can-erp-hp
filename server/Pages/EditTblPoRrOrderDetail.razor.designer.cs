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
    public partial class EditTblPoRrOrderDetailComponent : ComponentBase
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
        public dynamic RR_FK { get; set; }

        [Parameter]
        public dynamic Inventory_FK { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail _tblporrorderdetail;
        protected CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail tblporrorderdetail
        {
            get
            {
                return _tblporrorderdetail;
            }
            set
            {
                if(!object.Equals(_tblporrorderdetail, value))
                {
                    _tblporrorderdetail = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblPoRecReport> _getTblPoRecReportsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblPoRecReport> getTblPoRecReportsResult
        {
            get
            {
                return _getTblPoRecReportsResult;
            }
            set
            {
                if(!object.Equals(_getTblPoRecReportsResult, value))
                {
                    _getTblPoRecReportsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcInventory> _getTblIcInventoriesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcInventory> getTblIcInventoriesResult
        {
            get
            {
                return _getTblIcInventoriesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcInventoriesResult, value))
                {
                    _getTblIcInventoriesResult = value;
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

            var dbAtVdc2GetTblPoRrOrderDetailByRrFkAndInventoryFkResult = await DbAtVdc2.GetTblPoRrOrderDetailByRrFkAndInventoryFk($"{RR_FK}", int.Parse($"{Inventory_FK}"));
            tblporrorderdetail = dbAtVdc2GetTblPoRrOrderDetailByRrFkAndInventoryFkResult;

            var dbAtVdc2GetTblPoRecReportsResult = await DbAtVdc2.GetTblPoRecReports();
            getTblPoRecReportsResult = dbAtVdc2GetTblPoRecReportsResult;

            var dbAtVdc2GetTblIcInventoriesResult = await DbAtVdc2.GetTblIcInventories();
            getTblIcInventoriesResult = dbAtVdc2GetTblIcInventoriesResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail args)
        {
            try
            {
                var dbAtVdc2UpdateTblPoRrOrderDetailResult = await DbAtVdc2.UpdateTblPoRrOrderDetail($"{RR_FK}", int.Parse($"{Inventory_FK}"), tblporrorderdetail);
                DialogService.Close(tblporrorderdetail);
            }
            catch (Exception dbAtVdc2UpdateTblPoRrOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblPoRrOrderDetail");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
