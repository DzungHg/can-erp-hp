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
    public partial class AddTblPoRrOrderDetailComponent : ComponentBase
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var dbAtVdc2GetTblPoRecReportsResult = await DbAtVdc2.GetTblPoRecReports();
            getTblPoRecReportsResult = dbAtVdc2GetTblPoRecReportsResult;

            var dbAtVdc2GetTblIcInventoriesResult = await DbAtVdc2.GetTblIcInventories();
            getTblIcInventoriesResult = dbAtVdc2GetTblIcInventoriesResult;

            tblporrorderdetail = new CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoRrOrderDetail args)
        {
            try
            {
                var dbAtVdc2CreateTblPoRrOrderDetailResult = await DbAtVdc2.CreateTblPoRrOrderDetail(tblporrorderdetail);
                DialogService.Close(tblporrorderdetail);
            }
            catch (Exception dbAtVdc2CreateTblPoRrOrderDetailException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblPoRrOrderDetail!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
