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
    public partial class AddTblIcWarehouseComponent : ComponentBase
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
            tblicwarehouse = new CanErp2.Models.DbAtVdc2.TblIcWarehouse();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcWarehouse args)
        {
            try
            {
                var dbAtVdc2CreateTblIcWarehouseResult = await DbAtVdc2.CreateTblIcWarehouse(tblicwarehouse);
                DialogService.Close(tblicwarehouse);
            }
            catch (Exception dbAtVdc2CreateTblIcWarehouseException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblIcWarehouse!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
