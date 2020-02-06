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
    public partial class EditTblGnPaymentTypeComponent : ComponentBase
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
        public dynamic PaymentType_SEQ { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblGnPaymentType _tblgnpaymenttype;
        protected CanErp2.Models.DbAtVdc2.TblGnPaymentType tblgnpaymenttype
        {
            get
            {
                return _tblgnpaymenttype;
            }
            set
            {
                if(!object.Equals(_tblgnpaymenttype, value))
                {
                    _tblgnpaymenttype = value;
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

            var dbAtVdc2GetTblGnPaymentTypeByPaymentTypeSeqResult = await DbAtVdc2.GetTblGnPaymentTypeByPaymentTypeSeq(int.Parse($"{PaymentType_SEQ}"));
            tblgnpaymenttype = dbAtVdc2GetTblGnPaymentTypeByPaymentTypeSeqResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnPaymentType args)
        {
            try
            {
                var dbAtVdc2UpdateTblGnPaymentTypeResult = await DbAtVdc2.UpdateTblGnPaymentType(int.Parse($"{PaymentType_SEQ}"), tblgnpaymenttype);
                DialogService.Close(tblgnpaymenttype);
            }
            catch (Exception dbAtVdc2UpdateTblGnPaymentTypeException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblGnPaymentType");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
