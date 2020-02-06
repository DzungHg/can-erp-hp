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
    public partial class EditTblIcClassificationComponent : ComponentBase
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
        public dynamic Classifi_ID { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblIcClassification _tblicclassification;
        protected CanErp2.Models.DbAtVdc2.TblIcClassification tblicclassification
        {
            get
            {
                return _tblicclassification;
            }
            set
            {
                if(!object.Equals(_tblicclassification, value))
                {
                    _tblicclassification = value;
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

            var dbAtVdc2GetTblIcClassificationByClassifiIdResult = await DbAtVdc2.GetTblIcClassificationByClassifiId($"{Classifi_ID}");
            tblicclassification = dbAtVdc2GetTblIcClassificationByClassifiIdResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcClassification args)
        {
            try
            {
                var dbAtVdc2UpdateTblIcClassificationResult = await DbAtVdc2.UpdateTblIcClassification($"{Classifi_ID}", tblicclassification);
                DialogService.Close(tblicclassification);
            }
            catch (Exception dbAtVdc2UpdateTblIcClassificationException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblIcClassification");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
