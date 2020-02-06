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
    public partial class AddTblIcCategoryComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblIcCategory _tbliccategory;
        protected CanErp2.Models.DbAtVdc2.TblIcCategory tbliccategory
        {
            get
            {
                return _tbliccategory;
            }
            set
            {
                if(!object.Equals(_tbliccategory, value))
                {
                    _tbliccategory = value;
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
            tbliccategory = new CanErp2.Models.DbAtVdc2.TblIcCategory();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblIcCategory args)
        {
            try
            {
                var dbAtVdc2CreateTblIcCategoryResult = await DbAtVdc2.CreateTblIcCategory(tbliccategory);
                DialogService.Close(tbliccategory);
            }
            catch (Exception dbAtVdc2CreateTblIcCategoryException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblIcCategory!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
