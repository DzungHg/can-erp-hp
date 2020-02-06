using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using CanErp2.Data;

namespace CanErp2
{
    public partial class DbAtVdc2Service
    {
        private readonly DbAtVdc2Context context;
        private readonly NavigationManager navigationManager;

        public DbAtVdc2Service(DbAtVdc2Context context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public async Task ExportTblGnAddressBooksToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnaddressbooks/excel") : "export/dbatvdc2/tblgnaddressbooks/excel", true);
        }

        public async Task ExportTblGnAddressBooksToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnaddressbooks/csv") : "export/dbatvdc2/tblgnaddressbooks/csv", true);
        }

        partial void OnTblGnAddressBooksRead(ref IQueryable<Models.DbAtVdc2.TblGnAddressBook> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnAddressBook>> GetTblGnAddressBooks(Query query = null)
        {
            var items = context.TblGnAddressBooks.AsQueryable();

            items = items.Include(i => i.TblGnAddressBookType);

            items = items.Include(i => i.TblGnGender);

            items = items.Include(i => i.TblHpTinhTp);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnAddressBooksRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnAddressBookCreated(Models.DbAtVdc2.TblGnAddressBook item);

        public async Task<Models.DbAtVdc2.TblGnAddressBook> CreateTblGnAddressBook(Models.DbAtVdc2.TblGnAddressBook tblGnAddressBook)
        {
            OnTblGnAddressBookCreated(tblGnAddressBook);

            context.TblGnAddressBooks.Add(tblGnAddressBook);
            context.SaveChanges();

            return tblGnAddressBook;
        }
        public async Task ExportTblGnAddressBookTypesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnaddressbooktypes/excel") : "export/dbatvdc2/tblgnaddressbooktypes/excel", true);
        }

        public async Task ExportTblGnAddressBookTypesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnaddressbooktypes/csv") : "export/dbatvdc2/tblgnaddressbooktypes/csv", true);
        }

        partial void OnTblGnAddressBookTypesRead(ref IQueryable<Models.DbAtVdc2.TblGnAddressBookType> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnAddressBookType>> GetTblGnAddressBookTypes(Query query = null)
        {
            var items = context.TblGnAddressBookTypes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnAddressBookTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnAddressBookTypeCreated(Models.DbAtVdc2.TblGnAddressBookType item);

        public async Task<Models.DbAtVdc2.TblGnAddressBookType> CreateTblGnAddressBookType(Models.DbAtVdc2.TblGnAddressBookType tblGnAddressBookType)
        {
            OnTblGnAddressBookTypeCreated(tblGnAddressBookType);

            context.TblGnAddressBookTypes.Add(tblGnAddressBookType);
            context.SaveChanges();

            return tblGnAddressBookType;
        }
        public async Task ExportTblGnDepartmentsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgndepartments/excel") : "export/dbatvdc2/tblgndepartments/excel", true);
        }

        public async Task ExportTblGnDepartmentsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgndepartments/csv") : "export/dbatvdc2/tblgndepartments/csv", true);
        }

        partial void OnTblGnDepartmentsRead(ref IQueryable<Models.DbAtVdc2.TblGnDepartment> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnDepartment>> GetTblGnDepartments(Query query = null)
        {
            var items = context.TblGnDepartments.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnDepartmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnDepartmentCreated(Models.DbAtVdc2.TblGnDepartment item);

        public async Task<Models.DbAtVdc2.TblGnDepartment> CreateTblGnDepartment(Models.DbAtVdc2.TblGnDepartment tblGnDepartment)
        {
            OnTblGnDepartmentCreated(tblGnDepartment);

            context.TblGnDepartments.Add(tblGnDepartment);
            context.SaveChanges();

            return tblGnDepartment;
        }
        public async Task ExportTblGnGendersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgngenders/excel") : "export/dbatvdc2/tblgngenders/excel", true);
        }

        public async Task ExportTblGnGendersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgngenders/csv") : "export/dbatvdc2/tblgngenders/csv", true);
        }

        partial void OnTblGnGendersRead(ref IQueryable<Models.DbAtVdc2.TblGnGender> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnGender>> GetTblGnGenders(Query query = null)
        {
            var items = context.TblGnGenders.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnGendersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnGenderCreated(Models.DbAtVdc2.TblGnGender item);

        public async Task<Models.DbAtVdc2.TblGnGender> CreateTblGnGender(Models.DbAtVdc2.TblGnGender tblGnGender)
        {
            OnTblGnGenderCreated(tblGnGender);

            context.TblGnGenders.Add(tblGnGender);
            context.SaveChanges();

            return tblGnGender;
        }
        public async Task ExportTblGnIncotermsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnincoterms/excel") : "export/dbatvdc2/tblgnincoterms/excel", true);
        }

        public async Task ExportTblGnIncotermsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnincoterms/csv") : "export/dbatvdc2/tblgnincoterms/csv", true);
        }

        partial void OnTblGnIncotermsRead(ref IQueryable<Models.DbAtVdc2.TblGnIncoterm> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnIncoterm>> GetTblGnIncoterms(Query query = null)
        {
            var items = context.TblGnIncoterms.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnIncotermsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnIncotermCreated(Models.DbAtVdc2.TblGnIncoterm item);

        public async Task<Models.DbAtVdc2.TblGnIncoterm> CreateTblGnIncoterm(Models.DbAtVdc2.TblGnIncoterm tblGnIncoterm)
        {
            OnTblGnIncotermCreated(tblGnIncoterm);

            context.TblGnIncoterms.Add(tblGnIncoterm);
            context.SaveChanges();

            return tblGnIncoterm;
        }
        public async Task ExportTblGnPaymentTermsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnpaymentterms/excel") : "export/dbatvdc2/tblgnpaymentterms/excel", true);
        }

        public async Task ExportTblGnPaymentTermsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnpaymentterms/csv") : "export/dbatvdc2/tblgnpaymentterms/csv", true);
        }

        partial void OnTblGnPaymentTermsRead(ref IQueryable<Models.DbAtVdc2.TblGnPaymentTerm> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnPaymentTerm>> GetTblGnPaymentTerms(Query query = null)
        {
            var items = context.TblGnPaymentTerms.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnPaymentTermsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnPaymentTermCreated(Models.DbAtVdc2.TblGnPaymentTerm item);

        public async Task<Models.DbAtVdc2.TblGnPaymentTerm> CreateTblGnPaymentTerm(Models.DbAtVdc2.TblGnPaymentTerm tblGnPaymentTerm)
        {
            OnTblGnPaymentTermCreated(tblGnPaymentTerm);

            context.TblGnPaymentTerms.Add(tblGnPaymentTerm);
            context.SaveChanges();

            return tblGnPaymentTerm;
        }
        public async Task ExportTblGnPaymentTypesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnpaymenttypes/excel") : "export/dbatvdc2/tblgnpaymenttypes/excel", true);
        }

        public async Task ExportTblGnPaymentTypesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnpaymenttypes/csv") : "export/dbatvdc2/tblgnpaymenttypes/csv", true);
        }

        partial void OnTblGnPaymentTypesRead(ref IQueryable<Models.DbAtVdc2.TblGnPaymentType> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnPaymentType>> GetTblGnPaymentTypes(Query query = null)
        {
            var items = context.TblGnPaymentTypes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnPaymentTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnPaymentTypeCreated(Models.DbAtVdc2.TblGnPaymentType item);

        public async Task<Models.DbAtVdc2.TblGnPaymentType> CreateTblGnPaymentType(Models.DbAtVdc2.TblGnPaymentType tblGnPaymentType)
        {
            OnTblGnPaymentTypeCreated(tblGnPaymentType);

            context.TblGnPaymentTypes.Add(tblGnPaymentType);
            context.SaveChanges();

            return tblGnPaymentType;
        }
        public async Task ExportTblGnProductsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnproducts/excel") : "export/dbatvdc2/tblgnproducts/excel", true);
        }

        public async Task ExportTblGnProductsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnproducts/csv") : "export/dbatvdc2/tblgnproducts/csv", true);
        }

        partial void OnTblGnProductsRead(ref IQueryable<Models.DbAtVdc2.TblGnProduct> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnProduct>> GetTblGnProducts(Query query = null)
        {
            var items = context.TblGnProducts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnProductCreated(Models.DbAtVdc2.TblGnProduct item);

        public async Task<Models.DbAtVdc2.TblGnProduct> CreateTblGnProduct(Models.DbAtVdc2.TblGnProduct tblGnProduct)
        {
            OnTblGnProductCreated(tblGnProduct);

            context.TblGnProducts.Add(tblGnProduct);
            context.SaveChanges();

            return tblGnProduct;
        }
        public async Task ExportTblGnShipViaToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnshipvia/excel") : "export/dbatvdc2/tblgnshipvia/excel", true);
        }

        public async Task ExportTblGnShipViaToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblgnshipvia/csv") : "export/dbatvdc2/tblgnshipvia/csv", true);
        }

        partial void OnTblGnShipViaRead(ref IQueryable<Models.DbAtVdc2.TblGnShipVium> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblGnShipVium>> GetTblGnShipVia(Query query = null)
        {
            var items = context.TblGnShipVia.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblGnShipViaRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblGnShipViumCreated(Models.DbAtVdc2.TblGnShipVium item);

        public async Task<Models.DbAtVdc2.TblGnShipVium> CreateTblGnShipVium(Models.DbAtVdc2.TblGnShipVium tblGnShipVium)
        {
            OnTblGnShipViumCreated(tblGnShipVium);

            context.TblGnShipVia.Add(tblGnShipVium);
            context.SaveChanges();

            return tblGnShipVium;
        }
        public async Task ExportTblHpTinhTpsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblhptinhtps/excel") : "export/dbatvdc2/tblhptinhtps/excel", true);
        }

        public async Task ExportTblHpTinhTpsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblhptinhtps/csv") : "export/dbatvdc2/tblhptinhtps/csv", true);
        }

        partial void OnTblHpTinhTpsRead(ref IQueryable<Models.DbAtVdc2.TblHpTinhTp> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblHpTinhTp>> GetTblHpTinhTps(Query query = null)
        {
            var items = context.TblHpTinhTps.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblHpTinhTpsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblHpTinhTpCreated(Models.DbAtVdc2.TblHpTinhTp item);

        public async Task<Models.DbAtVdc2.TblHpTinhTp> CreateTblHpTinhTp(Models.DbAtVdc2.TblHpTinhTp tblHpTinhTp)
        {
            OnTblHpTinhTpCreated(tblHpTinhTp);

            context.TblHpTinhTps.Add(tblHpTinhTp);
            context.SaveChanges();

            return tblHpTinhTp;
        }
        public async Task ExportTblIcCategoriesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tbliccategories/excel") : "export/dbatvdc2/tbliccategories/excel", true);
        }

        public async Task ExportTblIcCategoriesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tbliccategories/csv") : "export/dbatvdc2/tbliccategories/csv", true);
        }

        partial void OnTblIcCategoriesRead(ref IQueryable<Models.DbAtVdc2.TblIcCategory> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcCategory>> GetTblIcCategories(Query query = null)
        {
            var items = context.TblIcCategories.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcCategoryCreated(Models.DbAtVdc2.TblIcCategory item);

        public async Task<Models.DbAtVdc2.TblIcCategory> CreateTblIcCategory(Models.DbAtVdc2.TblIcCategory tblIcCategory)
        {
            OnTblIcCategoryCreated(tblIcCategory);

            context.TblIcCategories.Add(tblIcCategory);
            context.SaveChanges();

            return tblIcCategory;
        }
        public async Task ExportTblIcClassificationsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicclassifications/excel") : "export/dbatvdc2/tblicclassifications/excel", true);
        }

        public async Task ExportTblIcClassificationsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicclassifications/csv") : "export/dbatvdc2/tblicclassifications/csv", true);
        }

        partial void OnTblIcClassificationsRead(ref IQueryable<Models.DbAtVdc2.TblIcClassification> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcClassification>> GetTblIcClassifications(Query query = null)
        {
            var items = context.TblIcClassifications.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcClassificationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcClassificationCreated(Models.DbAtVdc2.TblIcClassification item);

        public async Task<Models.DbAtVdc2.TblIcClassification> CreateTblIcClassification(Models.DbAtVdc2.TblIcClassification tblIcClassification)
        {
            OnTblIcClassificationCreated(tblIcClassification);

            context.TblIcClassifications.Add(tblIcClassification);
            context.SaveChanges();

            return tblIcClassification;
        }
        public async Task ExportTblIcInventoriesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicinventories/excel") : "export/dbatvdc2/tblicinventories/excel", true);
        }

        public async Task ExportTblIcInventoriesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicinventories/csv") : "export/dbatvdc2/tblicinventories/csv", true);
        }

        partial void OnTblIcInventoriesRead(ref IQueryable<Models.DbAtVdc2.TblIcInventory> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcInventory>> GetTblIcInventories(Query query = null)
        {
            var items = context.TblIcInventories.AsQueryable();

            items = items.Include(i => i.TblIcWarehouse);

            items = items.Include(i => i.TblIcCategory);

            items = items.Include(i => i.TblIcClassification);

            items = items.Include(i => i.TblGnProduct);

            items = items.Include(i => i.TblIcUnit);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcInventoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcInventoryCreated(Models.DbAtVdc2.TblIcInventory item);

        public async Task<Models.DbAtVdc2.TblIcInventory> CreateTblIcInventory(Models.DbAtVdc2.TblIcInventory tblIcInventory)
        {
            OnTblIcInventoryCreated(tblIcInventory);

            context.TblIcInventories.Add(tblIcInventory);
            context.SaveChanges();

            return tblIcInventory;
        }
        public async Task ExportTblIcTransactionsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblictransactions/excel") : "export/dbatvdc2/tblictransactions/excel", true);
        }

        public async Task ExportTblIcTransactionsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblictransactions/csv") : "export/dbatvdc2/tblictransactions/csv", true);
        }

        partial void OnTblIcTransactionsRead(ref IQueryable<Models.DbAtVdc2.TblIcTransaction> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcTransaction>> GetTblIcTransactions(Query query = null)
        {
            var items = context.TblIcTransactions.AsQueryable();

            items = items.Include(i => i.TblIcTransactionType);

            items = items.Include(i => i.TblIcWarehouse);

            items = items.Include(i => i.TblGnProduct);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcTransactionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcTransactionCreated(Models.DbAtVdc2.TblIcTransaction item);

        public async Task<Models.DbAtVdc2.TblIcTransaction> CreateTblIcTransaction(Models.DbAtVdc2.TblIcTransaction tblIcTransaction)
        {
            OnTblIcTransactionCreated(tblIcTransaction);

            context.TblIcTransactions.Add(tblIcTransaction);
            context.SaveChanges();

            return tblIcTransaction;
        }
        public async Task ExportTblIcTransactionTypesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblictransactiontypes/excel") : "export/dbatvdc2/tblictransactiontypes/excel", true);
        }

        public async Task ExportTblIcTransactionTypesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblictransactiontypes/csv") : "export/dbatvdc2/tblictransactiontypes/csv", true);
        }

        partial void OnTblIcTransactionTypesRead(ref IQueryable<Models.DbAtVdc2.TblIcTransactionType> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcTransactionType>> GetTblIcTransactionTypes(Query query = null)
        {
            var items = context.TblIcTransactionTypes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcTransactionTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcTransactionTypeCreated(Models.DbAtVdc2.TblIcTransactionType item);

        public async Task<Models.DbAtVdc2.TblIcTransactionType> CreateTblIcTransactionType(Models.DbAtVdc2.TblIcTransactionType tblIcTransactionType)
        {
            OnTblIcTransactionTypeCreated(tblIcTransactionType);

            context.TblIcTransactionTypes.Add(tblIcTransactionType);
            context.SaveChanges();

            return tblIcTransactionType;
        }
        public async Task ExportTblIcUnitsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicunits/excel") : "export/dbatvdc2/tblicunits/excel", true);
        }

        public async Task ExportTblIcUnitsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicunits/csv") : "export/dbatvdc2/tblicunits/csv", true);
        }

        partial void OnTblIcUnitsRead(ref IQueryable<Models.DbAtVdc2.TblIcUnit> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcUnit>> GetTblIcUnits(Query query = null)
        {
            var items = context.TblIcUnits.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcUnitsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcUnitCreated(Models.DbAtVdc2.TblIcUnit item);

        public async Task<Models.DbAtVdc2.TblIcUnit> CreateTblIcUnit(Models.DbAtVdc2.TblIcUnit tblIcUnit)
        {
            OnTblIcUnitCreated(tblIcUnit);

            context.TblIcUnits.Add(tblIcUnit);
            context.SaveChanges();

            return tblIcUnit;
        }
        public async Task ExportTblIcWarehousesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicwarehouses/excel") : "export/dbatvdc2/tblicwarehouses/excel", true);
        }

        public async Task ExportTblIcWarehousesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblicwarehouses/csv") : "export/dbatvdc2/tblicwarehouses/csv", true);
        }

        partial void OnTblIcWarehousesRead(ref IQueryable<Models.DbAtVdc2.TblIcWarehouse> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblIcWarehouse>> GetTblIcWarehouses(Query query = null)
        {
            var items = context.TblIcWarehouses.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblIcWarehousesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblIcWarehouseCreated(Models.DbAtVdc2.TblIcWarehouse item);

        public async Task<Models.DbAtVdc2.TblIcWarehouse> CreateTblIcWarehouse(Models.DbAtVdc2.TblIcWarehouse tblIcWarehouse)
        {
            OnTblIcWarehouseCreated(tblIcWarehouse);

            context.TblIcWarehouses.Add(tblIcWarehouse);
            context.SaveChanges();

            return tblIcWarehouse;
        }
        public async Task ExportTblPoAccountPayablesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoaccountpayables/excel") : "export/dbatvdc2/tblpoaccountpayables/excel", true);
        }

        public async Task ExportTblPoAccountPayablesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoaccountpayables/csv") : "export/dbatvdc2/tblpoaccountpayables/csv", true);
        }

        partial void OnTblPoAccountPayablesRead(ref IQueryable<Models.DbAtVdc2.TblPoAccountPayable> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoAccountPayable>> GetTblPoAccountPayables(Query query = null)
        {
            var items = context.TblPoAccountPayables.AsQueryable();

            items = items.Include(i => i.TblPoVendor);

            items = items.Include(i => i.TblGnDepartment);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoAccountPayablesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoAccountPayableCreated(Models.DbAtVdc2.TblPoAccountPayable item);

        public async Task<Models.DbAtVdc2.TblPoAccountPayable> CreateTblPoAccountPayable(Models.DbAtVdc2.TblPoAccountPayable tblPoAccountPayable)
        {
            OnTblPoAccountPayableCreated(tblPoAccountPayable);

            context.TblPoAccountPayables.Add(tblPoAccountPayable);
            context.SaveChanges();

            return tblPoAccountPayable;
        }
        public async Task ExportTblPoAccountsPayableAdjustmentsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoaccountspayableadjustments/excel") : "export/dbatvdc2/tblpoaccountspayableadjustments/excel", true);
        }

        public async Task ExportTblPoAccountsPayableAdjustmentsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoaccountspayableadjustments/csv") : "export/dbatvdc2/tblpoaccountspayableadjustments/csv", true);
        }

        partial void OnTblPoAccountsPayableAdjustmentsRead(ref IQueryable<Models.DbAtVdc2.TblPoAccountsPayableAdjustment> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoAccountsPayableAdjustment>> GetTblPoAccountsPayableAdjustments(Query query = null)
        {
            var items = context.TblPoAccountsPayableAdjustments.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoAccountsPayableAdjustmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoAccountsPayableAdjustmentCreated(Models.DbAtVdc2.TblPoAccountsPayableAdjustment item);

        public async Task<Models.DbAtVdc2.TblPoAccountsPayableAdjustment> CreateTblPoAccountsPayableAdjustment(Models.DbAtVdc2.TblPoAccountsPayableAdjustment tblPoAccountsPayableAdjustment)
        {
            OnTblPoAccountsPayableAdjustmentCreated(tblPoAccountsPayableAdjustment);

            context.TblPoAccountsPayableAdjustments.Add(tblPoAccountsPayableAdjustment);
            context.SaveChanges();

            return tblPoAccountsPayableAdjustment;
        }
        public async Task ExportTblPoApInvoicesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoapinvoices/excel") : "export/dbatvdc2/tblpoapinvoices/excel", true);
        }

        public async Task ExportTblPoApInvoicesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoapinvoices/csv") : "export/dbatvdc2/tblpoapinvoices/csv", true);
        }

        partial void OnTblPoApInvoicesRead(ref IQueryable<Models.DbAtVdc2.TblPoApInvoice> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoApInvoice>> GetTblPoApInvoices(Query query = null)
        {
            var items = context.TblPoApInvoices.AsQueryable();

            items = items.Include(i => i.TblPoVendor);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoApInvoicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoApInvoiceCreated(Models.DbAtVdc2.TblPoApInvoice item);

        public async Task<Models.DbAtVdc2.TblPoApInvoice> CreateTblPoApInvoice(Models.DbAtVdc2.TblPoApInvoice tblPoApInvoice)
        {
            OnTblPoApInvoiceCreated(tblPoApInvoice);

            context.TblPoApInvoices.Add(tblPoApInvoice);
            context.SaveChanges();

            return tblPoApInvoice;
        }
        public async Task ExportTblPoApInvoicesDetailsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoapinvoicesdetails/excel") : "export/dbatvdc2/tblpoapinvoicesdetails/excel", true);
        }

        public async Task ExportTblPoApInvoicesDetailsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoapinvoicesdetails/csv") : "export/dbatvdc2/tblpoapinvoicesdetails/csv", true);
        }

        partial void OnTblPoApInvoicesDetailsRead(ref IQueryable<Models.DbAtVdc2.TblPoApInvoicesDetail> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoApInvoicesDetail>> GetTblPoApInvoicesDetails(Query query = null)
        {
            var items = context.TblPoApInvoicesDetails.AsQueryable();

            items = items.Include(i => i.TblPoVendor);

            items = items.Include(i => i.TblIcInventory);

            items = items.Include(i => i.TblIcUnit);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoApInvoicesDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoApInvoicesDetailCreated(Models.DbAtVdc2.TblPoApInvoicesDetail item);

        public async Task<Models.DbAtVdc2.TblPoApInvoicesDetail> CreateTblPoApInvoicesDetail(Models.DbAtVdc2.TblPoApInvoicesDetail tblPoApInvoicesDetail)
        {
            OnTblPoApInvoicesDetailCreated(tblPoApInvoicesDetail);

            context.TblPoApInvoicesDetails.Add(tblPoApInvoicesDetail);
            context.SaveChanges();

            return tblPoApInvoicesDetail;
        }
        public async Task ExportTblPoCashDisbursementsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpocashdisbursements/excel") : "export/dbatvdc2/tblpocashdisbursements/excel", true);
        }

        public async Task ExportTblPoCashDisbursementsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpocashdisbursements/csv") : "export/dbatvdc2/tblpocashdisbursements/csv", true);
        }

        partial void OnTblPoCashDisbursementsRead(ref IQueryable<Models.DbAtVdc2.TblPoCashDisbursement> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoCashDisbursement>> GetTblPoCashDisbursements(Query query = null)
        {
            var items = context.TblPoCashDisbursements.AsQueryable();

            items = items.Include(i => i.TblGnAddressBook);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoCashDisbursementsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoCashDisbursementCreated(Models.DbAtVdc2.TblPoCashDisbursement item);

        public async Task<Models.DbAtVdc2.TblPoCashDisbursement> CreateTblPoCashDisbursement(Models.DbAtVdc2.TblPoCashDisbursement tblPoCashDisbursement)
        {
            OnTblPoCashDisbursementCreated(tblPoCashDisbursement);

            context.TblPoCashDisbursements.Add(tblPoCashDisbursement);
            context.SaveChanges();

            return tblPoCashDisbursement;
        }
        public async Task ExportTblPoOrderStatusesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoorderstatuses/excel") : "export/dbatvdc2/tblpoorderstatuses/excel", true);
        }

        public async Task ExportTblPoOrderStatusesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpoorderstatuses/csv") : "export/dbatvdc2/tblpoorderstatuses/csv", true);
        }

        partial void OnTblPoOrderStatusesRead(ref IQueryable<Models.DbAtVdc2.TblPoOrderStatus> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoOrderStatus>> GetTblPoOrderStatuses(Query query = null)
        {
            var items = context.TblPoOrderStatuses.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoOrderStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoOrderStatusCreated(Models.DbAtVdc2.TblPoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblPoOrderStatus> CreateTblPoOrderStatus(Models.DbAtVdc2.TblPoOrderStatus tblPoOrderStatus)
        {
            OnTblPoOrderStatusCreated(tblPoOrderStatus);

            context.TblPoOrderStatuses.Add(tblPoOrderStatus);
            context.SaveChanges();

            return tblPoOrderStatus;
        }
        public async Task ExportTblPoPurchaseOrdersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpopurchaseorders/excel") : "export/dbatvdc2/tblpopurchaseorders/excel", true);
        }

        public async Task ExportTblPoPurchaseOrdersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpopurchaseorders/csv") : "export/dbatvdc2/tblpopurchaseorders/csv", true);
        }

        partial void OnTblPoPurchaseOrdersRead(ref IQueryable<Models.DbAtVdc2.TblPoPurchaseOrder> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoPurchaseOrder>> GetTblPoPurchaseOrders(Query query = null)
        {
            var items = context.TblPoPurchaseOrders.AsQueryable();

            items = items.Include(i => i.TblGnAddressBook);

            items = items.Include(i => i.TblPoOrderStatus);

            items = items.Include(i => i.TblPoVendor);

            items = items.Include(i => i.TblGnIncoterm);

            items = items.Include(i => i.TblGnShipVium);

            items = items.Include(i => i.TblGnPaymentTerm);

            items = items.Include(i => i.TblGnPaymentType);

            items = items.Include(i => i.TblGnAddressBook1);

            items = items.Include(i => i.TblGnDepartment);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoPurchaseOrdersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoPurchaseOrderCreated(Models.DbAtVdc2.TblPoPurchaseOrder item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrder> CreateTblPoPurchaseOrder(Models.DbAtVdc2.TblPoPurchaseOrder tblPoPurchaseOrder)
        {
            OnTblPoPurchaseOrderCreated(tblPoPurchaseOrder);

            context.TblPoPurchaseOrders.Add(tblPoPurchaseOrder);
            context.SaveChanges();

            return tblPoPurchaseOrder;
        }
        public async Task ExportTblPoPurchaseOrderDetailsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpopurchaseorderdetails/excel") : "export/dbatvdc2/tblpopurchaseorderdetails/excel", true);
        }

        public async Task ExportTblPoPurchaseOrderDetailsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpopurchaseorderdetails/csv") : "export/dbatvdc2/tblpopurchaseorderdetails/csv", true);
        }

        partial void OnTblPoPurchaseOrderDetailsRead(ref IQueryable<Models.DbAtVdc2.TblPoPurchaseOrderDetail> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoPurchaseOrderDetail>> GetTblPoPurchaseOrderDetails(Query query = null)
        {
            var items = context.TblPoPurchaseOrderDetails.AsQueryable();

            items = items.Include(i => i.TblPoPurchaseOrder);

            items = items.Include(i => i.TblIcInventory);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoPurchaseOrderDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoPurchaseOrderDetailCreated(Models.DbAtVdc2.TblPoPurchaseOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrderDetail> CreateTblPoPurchaseOrderDetail(Models.DbAtVdc2.TblPoPurchaseOrderDetail tblPoPurchaseOrderDetail)
        {
            OnTblPoPurchaseOrderDetailCreated(tblPoPurchaseOrderDetail);

            context.TblPoPurchaseOrderDetails.Add(tblPoPurchaseOrderDetail);
            context.SaveChanges();

            return tblPoPurchaseOrderDetail;
        }
        public async Task ExportTblPoRecReportsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblporecreports/excel") : "export/dbatvdc2/tblporecreports/excel", true);
        }

        public async Task ExportTblPoRecReportsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblporecreports/csv") : "export/dbatvdc2/tblporecreports/csv", true);
        }

        partial void OnTblPoRecReportsRead(ref IQueryable<Models.DbAtVdc2.TblPoRecReport> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoRecReport>> GetTblPoRecReports(Query query = null)
        {
            var items = context.TblPoRecReports.AsQueryable();

            items = items.Include(i => i.TblGnAddressBook);

            items = items.Include(i => i.TblPoVendor);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoRecReportsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoRecReportCreated(Models.DbAtVdc2.TblPoRecReport item);

        public async Task<Models.DbAtVdc2.TblPoRecReport> CreateTblPoRecReport(Models.DbAtVdc2.TblPoRecReport tblPoRecReport)
        {
            OnTblPoRecReportCreated(tblPoRecReport);

            context.TblPoRecReports.Add(tblPoRecReport);
            context.SaveChanges();

            return tblPoRecReport;
        }
        public async Task ExportTblPoRrOrderDetailsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblporrorderdetails/excel") : "export/dbatvdc2/tblporrorderdetails/excel", true);
        }

        public async Task ExportTblPoRrOrderDetailsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblporrorderdetails/csv") : "export/dbatvdc2/tblporrorderdetails/csv", true);
        }

        partial void OnTblPoRrOrderDetailsRead(ref IQueryable<Models.DbAtVdc2.TblPoRrOrderDetail> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoRrOrderDetail>> GetTblPoRrOrderDetails(Query query = null)
        {
            var items = context.TblPoRrOrderDetails.AsQueryable();

            items = items.Include(i => i.TblPoRecReport);

            items = items.Include(i => i.TblIcInventory);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoRrOrderDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoRrOrderDetailCreated(Models.DbAtVdc2.TblPoRrOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoRrOrderDetail> CreateTblPoRrOrderDetail(Models.DbAtVdc2.TblPoRrOrderDetail tblPoRrOrderDetail)
        {
            OnTblPoRrOrderDetailCreated(tblPoRrOrderDetail);

            context.TblPoRrOrderDetails.Add(tblPoRrOrderDetail);
            context.SaveChanges();

            return tblPoRrOrderDetail;
        }
        public async Task ExportTblPoVendorsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpovendors/excel") : "export/dbatvdc2/tblpovendors/excel", true);
        }

        public async Task ExportTblPoVendorsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblpovendors/csv") : "export/dbatvdc2/tblpovendors/csv", true);
        }

        partial void OnTblPoVendorsRead(ref IQueryable<Models.DbAtVdc2.TblPoVendor> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblPoVendor>> GetTblPoVendors(Query query = null)
        {
            var items = context.TblPoVendors.AsQueryable();

            items = items.Include(i => i.TblGnAddressBook);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblPoVendorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblPoVendorCreated(Models.DbAtVdc2.TblPoVendor item);

        public async Task<Models.DbAtVdc2.TblPoVendor> CreateTblPoVendor(Models.DbAtVdc2.TblPoVendor tblPoVendor)
        {
            OnTblPoVendorCreated(tblPoVendor);

            context.TblPoVendors.Add(tblPoVendor);
            context.SaveChanges();

            return tblPoVendor;
        }
        public async Task ExportTblSoCustomersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsocustomers/excel") : "export/dbatvdc2/tblsocustomers/excel", true);
        }

        public async Task ExportTblSoCustomersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsocustomers/csv") : "export/dbatvdc2/tblsocustomers/csv", true);
        }

        partial void OnTblSoCustomersRead(ref IQueryable<Models.DbAtVdc2.TblSoCustomer> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblSoCustomer>> GetTblSoCustomers(Query query = null)
        {
            var items = context.TblSoCustomers.AsQueryable();

            items = items.Include(i => i.TblGnAddressBook);

            items = items.Include(i => i.TblGnPaymentTerm);

            items = items.Include(i => i.TblGnPaymentType);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblSoCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSoCustomerCreated(Models.DbAtVdc2.TblSoCustomer item);

        public async Task<Models.DbAtVdc2.TblSoCustomer> CreateTblSoCustomer(Models.DbAtVdc2.TblSoCustomer tblSoCustomer)
        {
            OnTblSoCustomerCreated(tblSoCustomer);

            context.TblSoCustomers.Add(tblSoCustomer);
            context.SaveChanges();

            return tblSoCustomer;
        }
        public async Task ExportTblSoOrderDetailsToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsoorderdetails/excel") : "export/dbatvdc2/tblsoorderdetails/excel", true);
        }

        public async Task ExportTblSoOrderDetailsToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsoorderdetails/csv") : "export/dbatvdc2/tblsoorderdetails/csv", true);
        }

        partial void OnTblSoOrderDetailsRead(ref IQueryable<Models.DbAtVdc2.TblSoOrderDetail> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblSoOrderDetail>> GetTblSoOrderDetails(Query query = null)
        {
            var items = context.TblSoOrderDetails.AsQueryable();

            items = items.Include(i => i.TblSoOrderDetailStatus);

            items = items.Include(i => i.TblSoSalesOrder);

            items = items.Include(i => i.TblIcInventory);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblSoOrderDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSoOrderDetailCreated(Models.DbAtVdc2.TblSoOrderDetail item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetail> CreateTblSoOrderDetail(Models.DbAtVdc2.TblSoOrderDetail tblSoOrderDetail)
        {
            OnTblSoOrderDetailCreated(tblSoOrderDetail);

            context.TblSoOrderDetails.Add(tblSoOrderDetail);
            context.SaveChanges();

            return tblSoOrderDetail;
        }
        public async Task ExportTblSoOrderDetailStatusesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsoorderdetailstatuses/excel") : "export/dbatvdc2/tblsoorderdetailstatuses/excel", true);
        }

        public async Task ExportTblSoOrderDetailStatusesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsoorderdetailstatuses/csv") : "export/dbatvdc2/tblsoorderdetailstatuses/csv", true);
        }

        partial void OnTblSoOrderDetailStatusesRead(ref IQueryable<Models.DbAtVdc2.TblSoOrderDetailStatus> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblSoOrderDetailStatus>> GetTblSoOrderDetailStatuses(Query query = null)
        {
            var items = context.TblSoOrderDetailStatuses.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblSoOrderDetailStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSoOrderDetailStatusCreated(Models.DbAtVdc2.TblSoOrderDetailStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetailStatus> CreateTblSoOrderDetailStatus(Models.DbAtVdc2.TblSoOrderDetailStatus tblSoOrderDetailStatus)
        {
            OnTblSoOrderDetailStatusCreated(tblSoOrderDetailStatus);

            context.TblSoOrderDetailStatuses.Add(tblSoOrderDetailStatus);
            context.SaveChanges();

            return tblSoOrderDetailStatus;
        }
        public async Task ExportTblSoOrderStatusesToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsoorderstatuses/excel") : "export/dbatvdc2/tblsoorderstatuses/excel", true);
        }

        public async Task ExportTblSoOrderStatusesToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsoorderstatuses/csv") : "export/dbatvdc2/tblsoorderstatuses/csv", true);
        }

        partial void OnTblSoOrderStatusesRead(ref IQueryable<Models.DbAtVdc2.TblSoOrderStatus> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblSoOrderStatus>> GetTblSoOrderStatuses(Query query = null)
        {
            var items = context.TblSoOrderStatuses.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblSoOrderStatusesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSoOrderStatusCreated(Models.DbAtVdc2.TblSoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderStatus> CreateTblSoOrderStatus(Models.DbAtVdc2.TblSoOrderStatus tblSoOrderStatus)
        {
            OnTblSoOrderStatusCreated(tblSoOrderStatus);

            context.TblSoOrderStatuses.Add(tblSoOrderStatus);
            context.SaveChanges();

            return tblSoOrderStatus;
        }
        public async Task ExportTblSoSalesOrdersToExcel(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsosalesorders/excel") : "export/dbatvdc2/tblsosalesorders/excel", true);
        }

        public async Task ExportTblSoSalesOrdersToCSV(Query query = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl("export/dbatvdc2/tblsosalesorders/csv") : "export/dbatvdc2/tblsosalesorders/csv", true);
        }

        partial void OnTblSoSalesOrdersRead(ref IQueryable<Models.DbAtVdc2.TblSoSalesOrder> items);

        public async Task<IQueryable<Models.DbAtVdc2.TblSoSalesOrder>> GetTblSoSalesOrders(Query query = null)
        {
            var items = context.TblSoSalesOrders.AsQueryable();

            items = items.Include(i => i.TblSoOrderStatus);

            items = items.Include(i => i.TblSoCustomer);

            items = items.Include(i => i.TblGnShipVium);

            items = items.Include(i => i.TblGnPaymentTerm);

            items = items.Include(i => i.TblGnPaymentType);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    items = items.Where(query.Filter);
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTblSoSalesOrdersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTblSoSalesOrderCreated(Models.DbAtVdc2.TblSoSalesOrder item);

        public async Task<Models.DbAtVdc2.TblSoSalesOrder> CreateTblSoSalesOrder(Models.DbAtVdc2.TblSoSalesOrder tblSoSalesOrder)
        {
            OnTblSoSalesOrderCreated(tblSoSalesOrder);

            context.TblSoSalesOrders.Add(tblSoSalesOrder);
            context.SaveChanges();

            return tblSoSalesOrder;
        }

        partial void OnTblGnAddressBookDeleted(Models.DbAtVdc2.TblGnAddressBook item);

        public async Task<Models.DbAtVdc2.TblGnAddressBook> DeleteTblGnAddressBook(int? addressBookSeq)
        {
            var item = context.TblGnAddressBooks
                              .Where(i => i.AddressBook_SEQ == addressBookSeq)
                              .Include(i => i.TblPoPurchaseOrders)
                              .Include(i => i.TblPoPurchaseOrders1)
                              .Include(i => i.TblPoRecReports)
                              .Include(i => i.TblPoCashDisbursements)
                              .Include(i => i.TblSoCustomers)
                              .Include(i => i.TblPoVendors)
                              .FirstOrDefault();

            OnTblGnAddressBookDeleted(item);

            context.TblGnAddressBooks.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnAddressBookGet(Models.DbAtVdc2.TblGnAddressBook item);

        public async Task<Models.DbAtVdc2.TblGnAddressBook> GetTblGnAddressBookByAddressBookSeq(int? addressBookSeq)
        {
            var items = context.TblGnAddressBooks
                              .AsNoTracking()
                              .Where(i => i.AddressBook_SEQ == addressBookSeq);

            items = items.Include(i => i.TblGnAddressBookType);

            items = items.Include(i => i.TblGnGender);

            items = items.Include(i => i.TblHpTinhTp);

            var item = items.FirstOrDefault();

            OnTblGnAddressBookGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnAddressBook> CancelTblGnAddressBookChanges(Models.DbAtVdc2.TblGnAddressBook item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnAddressBookUpdated(Models.DbAtVdc2.TblGnAddressBook item);

        public async Task<Models.DbAtVdc2.TblGnAddressBook> UpdateTblGnAddressBook(int? addressBookSeq, Models.DbAtVdc2.TblGnAddressBook tblGnAddressBook)
        {
            OnTblGnAddressBookUpdated(tblGnAddressBook);

            var item = context.TblGnAddressBooks
                              .Where(i => i.AddressBook_SEQ == addressBookSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnAddressBook);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnAddressBook;
        }

        partial void OnTblGnAddressBookTypeDeleted(Models.DbAtVdc2.TblGnAddressBookType item);

        public async Task<Models.DbAtVdc2.TblGnAddressBookType> DeleteTblGnAddressBookType(int? addressBookTypeSeq)
        {
            var item = context.TblGnAddressBookTypes
                              .Where(i => i.AddressBookType_SEQ == addressBookTypeSeq)
                              .Include(i => i.TblGnAddressBooks)
                              .FirstOrDefault();

            OnTblGnAddressBookTypeDeleted(item);

            context.TblGnAddressBookTypes.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnAddressBookTypeGet(Models.DbAtVdc2.TblGnAddressBookType item);

        public async Task<Models.DbAtVdc2.TblGnAddressBookType> GetTblGnAddressBookTypeByAddressBookTypeSeq(int? addressBookTypeSeq)
        {
            var items = context.TblGnAddressBookTypes
                              .AsNoTracking()
                              .Where(i => i.AddressBookType_SEQ == addressBookTypeSeq);

            var item = items.FirstOrDefault();

            OnTblGnAddressBookTypeGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnAddressBookType> CancelTblGnAddressBookTypeChanges(Models.DbAtVdc2.TblGnAddressBookType item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnAddressBookTypeUpdated(Models.DbAtVdc2.TblGnAddressBookType item);

        public async Task<Models.DbAtVdc2.TblGnAddressBookType> UpdateTblGnAddressBookType(int? addressBookTypeSeq, Models.DbAtVdc2.TblGnAddressBookType tblGnAddressBookType)
        {
            OnTblGnAddressBookTypeUpdated(tblGnAddressBookType);

            var item = context.TblGnAddressBookTypes
                              .Where(i => i.AddressBookType_SEQ == addressBookTypeSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnAddressBookType);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnAddressBookType;
        }

        partial void OnTblGnDepartmentDeleted(Models.DbAtVdc2.TblGnDepartment item);

        public async Task<Models.DbAtVdc2.TblGnDepartment> DeleteTblGnDepartment(string departmentId)
        {
            var item = context.TblGnDepartments
                              .Where(i => i.Department_ID == departmentId)
                              .Include(i => i.TblPoAccountPayables)
                              .Include(i => i.TblPoPurchaseOrders)
                              .FirstOrDefault();

            OnTblGnDepartmentDeleted(item);

            context.TblGnDepartments.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnDepartmentGet(Models.DbAtVdc2.TblGnDepartment item);

        public async Task<Models.DbAtVdc2.TblGnDepartment> GetTblGnDepartmentByDepartmentId(string departmentId)
        {
            var items = context.TblGnDepartments
                              .AsNoTracking()
                              .Where(i => i.Department_ID == departmentId);

            var item = items.FirstOrDefault();

            OnTblGnDepartmentGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnDepartment> CancelTblGnDepartmentChanges(Models.DbAtVdc2.TblGnDepartment item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnDepartmentUpdated(Models.DbAtVdc2.TblGnDepartment item);

        public async Task<Models.DbAtVdc2.TblGnDepartment> UpdateTblGnDepartment(string departmentId, Models.DbAtVdc2.TblGnDepartment tblGnDepartment)
        {
            OnTblGnDepartmentUpdated(tblGnDepartment);

            var item = context.TblGnDepartments
                              .Where(i => i.Department_ID == departmentId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnDepartment);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnDepartment;
        }

        partial void OnTblGnGenderDeleted(Models.DbAtVdc2.TblGnGender item);

        public async Task<Models.DbAtVdc2.TblGnGender> DeleteTblGnGender(int? genderSeq)
        {
            var item = context.TblGnGenders
                              .Where(i => i.Gender_SEQ == genderSeq)
                              .Include(i => i.TblGnAddressBooks)
                              .FirstOrDefault();

            OnTblGnGenderDeleted(item);

            context.TblGnGenders.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnGenderGet(Models.DbAtVdc2.TblGnGender item);

        public async Task<Models.DbAtVdc2.TblGnGender> GetTblGnGenderByGenderSeq(int? genderSeq)
        {
            var items = context.TblGnGenders
                              .AsNoTracking()
                              .Where(i => i.Gender_SEQ == genderSeq);

            var item = items.FirstOrDefault();

            OnTblGnGenderGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnGender> CancelTblGnGenderChanges(Models.DbAtVdc2.TblGnGender item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnGenderUpdated(Models.DbAtVdc2.TblGnGender item);

        public async Task<Models.DbAtVdc2.TblGnGender> UpdateTblGnGender(int? genderSeq, Models.DbAtVdc2.TblGnGender tblGnGender)
        {
            OnTblGnGenderUpdated(tblGnGender);

            var item = context.TblGnGenders
                              .Where(i => i.Gender_SEQ == genderSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnGender);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnGender;
        }

        partial void OnTblGnIncotermDeleted(Models.DbAtVdc2.TblGnIncoterm item);

        public async Task<Models.DbAtVdc2.TblGnIncoterm> DeleteTblGnIncoterm(string incotermId)
        {
            var item = context.TblGnIncoterms
                              .Where(i => i.Incoterm_ID == incotermId)
                              .Include(i => i.TblPoPurchaseOrders)
                              .FirstOrDefault();

            OnTblGnIncotermDeleted(item);

            context.TblGnIncoterms.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnIncotermGet(Models.DbAtVdc2.TblGnIncoterm item);

        public async Task<Models.DbAtVdc2.TblGnIncoterm> GetTblGnIncotermByIncotermId(string incotermId)
        {
            var items = context.TblGnIncoterms
                              .AsNoTracking()
                              .Where(i => i.Incoterm_ID == incotermId);

            var item = items.FirstOrDefault();

            OnTblGnIncotermGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnIncoterm> CancelTblGnIncotermChanges(Models.DbAtVdc2.TblGnIncoterm item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnIncotermUpdated(Models.DbAtVdc2.TblGnIncoterm item);

        public async Task<Models.DbAtVdc2.TblGnIncoterm> UpdateTblGnIncoterm(string incotermId, Models.DbAtVdc2.TblGnIncoterm tblGnIncoterm)
        {
            OnTblGnIncotermUpdated(tblGnIncoterm);

            var item = context.TblGnIncoterms
                              .Where(i => i.Incoterm_ID == incotermId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnIncoterm);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnIncoterm;
        }

        partial void OnTblGnPaymentTermDeleted(Models.DbAtVdc2.TblGnPaymentTerm item);

        public async Task<Models.DbAtVdc2.TblGnPaymentTerm> DeleteTblGnPaymentTerm(int? paymentTermSeq)
        {
            var item = context.TblGnPaymentTerms
                              .Where(i => i.PaymentTerm_SEQ == paymentTermSeq)
                              .Include(i => i.TblPoPurchaseOrders)
                              .Include(i => i.TblSoCustomers)
                              .Include(i => i.TblSoSalesOrders)
                              .FirstOrDefault();

            OnTblGnPaymentTermDeleted(item);

            context.TblGnPaymentTerms.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnPaymentTermGet(Models.DbAtVdc2.TblGnPaymentTerm item);

        public async Task<Models.DbAtVdc2.TblGnPaymentTerm> GetTblGnPaymentTermByPaymentTermSeq(int? paymentTermSeq)
        {
            var items = context.TblGnPaymentTerms
                              .AsNoTracking()
                              .Where(i => i.PaymentTerm_SEQ == paymentTermSeq);

            var item = items.FirstOrDefault();

            OnTblGnPaymentTermGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnPaymentTerm> CancelTblGnPaymentTermChanges(Models.DbAtVdc2.TblGnPaymentTerm item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnPaymentTermUpdated(Models.DbAtVdc2.TblGnPaymentTerm item);

        public async Task<Models.DbAtVdc2.TblGnPaymentTerm> UpdateTblGnPaymentTerm(int? paymentTermSeq, Models.DbAtVdc2.TblGnPaymentTerm tblGnPaymentTerm)
        {
            OnTblGnPaymentTermUpdated(tblGnPaymentTerm);

            var item = context.TblGnPaymentTerms
                              .Where(i => i.PaymentTerm_SEQ == paymentTermSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnPaymentTerm);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnPaymentTerm;
        }

        partial void OnTblGnPaymentTypeDeleted(Models.DbAtVdc2.TblGnPaymentType item);

        public async Task<Models.DbAtVdc2.TblGnPaymentType> DeleteTblGnPaymentType(int? paymentTypeSeq)
        {
            var item = context.TblGnPaymentTypes
                              .Where(i => i.PaymentType_SEQ == paymentTypeSeq)
                              .Include(i => i.TblPoPurchaseOrders)
                              .Include(i => i.TblSoCustomers)
                              .Include(i => i.TblSoSalesOrders)
                              .FirstOrDefault();

            OnTblGnPaymentTypeDeleted(item);

            context.TblGnPaymentTypes.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnPaymentTypeGet(Models.DbAtVdc2.TblGnPaymentType item);

        public async Task<Models.DbAtVdc2.TblGnPaymentType> GetTblGnPaymentTypeByPaymentTypeSeq(int? paymentTypeSeq)
        {
            var items = context.TblGnPaymentTypes
                              .AsNoTracking()
                              .Where(i => i.PaymentType_SEQ == paymentTypeSeq);

            var item = items.FirstOrDefault();

            OnTblGnPaymentTypeGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnPaymentType> CancelTblGnPaymentTypeChanges(Models.DbAtVdc2.TblGnPaymentType item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnPaymentTypeUpdated(Models.DbAtVdc2.TblGnPaymentType item);

        public async Task<Models.DbAtVdc2.TblGnPaymentType> UpdateTblGnPaymentType(int? paymentTypeSeq, Models.DbAtVdc2.TblGnPaymentType tblGnPaymentType)
        {
            OnTblGnPaymentTypeUpdated(tblGnPaymentType);

            var item = context.TblGnPaymentTypes
                              .Where(i => i.PaymentType_SEQ == paymentTypeSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnPaymentType);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnPaymentType;
        }

        partial void OnTblGnProductDeleted(Models.DbAtVdc2.TblGnProduct item);

        public async Task<Models.DbAtVdc2.TblGnProduct> DeleteTblGnProduct(int? productSeq)
        {
            var item = context.TblGnProducts
                              .Where(i => i.Product_SEQ == productSeq)
                              .Include(i => i.TblIcTransactions)
                              .Include(i => i.TblIcInventories)
                              .FirstOrDefault();

            OnTblGnProductDeleted(item);

            context.TblGnProducts.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnProductGet(Models.DbAtVdc2.TblGnProduct item);

        public async Task<Models.DbAtVdc2.TblGnProduct> GetTblGnProductByProductSeq(int? productSeq)
        {
            var items = context.TblGnProducts
                              .AsNoTracking()
                              .Where(i => i.Product_SEQ == productSeq);

            var item = items.FirstOrDefault();

            OnTblGnProductGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnProduct> CancelTblGnProductChanges(Models.DbAtVdc2.TblGnProduct item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnProductUpdated(Models.DbAtVdc2.TblGnProduct item);

        public async Task<Models.DbAtVdc2.TblGnProduct> UpdateTblGnProduct(int? productSeq, Models.DbAtVdc2.TblGnProduct tblGnProduct)
        {
            OnTblGnProductUpdated(tblGnProduct);

            var item = context.TblGnProducts
                              .Where(i => i.Product_SEQ == productSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnProduct);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnProduct;
        }

        partial void OnTblGnShipViumDeleted(Models.DbAtVdc2.TblGnShipVium item);

        public async Task<Models.DbAtVdc2.TblGnShipVium> DeleteTblGnShipVium(int? shipViaSeq)
        {
            var item = context.TblGnShipVia
                              .Where(i => i.ShipVia_SEQ == shipViaSeq)
                              .Include(i => i.TblPoPurchaseOrders)
                              .Include(i => i.TblSoSalesOrders)
                              .FirstOrDefault();

            OnTblGnShipViumDeleted(item);

            context.TblGnShipVia.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblGnShipViumGet(Models.DbAtVdc2.TblGnShipVium item);

        public async Task<Models.DbAtVdc2.TblGnShipVium> GetTblGnShipViumByShipViaSeq(int? shipViaSeq)
        {
            var items = context.TblGnShipVia
                              .AsNoTracking()
                              .Where(i => i.ShipVia_SEQ == shipViaSeq);

            var item = items.FirstOrDefault();

            OnTblGnShipViumGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblGnShipVium> CancelTblGnShipViumChanges(Models.DbAtVdc2.TblGnShipVium item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblGnShipViumUpdated(Models.DbAtVdc2.TblGnShipVium item);

        public async Task<Models.DbAtVdc2.TblGnShipVium> UpdateTblGnShipVium(int? shipViaSeq, Models.DbAtVdc2.TblGnShipVium tblGnShipVium)
        {
            OnTblGnShipViumUpdated(tblGnShipVium);

            var item = context.TblGnShipVia
                              .Where(i => i.ShipVia_SEQ == shipViaSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblGnShipVium);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblGnShipVium;
        }

        partial void OnTblHpTinhTpDeleted(Models.DbAtVdc2.TblHpTinhTp item);

        public async Task<Models.DbAtVdc2.TblHpTinhTp> DeleteTblHpTinhTp(string tinhTpId)
        {
            var item = context.TblHpTinhTps
                              .Where(i => i.TinhTP_ID == tinhTpId)
                              .Include(i => i.TblGnAddressBooks)
                              .FirstOrDefault();

            OnTblHpTinhTpDeleted(item);

            context.TblHpTinhTps.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblHpTinhTpGet(Models.DbAtVdc2.TblHpTinhTp item);

        public async Task<Models.DbAtVdc2.TblHpTinhTp> GetTblHpTinhTpByTinhTpId(string tinhTpId)
        {
            var items = context.TblHpTinhTps
                              .AsNoTracking()
                              .Where(i => i.TinhTP_ID == tinhTpId);

            var item = items.FirstOrDefault();

            OnTblHpTinhTpGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblHpTinhTp> CancelTblHpTinhTpChanges(Models.DbAtVdc2.TblHpTinhTp item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblHpTinhTpUpdated(Models.DbAtVdc2.TblHpTinhTp item);

        public async Task<Models.DbAtVdc2.TblHpTinhTp> UpdateTblHpTinhTp(string tinhTpId, Models.DbAtVdc2.TblHpTinhTp tblHpTinhTp)
        {
            OnTblHpTinhTpUpdated(tblHpTinhTp);

            var item = context.TblHpTinhTps
                              .Where(i => i.TinhTP_ID == tinhTpId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblHpTinhTp);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblHpTinhTp;
        }

        partial void OnTblIcCategoryDeleted(Models.DbAtVdc2.TblIcCategory item);

        public async Task<Models.DbAtVdc2.TblIcCategory> DeleteTblIcCategory(string categoryId)
        {
            var item = context.TblIcCategories
                              .Where(i => i.Category_ID == categoryId)
                              .Include(i => i.TblIcInventories)
                              .FirstOrDefault();

            OnTblIcCategoryDeleted(item);

            context.TblIcCategories.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcCategoryGet(Models.DbAtVdc2.TblIcCategory item);

        public async Task<Models.DbAtVdc2.TblIcCategory> GetTblIcCategoryByCategoryId(string categoryId)
        {
            var items = context.TblIcCategories
                              .AsNoTracking()
                              .Where(i => i.Category_ID == categoryId);

            var item = items.FirstOrDefault();

            OnTblIcCategoryGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcCategory> CancelTblIcCategoryChanges(Models.DbAtVdc2.TblIcCategory item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcCategoryUpdated(Models.DbAtVdc2.TblIcCategory item);

        public async Task<Models.DbAtVdc2.TblIcCategory> UpdateTblIcCategory(string categoryId, Models.DbAtVdc2.TblIcCategory tblIcCategory)
        {
            OnTblIcCategoryUpdated(tblIcCategory);

            var item = context.TblIcCategories
                              .Where(i => i.Category_ID == categoryId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcCategory);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcCategory;
        }

        partial void OnTblIcClassificationDeleted(Models.DbAtVdc2.TblIcClassification item);

        public async Task<Models.DbAtVdc2.TblIcClassification> DeleteTblIcClassification(string classifiId)
        {
            var item = context.TblIcClassifications
                              .Where(i => i.Classifi_ID == classifiId)
                              .Include(i => i.TblIcInventories)
                              .FirstOrDefault();

            OnTblIcClassificationDeleted(item);

            context.TblIcClassifications.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcClassificationGet(Models.DbAtVdc2.TblIcClassification item);

        public async Task<Models.DbAtVdc2.TblIcClassification> GetTblIcClassificationByClassifiId(string classifiId)
        {
            var items = context.TblIcClassifications
                              .AsNoTracking()
                              .Where(i => i.Classifi_ID == classifiId);

            var item = items.FirstOrDefault();

            OnTblIcClassificationGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcClassification> CancelTblIcClassificationChanges(Models.DbAtVdc2.TblIcClassification item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcClassificationUpdated(Models.DbAtVdc2.TblIcClassification item);

        public async Task<Models.DbAtVdc2.TblIcClassification> UpdateTblIcClassification(string classifiId, Models.DbAtVdc2.TblIcClassification tblIcClassification)
        {
            OnTblIcClassificationUpdated(tblIcClassification);

            var item = context.TblIcClassifications
                              .Where(i => i.Classifi_ID == classifiId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcClassification);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcClassification;
        }

        partial void OnTblIcInventoryDeleted(Models.DbAtVdc2.TblIcInventory item);

        public async Task<Models.DbAtVdc2.TblIcInventory> DeleteTblIcInventory(int? inventorySeq)
        {
            var item = context.TblIcInventories
                              .Where(i => i.Inventory_SEQ == inventorySeq)
                              .Include(i => i.TblPoPurchaseOrderDetails)
                              .Include(i => i.TblPoApInvoicesDetails)
                              .Include(i => i.TblPoRrOrderDetails)
                              .Include(i => i.TblSoOrderDetails)
                              .FirstOrDefault();

            OnTblIcInventoryDeleted(item);

            context.TblIcInventories.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcInventoryGet(Models.DbAtVdc2.TblIcInventory item);

        public async Task<Models.DbAtVdc2.TblIcInventory> GetTblIcInventoryByInventorySeq(int? inventorySeq)
        {
            var items = context.TblIcInventories
                              .AsNoTracking()
                              .Where(i => i.Inventory_SEQ == inventorySeq);

            items = items.Include(i => i.TblIcWarehouse);

            items = items.Include(i => i.TblIcCategory);

            items = items.Include(i => i.TblIcClassification);

            items = items.Include(i => i.TblGnProduct);

            items = items.Include(i => i.TblIcUnit);

            var item = items.FirstOrDefault();

            OnTblIcInventoryGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcInventory> CancelTblIcInventoryChanges(Models.DbAtVdc2.TblIcInventory item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcInventoryUpdated(Models.DbAtVdc2.TblIcInventory item);

        public async Task<Models.DbAtVdc2.TblIcInventory> UpdateTblIcInventory(int? inventorySeq, Models.DbAtVdc2.TblIcInventory tblIcInventory)
        {
            OnTblIcInventoryUpdated(tblIcInventory);

            var item = context.TblIcInventories
                              .Where(i => i.Inventory_SEQ == inventorySeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcInventory);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcInventory;
        }

        partial void OnTblIcTransactionDeleted(Models.DbAtVdc2.TblIcTransaction item);

        public async Task<Models.DbAtVdc2.TblIcTransaction> DeleteTblIcTransaction(string transNo)
        {
            var item = context.TblIcTransactions
                              .Where(i => i.Trans_No == transNo)
                              .FirstOrDefault();

            OnTblIcTransactionDeleted(item);

            context.TblIcTransactions.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcTransactionGet(Models.DbAtVdc2.TblIcTransaction item);

        public async Task<Models.DbAtVdc2.TblIcTransaction> GetTblIcTransactionByTransNo(string transNo)
        {
            var items = context.TblIcTransactions
                              .AsNoTracking()
                              .Where(i => i.Trans_No == transNo);

            items = items.Include(i => i.TblIcTransactionType);

            items = items.Include(i => i.TblIcWarehouse);

            items = items.Include(i => i.TblGnProduct);

            var item = items.FirstOrDefault();

            OnTblIcTransactionGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcTransaction> CancelTblIcTransactionChanges(Models.DbAtVdc2.TblIcTransaction item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcTransactionUpdated(Models.DbAtVdc2.TblIcTransaction item);

        public async Task<Models.DbAtVdc2.TblIcTransaction> UpdateTblIcTransaction(string transNo, Models.DbAtVdc2.TblIcTransaction tblIcTransaction)
        {
            OnTblIcTransactionUpdated(tblIcTransaction);

            var item = context.TblIcTransactions
                              .Where(i => i.Trans_No == transNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcTransaction);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcTransaction;
        }

        partial void OnTblIcTransactionTypeDeleted(Models.DbAtVdc2.TblIcTransactionType item);

        public async Task<Models.DbAtVdc2.TblIcTransactionType> DeleteTblIcTransactionType(string transactionId)
        {
            var item = context.TblIcTransactionTypes
                              .Where(i => i.Transaction_ID == transactionId)
                              .Include(i => i.TblIcTransactions)
                              .FirstOrDefault();

            OnTblIcTransactionTypeDeleted(item);

            context.TblIcTransactionTypes.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcTransactionTypeGet(Models.DbAtVdc2.TblIcTransactionType item);

        public async Task<Models.DbAtVdc2.TblIcTransactionType> GetTblIcTransactionTypeByTransactionId(string transactionId)
        {
            var items = context.TblIcTransactionTypes
                              .AsNoTracking()
                              .Where(i => i.Transaction_ID == transactionId);

            var item = items.FirstOrDefault();

            OnTblIcTransactionTypeGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcTransactionType> CancelTblIcTransactionTypeChanges(Models.DbAtVdc2.TblIcTransactionType item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcTransactionTypeUpdated(Models.DbAtVdc2.TblIcTransactionType item);

        public async Task<Models.DbAtVdc2.TblIcTransactionType> UpdateTblIcTransactionType(string transactionId, Models.DbAtVdc2.TblIcTransactionType tblIcTransactionType)
        {
            OnTblIcTransactionTypeUpdated(tblIcTransactionType);

            var item = context.TblIcTransactionTypes
                              .Where(i => i.Transaction_ID == transactionId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcTransactionType);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcTransactionType;
        }

        partial void OnTblIcUnitDeleted(Models.DbAtVdc2.TblIcUnit item);

        public async Task<Models.DbAtVdc2.TblIcUnit> DeleteTblIcUnit(int? unitSeq)
        {
            var item = context.TblIcUnits
                              .Where(i => i.Unit_SEQ == unitSeq)
                              .Include(i => i.TblPoApInvoicesDetails)
                              .Include(i => i.TblIcInventories)
                              .FirstOrDefault();

            OnTblIcUnitDeleted(item);

            context.TblIcUnits.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcUnitGet(Models.DbAtVdc2.TblIcUnit item);

        public async Task<Models.DbAtVdc2.TblIcUnit> GetTblIcUnitByUnitSeq(int? unitSeq)
        {
            var items = context.TblIcUnits
                              .AsNoTracking()
                              .Where(i => i.Unit_SEQ == unitSeq);

            var item = items.FirstOrDefault();

            OnTblIcUnitGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcUnit> CancelTblIcUnitChanges(Models.DbAtVdc2.TblIcUnit item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcUnitUpdated(Models.DbAtVdc2.TblIcUnit item);

        public async Task<Models.DbAtVdc2.TblIcUnit> UpdateTblIcUnit(int? unitSeq, Models.DbAtVdc2.TblIcUnit tblIcUnit)
        {
            OnTblIcUnitUpdated(tblIcUnit);

            var item = context.TblIcUnits
                              .Where(i => i.Unit_SEQ == unitSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcUnit);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcUnit;
        }

        partial void OnTblIcWarehouseDeleted(Models.DbAtVdc2.TblIcWarehouse item);

        public async Task<Models.DbAtVdc2.TblIcWarehouse> DeleteTblIcWarehouse(string warehouseId)
        {
            var item = context.TblIcWarehouses
                              .Where(i => i.Warehouse_ID == warehouseId)
                              .Include(i => i.TblIcTransactions)
                              .Include(i => i.TblIcInventories)
                              .FirstOrDefault();

            OnTblIcWarehouseDeleted(item);

            context.TblIcWarehouses.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblIcWarehouseGet(Models.DbAtVdc2.TblIcWarehouse item);

        public async Task<Models.DbAtVdc2.TblIcWarehouse> GetTblIcWarehouseByWarehouseId(string warehouseId)
        {
            var items = context.TblIcWarehouses
                              .AsNoTracking()
                              .Where(i => i.Warehouse_ID == warehouseId);

            var item = items.FirstOrDefault();

            OnTblIcWarehouseGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblIcWarehouse> CancelTblIcWarehouseChanges(Models.DbAtVdc2.TblIcWarehouse item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblIcWarehouseUpdated(Models.DbAtVdc2.TblIcWarehouse item);

        public async Task<Models.DbAtVdc2.TblIcWarehouse> UpdateTblIcWarehouse(string warehouseId, Models.DbAtVdc2.TblIcWarehouse tblIcWarehouse)
        {
            OnTblIcWarehouseUpdated(tblIcWarehouse);

            var item = context.TblIcWarehouses
                              .Where(i => i.Warehouse_ID == warehouseId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblIcWarehouse);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblIcWarehouse;
        }

        partial void OnTblPoAccountPayableDeleted(Models.DbAtVdc2.TblPoAccountPayable item);

        public async Task<Models.DbAtVdc2.TblPoAccountPayable> DeleteTblPoAccountPayable(string apNo)
        {
            var item = context.TblPoAccountPayables
                              .Where(i => i.AP_No == apNo)
                              .FirstOrDefault();

            OnTblPoAccountPayableDeleted(item);

            context.TblPoAccountPayables.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoAccountPayableGet(Models.DbAtVdc2.TblPoAccountPayable item);

        public async Task<Models.DbAtVdc2.TblPoAccountPayable> GetTblPoAccountPayableByApNo(string apNo)
        {
            var items = context.TblPoAccountPayables
                              .AsNoTracking()
                              .Where(i => i.AP_No == apNo);

            items = items.Include(i => i.TblPoVendor);

            items = items.Include(i => i.TblGnDepartment);

            var item = items.FirstOrDefault();

            OnTblPoAccountPayableGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoAccountPayable> CancelTblPoAccountPayableChanges(Models.DbAtVdc2.TblPoAccountPayable item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoAccountPayableUpdated(Models.DbAtVdc2.TblPoAccountPayable item);

        public async Task<Models.DbAtVdc2.TblPoAccountPayable> UpdateTblPoAccountPayable(string apNo, Models.DbAtVdc2.TblPoAccountPayable tblPoAccountPayable)
        {
            OnTblPoAccountPayableUpdated(tblPoAccountPayable);

            var item = context.TblPoAccountPayables
                              .Where(i => i.AP_No == apNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoAccountPayable);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoAccountPayable;
        }

        partial void OnTblPoAccountsPayableAdjustmentDeleted(Models.DbAtVdc2.TblPoAccountsPayableAdjustment item);

        public async Task<Models.DbAtVdc2.TblPoAccountsPayableAdjustment> DeleteTblPoAccountsPayableAdjustment(string voucherNo)
        {
            var item = context.TblPoAccountsPayableAdjustments
                              .Where(i => i.Voucher_No == voucherNo)
                              .FirstOrDefault();

            OnTblPoAccountsPayableAdjustmentDeleted(item);

            context.TblPoAccountsPayableAdjustments.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoAccountsPayableAdjustmentGet(Models.DbAtVdc2.TblPoAccountsPayableAdjustment item);

        public async Task<Models.DbAtVdc2.TblPoAccountsPayableAdjustment> GetTblPoAccountsPayableAdjustmentByVoucherNo(string voucherNo)
        {
            var items = context.TblPoAccountsPayableAdjustments
                              .AsNoTracking()
                              .Where(i => i.Voucher_No == voucherNo);

            var item = items.FirstOrDefault();

            OnTblPoAccountsPayableAdjustmentGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoAccountsPayableAdjustment> CancelTblPoAccountsPayableAdjustmentChanges(Models.DbAtVdc2.TblPoAccountsPayableAdjustment item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoAccountsPayableAdjustmentUpdated(Models.DbAtVdc2.TblPoAccountsPayableAdjustment item);

        public async Task<Models.DbAtVdc2.TblPoAccountsPayableAdjustment> UpdateTblPoAccountsPayableAdjustment(string voucherNo, Models.DbAtVdc2.TblPoAccountsPayableAdjustment tblPoAccountsPayableAdjustment)
        {
            OnTblPoAccountsPayableAdjustmentUpdated(tblPoAccountsPayableAdjustment);

            var item = context.TblPoAccountsPayableAdjustments
                              .Where(i => i.Voucher_No == voucherNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoAccountsPayableAdjustment);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoAccountsPayableAdjustment;
        }

        partial void OnTblPoApInvoiceDeleted(Models.DbAtVdc2.TblPoApInvoice item);

        public async Task<Models.DbAtVdc2.TblPoApInvoice> DeleteTblPoApInvoice(string vendorId, string invoiceNo)
        {
            var item = context.TblPoApInvoices
                              .Where(i => i.Vendor_ID == vendorId && i.Invoice_No == invoiceNo)
                              .FirstOrDefault();

            OnTblPoApInvoiceDeleted(item);

            context.TblPoApInvoices.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoApInvoiceGet(Models.DbAtVdc2.TblPoApInvoice item);

        public async Task<Models.DbAtVdc2.TblPoApInvoice> GetTblPoApInvoiceByVendorIdAndInvoiceNo(string vendorId, string invoiceNo)
        {
            var items = context.TblPoApInvoices
                              .AsNoTracking()
                              .Where(i => i.Vendor_ID == vendorId && i.Invoice_No == invoiceNo);

            items = items.Include(i => i.TblPoVendor);

            var item = items.FirstOrDefault();

            OnTblPoApInvoiceGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoApInvoice> CancelTblPoApInvoiceChanges(Models.DbAtVdc2.TblPoApInvoice item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoApInvoiceUpdated(Models.DbAtVdc2.TblPoApInvoice item);

        public async Task<Models.DbAtVdc2.TblPoApInvoice> UpdateTblPoApInvoice(string vendorId, string invoiceNo, Models.DbAtVdc2.TblPoApInvoice tblPoApInvoice)
        {
            OnTblPoApInvoiceUpdated(tblPoApInvoice);

            var item = context.TblPoApInvoices
                              .Where(i => i.Vendor_ID == vendorId && i.Invoice_No == invoiceNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoApInvoice);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoApInvoice;
        }

        partial void OnTblPoApInvoicesDetailDeleted(Models.DbAtVdc2.TblPoApInvoicesDetail item);

        public async Task<Models.DbAtVdc2.TblPoApInvoicesDetail> DeleteTblPoApInvoicesDetail(string vendorId, string invoiceNo)
        {
            var item = context.TblPoApInvoicesDetails
                              .Where(i => i.Vendor_ID == vendorId && i.Invoice_No == invoiceNo)
                              .FirstOrDefault();

            OnTblPoApInvoicesDetailDeleted(item);

            context.TblPoApInvoicesDetails.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoApInvoicesDetailGet(Models.DbAtVdc2.TblPoApInvoicesDetail item);

        public async Task<Models.DbAtVdc2.TblPoApInvoicesDetail> GetTblPoApInvoicesDetailByVendorIdAndInvoiceNo(string vendorId, string invoiceNo)
        {
            var items = context.TblPoApInvoicesDetails
                              .AsNoTracking()
                              .Where(i => i.Vendor_ID == vendorId && i.Invoice_No == invoiceNo);

            items = items.Include(i => i.TblPoVendor);

            items = items.Include(i => i.TblIcInventory);

            items = items.Include(i => i.TblIcUnit);

            var item = items.FirstOrDefault();

            OnTblPoApInvoicesDetailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoApInvoicesDetail> CancelTblPoApInvoicesDetailChanges(Models.DbAtVdc2.TblPoApInvoicesDetail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoApInvoicesDetailUpdated(Models.DbAtVdc2.TblPoApInvoicesDetail item);

        public async Task<Models.DbAtVdc2.TblPoApInvoicesDetail> UpdateTblPoApInvoicesDetail(string vendorId, string invoiceNo, Models.DbAtVdc2.TblPoApInvoicesDetail tblPoApInvoicesDetail)
        {
            OnTblPoApInvoicesDetailUpdated(tblPoApInvoicesDetail);

            var item = context.TblPoApInvoicesDetails
                              .Where(i => i.Vendor_ID == vendorId && i.Invoice_No == invoiceNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoApInvoicesDetail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoApInvoicesDetail;
        }

        partial void OnTblPoCashDisbursementDeleted(Models.DbAtVdc2.TblPoCashDisbursement item);

        public async Task<Models.DbAtVdc2.TblPoCashDisbursement> DeleteTblPoCashDisbursement(string poCashDisbNo)
        {
            var item = context.TblPoCashDisbursements
                              .Where(i => i.PO_CashDisb_No == poCashDisbNo)
                              .FirstOrDefault();

            OnTblPoCashDisbursementDeleted(item);

            context.TblPoCashDisbursements.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoCashDisbursementGet(Models.DbAtVdc2.TblPoCashDisbursement item);

        public async Task<Models.DbAtVdc2.TblPoCashDisbursement> GetTblPoCashDisbursementByPoCashDisbNo(string poCashDisbNo)
        {
            var items = context.TblPoCashDisbursements
                              .AsNoTracking()
                              .Where(i => i.PO_CashDisb_No == poCashDisbNo);

            items = items.Include(i => i.TblGnAddressBook);

            var item = items.FirstOrDefault();

            OnTblPoCashDisbursementGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoCashDisbursement> CancelTblPoCashDisbursementChanges(Models.DbAtVdc2.TblPoCashDisbursement item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoCashDisbursementUpdated(Models.DbAtVdc2.TblPoCashDisbursement item);

        public async Task<Models.DbAtVdc2.TblPoCashDisbursement> UpdateTblPoCashDisbursement(string poCashDisbNo, Models.DbAtVdc2.TblPoCashDisbursement tblPoCashDisbursement)
        {
            OnTblPoCashDisbursementUpdated(tblPoCashDisbursement);

            var item = context.TblPoCashDisbursements
                              .Where(i => i.PO_CashDisb_No == poCashDisbNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoCashDisbursement);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoCashDisbursement;
        }

        partial void OnTblPoOrderStatusDeleted(Models.DbAtVdc2.TblPoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblPoOrderStatus> DeleteTblPoOrderStatus(string poStatusId)
        {
            var item = context.TblPoOrderStatuses
                              .Where(i => i.POStatus_ID == poStatusId)
                              .Include(i => i.TblPoPurchaseOrders)
                              .FirstOrDefault();

            OnTblPoOrderStatusDeleted(item);

            context.TblPoOrderStatuses.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoOrderStatusGet(Models.DbAtVdc2.TblPoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblPoOrderStatus> GetTblPoOrderStatusByPoStatusId(string poStatusId)
        {
            var items = context.TblPoOrderStatuses
                              .AsNoTracking()
                              .Where(i => i.POStatus_ID == poStatusId);

            var item = items.FirstOrDefault();

            OnTblPoOrderStatusGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoOrderStatus> CancelTblPoOrderStatusChanges(Models.DbAtVdc2.TblPoOrderStatus item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoOrderStatusUpdated(Models.DbAtVdc2.TblPoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblPoOrderStatus> UpdateTblPoOrderStatus(string poStatusId, Models.DbAtVdc2.TblPoOrderStatus tblPoOrderStatus)
        {
            OnTblPoOrderStatusUpdated(tblPoOrderStatus);

            var item = context.TblPoOrderStatuses
                              .Where(i => i.POStatus_ID == poStatusId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoOrderStatus);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoOrderStatus;
        }

        partial void OnTblPoPurchaseOrderDeleted(Models.DbAtVdc2.TblPoPurchaseOrder item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrder> DeleteTblPoPurchaseOrder(string poId)
        {
            var item = context.TblPoPurchaseOrders
                              .Where(i => i.PO_ID == poId)
                              .Include(i => i.TblPoPurchaseOrderDetails)
                              .FirstOrDefault();

            OnTblPoPurchaseOrderDeleted(item);

            context.TblPoPurchaseOrders.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoPurchaseOrderGet(Models.DbAtVdc2.TblPoPurchaseOrder item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrder> GetTblPoPurchaseOrderByPoId(string poId)
        {
            var items = context.TblPoPurchaseOrders
                              .AsNoTracking()
                              .Where(i => i.PO_ID == poId);

            items = items.Include(i => i.TblGnAddressBook);

            items = items.Include(i => i.TblPoOrderStatus);

            items = items.Include(i => i.TblPoVendor);

            items = items.Include(i => i.TblGnIncoterm);

            items = items.Include(i => i.TblGnShipVium);

            items = items.Include(i => i.TblGnPaymentTerm);

            items = items.Include(i => i.TblGnPaymentType);

            items = items.Include(i => i.TblGnAddressBook1);

            items = items.Include(i => i.TblGnDepartment);

            var item = items.FirstOrDefault();

            OnTblPoPurchaseOrderGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrder> CancelTblPoPurchaseOrderChanges(Models.DbAtVdc2.TblPoPurchaseOrder item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoPurchaseOrderUpdated(Models.DbAtVdc2.TblPoPurchaseOrder item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrder> UpdateTblPoPurchaseOrder(string poId, Models.DbAtVdc2.TblPoPurchaseOrder tblPoPurchaseOrder)
        {
            OnTblPoPurchaseOrderUpdated(tblPoPurchaseOrder);

            var item = context.TblPoPurchaseOrders
                              .Where(i => i.PO_ID == poId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoPurchaseOrder);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoPurchaseOrder;
        }

        partial void OnTblPoPurchaseOrderDetailDeleted(Models.DbAtVdc2.TblPoPurchaseOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrderDetail> DeleteTblPoPurchaseOrderDetail(string poFk, int? inventoryFk)
        {
            var item = context.TblPoPurchaseOrderDetails
                              .Where(i => i.PO_FK == poFk && i.Inventory_FK == inventoryFk)
                              .FirstOrDefault();

            OnTblPoPurchaseOrderDetailDeleted(item);

            context.TblPoPurchaseOrderDetails.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoPurchaseOrderDetailGet(Models.DbAtVdc2.TblPoPurchaseOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrderDetail> GetTblPoPurchaseOrderDetailByPoFkAndInventoryFk(string poFk, int? inventoryFk)
        {
            var items = context.TblPoPurchaseOrderDetails
                              .AsNoTracking()
                              .Where(i => i.PO_FK == poFk && i.Inventory_FK == inventoryFk);

            items = items.Include(i => i.TblPoPurchaseOrder);

            items = items.Include(i => i.TblIcInventory);

            var item = items.FirstOrDefault();

            OnTblPoPurchaseOrderDetailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrderDetail> CancelTblPoPurchaseOrderDetailChanges(Models.DbAtVdc2.TblPoPurchaseOrderDetail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoPurchaseOrderDetailUpdated(Models.DbAtVdc2.TblPoPurchaseOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoPurchaseOrderDetail> UpdateTblPoPurchaseOrderDetail(string poFk, int? inventoryFk, Models.DbAtVdc2.TblPoPurchaseOrderDetail tblPoPurchaseOrderDetail)
        {
            OnTblPoPurchaseOrderDetailUpdated(tblPoPurchaseOrderDetail);

            var item = context.TblPoPurchaseOrderDetails
                              .Where(i => i.PO_FK == poFk && i.Inventory_FK == inventoryFk)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoPurchaseOrderDetail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoPurchaseOrderDetail;
        }

        partial void OnTblPoRecReportDeleted(Models.DbAtVdc2.TblPoRecReport item);

        public async Task<Models.DbAtVdc2.TblPoRecReport> DeleteTblPoRecReport(string rrNo)
        {
            var item = context.TblPoRecReports
                              .Where(i => i.RR_No == rrNo)
                              .Include(i => i.TblPoRrOrderDetails)
                              .FirstOrDefault();

            OnTblPoRecReportDeleted(item);

            context.TblPoRecReports.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoRecReportGet(Models.DbAtVdc2.TblPoRecReport item);

        public async Task<Models.DbAtVdc2.TblPoRecReport> GetTblPoRecReportByRrNo(string rrNo)
        {
            var items = context.TblPoRecReports
                              .AsNoTracking()
                              .Where(i => i.RR_No == rrNo);

            items = items.Include(i => i.TblGnAddressBook);

            items = items.Include(i => i.TblPoVendor);

            var item = items.FirstOrDefault();

            OnTblPoRecReportGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoRecReport> CancelTblPoRecReportChanges(Models.DbAtVdc2.TblPoRecReport item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoRecReportUpdated(Models.DbAtVdc2.TblPoRecReport item);

        public async Task<Models.DbAtVdc2.TblPoRecReport> UpdateTblPoRecReport(string rrNo, Models.DbAtVdc2.TblPoRecReport tblPoRecReport)
        {
            OnTblPoRecReportUpdated(tblPoRecReport);

            var item = context.TblPoRecReports
                              .Where(i => i.RR_No == rrNo)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoRecReport);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoRecReport;
        }

        partial void OnTblPoRrOrderDetailDeleted(Models.DbAtVdc2.TblPoRrOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoRrOrderDetail> DeleteTblPoRrOrderDetail(string rrFk, int? inventoryFk)
        {
            var item = context.TblPoRrOrderDetails
                              .Where(i => i.RR_FK == rrFk && i.Inventory_FK == inventoryFk)
                              .FirstOrDefault();

            OnTblPoRrOrderDetailDeleted(item);

            context.TblPoRrOrderDetails.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoRrOrderDetailGet(Models.DbAtVdc2.TblPoRrOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoRrOrderDetail> GetTblPoRrOrderDetailByRrFkAndInventoryFk(string rrFk, int? inventoryFk)
        {
            var items = context.TblPoRrOrderDetails
                              .AsNoTracking()
                              .Where(i => i.RR_FK == rrFk && i.Inventory_FK == inventoryFk);

            items = items.Include(i => i.TblPoRecReport);

            items = items.Include(i => i.TblIcInventory);

            var item = items.FirstOrDefault();

            OnTblPoRrOrderDetailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoRrOrderDetail> CancelTblPoRrOrderDetailChanges(Models.DbAtVdc2.TblPoRrOrderDetail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoRrOrderDetailUpdated(Models.DbAtVdc2.TblPoRrOrderDetail item);

        public async Task<Models.DbAtVdc2.TblPoRrOrderDetail> UpdateTblPoRrOrderDetail(string rrFk, int? inventoryFk, Models.DbAtVdc2.TblPoRrOrderDetail tblPoRrOrderDetail)
        {
            OnTblPoRrOrderDetailUpdated(tblPoRrOrderDetail);

            var item = context.TblPoRrOrderDetails
                              .Where(i => i.RR_FK == rrFk && i.Inventory_FK == inventoryFk)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoRrOrderDetail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoRrOrderDetail;
        }

        partial void OnTblPoVendorDeleted(Models.DbAtVdc2.TblPoVendor item);

        public async Task<Models.DbAtVdc2.TblPoVendor> DeleteTblPoVendor(string vendorId)
        {
            var item = context.TblPoVendors
                              .Where(i => i.Vendor_ID == vendorId)
                              .Include(i => i.TblPoPurchaseOrders)
                              .Include(i => i.TblPoAccountPayables)
                              .Include(i => i.TblPoApInvoices)
                              .Include(i => i.TblPoApInvoicesDetails)
                              .Include(i => i.TblPoRecReports)
                              .FirstOrDefault();

            OnTblPoVendorDeleted(item);

            context.TblPoVendors.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblPoVendorGet(Models.DbAtVdc2.TblPoVendor item);

        public async Task<Models.DbAtVdc2.TblPoVendor> GetTblPoVendorByVendorId(string vendorId)
        {
            var items = context.TblPoVendors
                              .AsNoTracking()
                              .Where(i => i.Vendor_ID == vendorId);

            items = items.Include(i => i.TblGnAddressBook);

            var item = items.FirstOrDefault();

            OnTblPoVendorGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblPoVendor> CancelTblPoVendorChanges(Models.DbAtVdc2.TblPoVendor item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblPoVendorUpdated(Models.DbAtVdc2.TblPoVendor item);

        public async Task<Models.DbAtVdc2.TblPoVendor> UpdateTblPoVendor(string vendorId, Models.DbAtVdc2.TblPoVendor tblPoVendor)
        {
            OnTblPoVendorUpdated(tblPoVendor);

            var item = context.TblPoVendors
                              .Where(i => i.Vendor_ID == vendorId)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblPoVendor);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblPoVendor;
        }

        partial void OnTblSoCustomerDeleted(Models.DbAtVdc2.TblSoCustomer item);

        public async Task<Models.DbAtVdc2.TblSoCustomer> DeleteTblSoCustomer(int? customerSeq)
        {
            var item = context.TblSoCustomers
                              .Where(i => i.Customer_SEQ == customerSeq)
                              .Include(i => i.TblSoSalesOrders)
                              .FirstOrDefault();

            OnTblSoCustomerDeleted(item);

            context.TblSoCustomers.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblSoCustomerGet(Models.DbAtVdc2.TblSoCustomer item);

        public async Task<Models.DbAtVdc2.TblSoCustomer> GetTblSoCustomerByCustomerSeq(int? customerSeq)
        {
            var items = context.TblSoCustomers
                              .AsNoTracking()
                              .Where(i => i.Customer_SEQ == customerSeq);

            items = items.Include(i => i.TblGnAddressBook);

            items = items.Include(i => i.TblGnPaymentTerm);

            items = items.Include(i => i.TblGnPaymentType);

            var item = items.FirstOrDefault();

            OnTblSoCustomerGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblSoCustomer> CancelTblSoCustomerChanges(Models.DbAtVdc2.TblSoCustomer item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblSoCustomerUpdated(Models.DbAtVdc2.TblSoCustomer item);

        public async Task<Models.DbAtVdc2.TblSoCustomer> UpdateTblSoCustomer(int? customerSeq, Models.DbAtVdc2.TblSoCustomer tblSoCustomer)
        {
            OnTblSoCustomerUpdated(tblSoCustomer);

            var item = context.TblSoCustomers
                              .Where(i => i.Customer_SEQ == customerSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblSoCustomer);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblSoCustomer;
        }

        partial void OnTblSoOrderDetailDeleted(Models.DbAtVdc2.TblSoOrderDetail item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetail> DeleteTblSoOrderDetail(int? soDetailSeq)
        {
            var item = context.TblSoOrderDetails
                              .Where(i => i.SODetail_SEQ == soDetailSeq)
                              .FirstOrDefault();

            OnTblSoOrderDetailDeleted(item);

            context.TblSoOrderDetails.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblSoOrderDetailGet(Models.DbAtVdc2.TblSoOrderDetail item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetail> GetTblSoOrderDetailBySoDetailSeq(int? soDetailSeq)
        {
            var items = context.TblSoOrderDetails
                              .AsNoTracking()
                              .Where(i => i.SODetail_SEQ == soDetailSeq);

            items = items.Include(i => i.TblSoOrderDetailStatus);

            items = items.Include(i => i.TblSoSalesOrder);

            items = items.Include(i => i.TblIcInventory);

            var item = items.FirstOrDefault();

            OnTblSoOrderDetailGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblSoOrderDetail> CancelTblSoOrderDetailChanges(Models.DbAtVdc2.TblSoOrderDetail item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblSoOrderDetailUpdated(Models.DbAtVdc2.TblSoOrderDetail item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetail> UpdateTblSoOrderDetail(int? soDetailSeq, Models.DbAtVdc2.TblSoOrderDetail tblSoOrderDetail)
        {
            OnTblSoOrderDetailUpdated(tblSoOrderDetail);

            var item = context.TblSoOrderDetails
                              .Where(i => i.SODetail_SEQ == soDetailSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblSoOrderDetail);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblSoOrderDetail;
        }

        partial void OnTblSoOrderDetailStatusDeleted(Models.DbAtVdc2.TblSoOrderDetailStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetailStatus> DeleteTblSoOrderDetailStatus(int? soDetailStatusSeq)
        {
            var item = context.TblSoOrderDetailStatuses
                              .Where(i => i.SODetailStatus_SEQ == soDetailStatusSeq)
                              .Include(i => i.TblSoOrderDetails)
                              .FirstOrDefault();

            OnTblSoOrderDetailStatusDeleted(item);

            context.TblSoOrderDetailStatuses.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblSoOrderDetailStatusGet(Models.DbAtVdc2.TblSoOrderDetailStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetailStatus> GetTblSoOrderDetailStatusBySoDetailStatusSeq(int? soDetailStatusSeq)
        {
            var items = context.TblSoOrderDetailStatuses
                              .AsNoTracking()
                              .Where(i => i.SODetailStatus_SEQ == soDetailStatusSeq);

            var item = items.FirstOrDefault();

            OnTblSoOrderDetailStatusGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblSoOrderDetailStatus> CancelTblSoOrderDetailStatusChanges(Models.DbAtVdc2.TblSoOrderDetailStatus item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblSoOrderDetailStatusUpdated(Models.DbAtVdc2.TblSoOrderDetailStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderDetailStatus> UpdateTblSoOrderDetailStatus(int? soDetailStatusSeq, Models.DbAtVdc2.TblSoOrderDetailStatus tblSoOrderDetailStatus)
        {
            OnTblSoOrderDetailStatusUpdated(tblSoOrderDetailStatus);

            var item = context.TblSoOrderDetailStatuses
                              .Where(i => i.SODetailStatus_SEQ == soDetailStatusSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblSoOrderDetailStatus);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblSoOrderDetailStatus;
        }

        partial void OnTblSoOrderStatusDeleted(Models.DbAtVdc2.TblSoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderStatus> DeleteTblSoOrderStatus(int? soStatusSeq)
        {
            var item = context.TblSoOrderStatuses
                              .Where(i => i.SOStatus_SEQ == soStatusSeq)
                              .Include(i => i.TblSoSalesOrders)
                              .FirstOrDefault();

            OnTblSoOrderStatusDeleted(item);

            context.TblSoOrderStatuses.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblSoOrderStatusGet(Models.DbAtVdc2.TblSoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderStatus> GetTblSoOrderStatusBySoStatusSeq(int? soStatusSeq)
        {
            var items = context.TblSoOrderStatuses
                              .AsNoTracking()
                              .Where(i => i.SOStatus_SEQ == soStatusSeq);

            var item = items.FirstOrDefault();

            OnTblSoOrderStatusGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblSoOrderStatus> CancelTblSoOrderStatusChanges(Models.DbAtVdc2.TblSoOrderStatus item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblSoOrderStatusUpdated(Models.DbAtVdc2.TblSoOrderStatus item);

        public async Task<Models.DbAtVdc2.TblSoOrderStatus> UpdateTblSoOrderStatus(int? soStatusSeq, Models.DbAtVdc2.TblSoOrderStatus tblSoOrderStatus)
        {
            OnTblSoOrderStatusUpdated(tblSoOrderStatus);

            var item = context.TblSoOrderStatuses
                              .Where(i => i.SOStatus_SEQ == soStatusSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblSoOrderStatus);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblSoOrderStatus;
        }

        partial void OnTblSoSalesOrderDeleted(Models.DbAtVdc2.TblSoSalesOrder item);

        public async Task<Models.DbAtVdc2.TblSoSalesOrder> DeleteTblSoSalesOrder(int? soSeq)
        {
            var item = context.TblSoSalesOrders
                              .Where(i => i.SO_SEQ == soSeq)
                              .Include(i => i.TblSoOrderDetails)
                              .FirstOrDefault();

            OnTblSoSalesOrderDeleted(item);

            context.TblSoSalesOrders.Remove(item);
            context.SaveChanges();

            return item;
        }

        partial void OnTblSoSalesOrderGet(Models.DbAtVdc2.TblSoSalesOrder item);

        public async Task<Models.DbAtVdc2.TblSoSalesOrder> GetTblSoSalesOrderBySoSeq(int? soSeq)
        {
            var items = context.TblSoSalesOrders
                              .AsNoTracking()
                              .Where(i => i.SO_SEQ == soSeq);

            items = items.Include(i => i.TblSoOrderStatus);

            items = items.Include(i => i.TblSoCustomer);

            items = items.Include(i => i.TblGnShipVium);

            items = items.Include(i => i.TblGnPaymentTerm);

            items = items.Include(i => i.TblGnPaymentType);

            var item = items.FirstOrDefault();

            OnTblSoSalesOrderGet(item);

            return await Task.FromResult(item);
        }

        public async Task<Models.DbAtVdc2.TblSoSalesOrder> CancelTblSoSalesOrderChanges(Models.DbAtVdc2.TblSoSalesOrder item)
        {
            var entity = context.Entry(item);
            entity.CurrentValues.SetValues(entity.OriginalValues);
            entity.State = EntityState.Unchanged;

            return item;
        }

        partial void OnTblSoSalesOrderUpdated(Models.DbAtVdc2.TblSoSalesOrder item);

        public async Task<Models.DbAtVdc2.TblSoSalesOrder> UpdateTblSoSalesOrder(int? soSeq, Models.DbAtVdc2.TblSoSalesOrder tblSoSalesOrder)
        {
            OnTblSoSalesOrderUpdated(tblSoSalesOrder);

            var item = context.TblSoSalesOrders
                              .Where(i => i.SO_SEQ == soSeq)
                              .First();
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(tblSoSalesOrder);
            entry.State = EntityState.Modified;
            context.SaveChanges();

            return tblSoSalesOrder;
        }
    }
}
