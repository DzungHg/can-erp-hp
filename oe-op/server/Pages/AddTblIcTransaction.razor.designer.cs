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
    public partial class AddTblIcTransactionComponent : ComponentBase
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

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcTransactionType> _getTblIcTransactionTypesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcTransactionType> getTblIcTransactionTypesResult
        {
            get
            {
                return _getTblIcTransactionTypesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcTransactionTypesResult, value))
                {
                    _getTblIcTransactionTypesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcWarehouse> _getTblIcWarehousesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcWarehouse> getTblIcWarehousesResult
        {
            get
            {
                return _getTblIcWarehousesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcWarehousesResult, value))
                {
                    _getTblIcWarehousesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnProduct> _getTblGnProductsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnProduct> getTblGnProductsResult
        {
            get
            {
                return _getTblGnProductsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnProductsResult, value))
                {
                    _getTblGnProductsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        CanErp2.Models.DbAtVdc2.TblIcTransaction _tblictransaction;
        protected CanErp2.Models.DbAtVdc2.TblIcTransaction tblictransaction
        {
            get
            {
                return _tblictransaction;
            }
            set
            {
                if(!object.Equals(_tblictransaction, value))
                {
                    _tblictransaction = value;
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
            var dbAtVdc2GetTblIcTransactionTypesResult = await DbAtVdc2.GetTblIcTransactionTypes();
            getTblIcTransactionTypesResult = dbAtVdc2GetTblIcTransactionTypesResult;

            var dbAtVdc2GetTblIcWarehousesResult = await DbAtVdc2.GetTblIcWarehouses();
            getTblIcWarehousesResult = dbAtVdc2GetTblIcWarehousesResult;

            var dbAtVdc2GetTblGnProductsResult = await DbAtVdc2.GetTblGnProducts();
            getTblGnProductsResult = dbAtVdc2GetTblGnProductsResult;

            tblictransaction = new CanErp2.Models.DbAtVdc2.TblIcTransaction();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcTransaction args)
        {
            try
            {
                var dbAtVdc2CreateTblIcTransactionResult = await DbAtVdc2.CreateTblIcTransaction(tblictransaction);
                DialogService.Close(tblictransaction);
            }
            catch (Exception dbAtVdc2CreateTblIcTransactionException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblIcTransaction!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
