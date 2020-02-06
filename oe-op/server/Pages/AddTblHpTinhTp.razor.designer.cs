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
    public partial class AddTblHpTinhTpComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblHpTinhTp _tblhptinhtp;
        protected CanErp2.Models.DbAtVdc2.TblHpTinhTp tblhptinhtp
        {
            get
            {
                return _tblhptinhtp;
            }
            set
            {
                if(!object.Equals(_tblhptinhtp, value))
                {
                    _tblhptinhtp = value;
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
            tblhptinhtp = new CanErp2.Models.DbAtVdc2.TblHpTinhTp();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblHpTinhTp args)
        {
            try
            {
                var dbAtVdc2CreateTblHpTinhTpResult = await DbAtVdc2.CreateTblHpTinhTp(tblhptinhtp);
                DialogService.Close(tblhptinhtp);
            }
            catch (Exception dbAtVdc2CreateTblHpTinhTpException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblHpTinhTp!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
