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
    public partial class EditTblGnDepartmentComponent : ComponentBase
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
        public dynamic Department_ID { get; set; }

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

        CanErp2.Models.DbAtVdc2.TblGnDepartment _tblgndepartment;
        protected CanErp2.Models.DbAtVdc2.TblGnDepartment tblgndepartment
        {
            get
            {
                return _tblgndepartment;
            }
            set
            {
                if(!object.Equals(_tblgndepartment, value))
                {
                    _tblgndepartment = value;
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

            var dbAtVdc2GetTblGnDepartmentByDepartmentIdResult = await DbAtVdc2.GetTblGnDepartmentByDepartmentId($"{Department_ID}");
            tblgndepartment = dbAtVdc2GetTblGnDepartmentByDepartmentIdResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnDepartment args)
        {
            try
            {
                var dbAtVdc2UpdateTblGnDepartmentResult = await DbAtVdc2.UpdateTblGnDepartment($"{Department_ID}", tblgndepartment);
                DialogService.Close(tblgndepartment);
            }
            catch (Exception dbAtVdc2UpdateTblGnDepartmentException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to update TblGnDepartment");
            }
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
