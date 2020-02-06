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
    public partial class AddTblSoOrderDetailStatusComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus _tblsoorderdetailstatus;
        protected CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus tblsoorderdetailstatus
        {
            get
            {
                return _tblsoorderdetailstatus;
            }
            set
            {
                if(!object.Equals(_tblsoorderdetailstatus, value))
                {
                    _tblsoorderdetailstatus = value;
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
            tblsoorderdetailstatus = new CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus args)
        {
            try
            {
                var dbAtVdc2CreateTblSoOrderDetailStatusResult = await DbAtVdc2.CreateTblSoOrderDetailStatus(tblsoorderdetailstatus);
                DialogService.Close(tblsoorderdetailstatus);
            }
            catch (Exception dbAtVdc2CreateTblSoOrderDetailStatusException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblSoOrderDetailStatus!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
