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
    public partial class EditTblIcUnitComponent : ComponentBase
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
        public dynamic Unit_SEQ { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblIcUnit _tblicunit;
        protected CanErp2.Models.DbAtVdc2.TblIcUnit tblicunit
        {
            get
            {
                return _tblicunit;
            }
            set
            {
                if(!object.Equals(_tblicunit, value))
                {
                    _tblicunit = value;
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

            var dbAtVdc2GetTblIcUnitByUnitSeqResult = await DbAtVdc2.GetTblIcUnitByUnitSeq(int.Parse($"{Unit_SEQ}"));
            tblicunit = dbAtVdc2GetTblIcUnitByUnitSeqResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcUnit args)
        {
            try
            {
                var dbAtVdc2UpdateTblIcUnitResult = await DbAtVdc2.UpdateTblIcUnit(int.Parse($"{Unit_SEQ}"), tblicunit);
                DialogService.Close(tblicunit);
            }
            catch (Exception dbAtVdc2UpdateTblIcUnitException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblIcUnit");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
