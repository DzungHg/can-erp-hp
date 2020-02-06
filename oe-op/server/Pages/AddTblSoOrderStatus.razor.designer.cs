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
    public partial class AddTblSoOrderStatusComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblSoOrderStatus _tblsoorderstatus;
        protected CanErp2.Models.DbAtVdc2.TblSoOrderStatus tblsoorderstatus
        {
            get
            {
                return _tblsoorderstatus;
            }
            set
            {
                if(!object.Equals(_tblsoorderstatus, value))
                {
                    _tblsoorderstatus = value;
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
            tblsoorderstatus = new CanErp2.Models.DbAtVdc2.TblSoOrderStatus();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblSoOrderStatus args)
        {
            try
            {
                var dbAtVdc2CreateTblSoOrderStatusResult = await DbAtVdc2.CreateTblSoOrderStatus(tblsoorderstatus);
                DialogService.Close(tblsoorderstatus);
            }
            catch (Exception dbAtVdc2CreateTblSoOrderStatusException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblSoOrderStatus!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
