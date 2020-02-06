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
    public partial class AddTblGnPaymentTermComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblGnPaymentTerm _tblgnpaymentterm;
        protected CanErp2.Models.DbAtVdc2.TblGnPaymentTerm tblgnpaymentterm
        {
            get
            {
                return _tblgnpaymentterm;
            }
            set
            {
                if(!object.Equals(_tblgnpaymentterm, value))
                {
                    _tblgnpaymentterm = value;
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
            tblgnpaymentterm = new CanErp2.Models.DbAtVdc2.TblGnPaymentTerm();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnPaymentTerm args)
        {
            try
            {
                var dbAtVdc2CreateTblGnPaymentTermResult = await DbAtVdc2.CreateTblGnPaymentTerm(tblgnpaymentterm);
                DialogService.Close(tblgnpaymentterm);
            }
            catch (Exception dbAtVdc2CreateTblGnPaymentTermException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblGnPaymentTerm!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
