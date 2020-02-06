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
    public partial class AddTblGnProductComponent : ComponentBase
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

        CanErp2.Models.DbAtVdc2.TblGnProduct _tblgnproduct;
        protected CanErp2.Models.DbAtVdc2.TblGnProduct tblgnproduct
        {
            get
            {
                return _tblgnproduct;
            }
            set
            {
                if(!object.Equals(_tblgnproduct, value))
                {
                    _tblgnproduct = value;
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
            tblgnproduct = new CanErp2.Models.DbAtVdc2.TblGnProduct();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblGnProduct args)
        {
            try
            {
                var dbAtVdc2CreateTblGnProductResult = await DbAtVdc2.CreateTblGnProduct(tblgnproduct);
                DialogService.Close(tblgnproduct);
            }
            catch (Exception dbAtVdc2CreateTblGnProductException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblGnProduct!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
