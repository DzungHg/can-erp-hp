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
    public partial class EditTblIcWarehouseComponent : ComponentBase
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
        public dynamic Warehouse_ID { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblIcWarehouse _tblicwarehouse;
        protected CanErp2.Models.DbAtVdc2.TblIcWarehouse tblicwarehouse
        {
            get
            {
                return _tblicwarehouse;
            }
            set
            {
                if(!object.Equals(_tblicwarehouse, value))
                {
                    _tblicwarehouse = value;
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

            var dbAtVdc2GetTblIcWarehouseByWarehouseIdResult = await DbAtVdc2.GetTblIcWarehouseByWarehouseId($"{Warehouse_ID}");
            tblicwarehouse = dbAtVdc2GetTblIcWarehouseByWarehouseIdResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcWarehouse args)
        {
            try
            {
                var dbAtVdc2UpdateTblIcWarehouseResult = await DbAtVdc2.UpdateTblIcWarehouse($"{Warehouse_ID}", tblicwarehouse);
                DialogService.Close(tblicwarehouse);
            }
            catch (Exception dbAtVdc2UpdateTblIcWarehouseException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblIcWarehouse");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
