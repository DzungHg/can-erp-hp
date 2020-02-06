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
    public partial class EditTblSoOrderDetailStatusComponent : ComponentBase
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
        public dynamic SODetailStatus_SEQ { get; set; }

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
            canEdit = true;

            var dbAtVdc2GetTblSoOrderDetailStatusBySoDetailStatusSeqResult = await DbAtVdc2.GetTblSoOrderDetailStatusBySoDetailStatusSeq(int.Parse($"{SODetailStatus_SEQ}"));
            tblsoorderdetailstatus = dbAtVdc2GetTblSoOrderDetailStatusBySoDetailStatusSeqResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblSoOrderDetailStatus args)
        {
            try
            {
                var dbAtVdc2UpdateTblSoOrderDetailStatusResult = await DbAtVdc2.UpdateTblSoOrderDetailStatus(int.Parse($"{SODetailStatus_SEQ}"), tblsoorderdetailstatus);
                DialogService.Close(tblsoorderdetailstatus);
            }
            catch (Exception dbAtVdc2UpdateTblSoOrderDetailStatusException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblSoOrderDetailStatus");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
