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
    public partial class EditTblIcInventoryComponent : ComponentBase
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
        public dynamic Inventory_SEQ { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblIcInventory _tblicinventory;
        protected CanErp2.Models.DbAtVdc2.TblIcInventory tblicinventory
        {
            get
            {
                return _tblicinventory;
            }
            set
            {
                if(!object.Equals(_tblicinventory, value))
                {
                    _tblicinventory = value;
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

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcCategory> _getTblIcCategoriesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcCategory> getTblIcCategoriesResult
        {
            get
            {
                return _getTblIcCategoriesResult;
            }
            set
            {
                if(!object.Equals(_getTblIcCategoriesResult, value))
                {
                    _getTblIcCategoriesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblIcClassification> _getTblIcClassificationsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblIcClassification> getTblIcClassificationsResult
        {
            get
            {
                return _getTblIcClassificationsResult;
            }
            set
            {
                if(!object.Equals(_getTblIcClassificationsResult, value))
                {
                    _getTblIcClassificationsResult = value;
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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            canEdit = true;

            var dbAtVdc2GetTblIcInventoryByInventorySeqResult = await DbAtVdc2.GetTblIcInventoryByInventorySeq(int.Parse($"{Inventory_SEQ}"));
            tblicinventory = dbAtVdc2GetTblIcInventoryByInventorySeqResult;

            var dbAtVdc2GetTblIcWarehousesResult = await DbAtVdc2.GetTblIcWarehouses();
            getTblIcWarehousesResult = dbAtVdc2GetTblIcWarehousesResult;

            var dbAtVdc2GetTblIcCategoriesResult = await DbAtVdc2.GetTblIcCategories();
            getTblIcCategoriesResult = dbAtVdc2GetTblIcCategoriesResult;

            var dbAtVdc2GetTblIcClassificationsResult = await DbAtVdc2.GetTblIcClassifications();
            getTblIcClassificationsResult = dbAtVdc2GetTblIcClassificationsResult;

            var dbAtVdc2GetTblGnProductsResult = await DbAtVdc2.GetTblGnProducts();
            getTblGnProductsResult = dbAtVdc2GetTblGnProductsResult;

            var dbAtVdc2GetTblIcUnitsResult = await DbAtVdc2.GetTblIcUnits();
            getTblIcUnitsResult = dbAtVdc2GetTblIcUnitsResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcInventory args)
        {
            try
            {
                var dbAtVdc2UpdateTblIcInventoryResult = await DbAtVdc2.UpdateTblIcInventory(int.Parse($"{Inventory_SEQ}"), tblicinventory);
                DialogService.Close(tblicinventory);
            }
            catch (Exception dbAtVdc2UpdateTblIcInventoryException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblIcInventory");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
