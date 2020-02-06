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
    public partial class EditTblGnPaymentTermComponent : ComponentBase
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
        public dynamic PaymentTerm_SEQ { get; set; }

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
            canEdit = true;

            var dbAtVdc2GetTblGnPaymentTermByPaymentTermSeqResult = await DbAtVdc2.GetTblGnPaymentTermByPaymentTermSeq(int.Parse($"{PaymentTerm_SEQ}"));
            tblgnpaymentterm = dbAtVdc2GetTblGnPaymentTermByPaymentTermSeqResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnPaymentTerm args)
        {
            try
            {
                var dbAtVdc2UpdateTblGnPaymentTermResult = await DbAtVdc2.UpdateTblGnPaymentTerm(int.Parse($"{PaymentTerm_SEQ}"), tblgnpaymentterm);
                DialogService.Close(tblgnpaymentterm);
            }
            catch (Exception dbAtVdc2UpdateTblGnPaymentTermException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblGnPaymentTerm");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
