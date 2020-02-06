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
    public partial class AddTblPoAccountsPayableAdjustmentComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment _tblpoaccountspayableadjustment;
        protected CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment tblpoaccountspayableadjustment
        {
            get
            {
                return _tblpoaccountspayableadjustment;
            }
            set
            {
                if(!object.Equals(_tblpoaccountspayableadjustment, value))
                {
                    _tblpoaccountspayableadjustment = value;
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
            tblpoaccountspayableadjustment = new CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoAccountsPayableAdjustment args)
        {
            try
            {
                var dbAtVdc2CreateTblPoAccountsPayableAdjustmentResult = await DbAtVdc2.CreateTblPoAccountsPayableAdjustment(tblpoaccountspayableadjustment);
                DialogService.Close(tblpoaccountspayableadjustment);
            }
            catch (Exception dbAtVdc2CreateTblPoAccountsPayableAdjustmentException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblPoAccountsPayableAdjustment!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
