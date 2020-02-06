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
    public partial class AddTblPoApInvoicesDetailComponent : ComponentBase
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

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcUnit> _getTblIcUnitsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcUnit> getTblIcUnitsResult
        {
            get
            {
                return _getTblIcUnitsResult;
            }
            set
            {
                if(!object.Equals(_getTblIcUnitsResult, value))
                {
                    _getTblIcUnitsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail _tblpoapinvoicesdetail;
        protected CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail tblpoapinvoicesdetail
        {
            get
            {
                return _tblpoapinvoicesdetail;
            }
            set
            {
                if(!object.Equals(_tblpoapinvoicesdetail, value))
                {
                    _tblpoapinvoicesdetail = value;
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

            var dbAtVdc2GetTblIcInventoriesResult = await DbAtVdc2.GetTblIcInventories();
            getTblIcInventoriesResult = dbAtVdc2GetTblIcInventoriesResult;

            var dbAtVdc2GetTblIcUnitsResult = await DbAtVdc2.GetTblIcUnits();
            getTblIcUnitsResult = dbAtVdc2GetTblIcUnitsResult;

            tblpoapinvoicesdetail = new CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoApInvoicesDetail args)
        {
            try
            {
                var dbAtVdc2CreateTblPoApInvoicesDetailResult = await DbAtVdc2.CreateTblPoApInvoicesDetail(tblpoapinvoicesdetail);
                DialogService.Close(tblpoapinvoicesdetail);
            }
            catch (Exception dbAtVdc2CreateTblPoApInvoicesDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblPoApInvoicesDetail!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
