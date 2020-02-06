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
    public partial class AddTblSoCustomerComponent : ComponentBase
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

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBook> _getTblGnAddressBooksResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnAddressBook> getTblGnAddressBooksResult
        {
            get
            {
                return _getTblGnAddressBooksResult;
            }
            set
            {
                if(!object.Equals(_getTblGnAddressBooksResult, value))
                {
                    _getTblGnAddressBooksResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> _getTblGnPaymentTermsResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentTerm> getTblGnPaymentTermsResult
        {
            get
            {
                return _getTblGnPaymentTermsResult;
            }
            set
            {
                if(!object.Equals(_getTblGnPaymentTermsResult, value))
                {
                    _getTblGnPaymentTermsResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentType> _getTblGnPaymentTypesResult;
        protected IEnumerable<CanErp2.Models.DbAtVdc2.TblGnPaymentType> getTblGnPaymentTypesResult
        {
            get
            {
                return _getTblGnPaymentTypesResult;
            }
            set
            {
                if(!object.Equals(_getTblGnPaymentTypesResult, value))
                {
                    _getTblGnPaymentTypesResult = value;
                    InvokeAsync(() => { StateHasChanged(); });
                }
            }
        }

        CanErp2.Models.DbAtVdc2.TblSoCustomer _tblsocustomer;
        protected CanErp2.Models.DbAtVdc2.TblSoCustomer tblsocustomer
        {
            get
            {
                return _tblsocustomer;
            }
            set
            {
                if(!object.Equals(_tblsocustomer, value))
                {
                    _tblsocustomer = value;
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
            var dbAtVdc2GetTblGnAddressBooksResult = await DbAtVdc2.GetTblGnAddressBooks();
            getTblGnAddressBooksResult = dbAtVdc2GetTblGnAddressBooksResult;

            var dbAtVdc2GetTblGnPaymentTermsResult = await DbAtVdc2.GetTblGnPaymentTerms();
            getTblGnPaymentTermsResult = dbAtVdc2GetTblGnPaymentTermsResult;

            var dbAtVdc2GetTblGnPaymentTypesResult = await DbAtVdc2.GetTblGnPaymentTypes();
            getTblGnPaymentTypesResult = dbAtVdc2GetTblGnPaymentTypesResult;

            tblsocustomer = new CanErp2.Models.DbAtVdc2.TblSoCustomer();
        }

        protected async System.Threading.Tasks.Task Form0Submit(CanErp2.Models.DbAtVdc2.TblSoCustomer args)
        {
            try
            {
                var dbAtVdc2CreateTblSoCustomerResult = await DbAtVdc2.CreateTblSoCustomer(tblsocustomer);
                DialogService.Close(tblsocustomer);
            }
            catch (Exception dbAtVdc2CreateTblSoCustomerException)
            {
                    NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new TblSoCustomer!");
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
