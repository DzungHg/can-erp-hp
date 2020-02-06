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
    public partial class EditTblIcTransactionComponent : ComponentBase
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
        public dynamic Trans_No { get; set; }

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            canEdit = true;

            var dbAtVdc2GetTblIcTransactionByTransNoResult = await DbAtVdc2.GetTblIcTransactionByTransNo($"{Trans_No}");
            tblictransaction = dbAtVdc2GetTblIcTransactionByTransNoResult;

            var dbAtVdc2GetTblIcTransactionTypesResult = await DbAtVdc2.GetTblIcTransactionTypes();
            getTblIcTransactionTypesResult = dbAtVdc2GetTblIcTransactionTypesResult;

            var dbAtVdc2GetTblIcWarehousesResult = await DbAtVdc2.GetTblIcWarehouses();
            getTblIcWarehousesResult = dbAtVdc2GetTblIcWarehousesResult;

            var dbAtVdc2GetTblGnProductsResult = await DbAtVdc2.GetTblGnProducts();
            getTblGnProductsResult = dbAtVdc2GetTblGnProductsResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcTransaction args)
        {
            try
            {
                var dbAtVdc2UpdateTblIcTransactionResult = await DbAtVdc2.UpdateTblIcTransaction($"{Trans_No}", tblictransaction);
                DialogService.Close(tblictransaction);
            }
            catch (Exception dbAtVdc2UpdateTblIcTransactionException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblIcTransaction");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
