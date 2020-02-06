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
    public partial class EditTblPoOrderStatusComponent : ComponentBase
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
        public dynamic POStatus_ID { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblPoOrderStatus _tblpoorderstatus;
        protected CanErp2.Models.DbAtVdc2.TblPoOrderStatus tblpoorderstatus
        {
            get
            {
                return _tblpoorderstatus;
            }
            set
            {
                if(!object.Equals(_tblpoorderstatus, value))
                {
                    _tblpoorderstatus = value;
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

            var dbAtVdc2GetTblPoOrderStatusByPoStatusIdResult = await DbAtVdc2.GetTblPoOrderStatusByPoStatusId($"{POStatus_ID}");
            tblpoorderstatus = dbAtVdc2GetTblPoOrderStatusByPoStatusIdResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblPoOrderStatus args)
        {
            try
            {
                var dbAtVdc2UpdateTblPoOrderStatusResult = await DbAtVdc2.UpdateTblPoOrderStatus($"{POStatus_ID}", tblpoorderstatus);
                DialogService.Close(tblpoorderstatus);
            }
            catch (Exception dbAtVdc2UpdateTblPoOrderStatusException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblPoOrderStatus");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
