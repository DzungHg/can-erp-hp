using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace CanErp2.Pages
{
    public partial class AddTblSoCustomerComponent
    {
        public void FillSomeDatas(int? contactID)
        {
            const int totalLengthOfCustomerID = 9; //gồm cả ký tự C
            int total0CharAdded;
            string str0;

            total0CharAdded = totalLengthOfCustomerID - contactID.ToString().Length - 1; //Trừ 1 là bỏ C để thêm tổng số 0

            for (int i = 0; i < total0CharAdded; i++)
            {
                str0 = string.Create()
            }

            this.InitCustomerID = string.Format("C000{0}",  contactID);
            var addressContact = getTblGnAddressBooksResult.Where(x => x.AddressBook_SEQ == contactID).FirstOrDefault();

            //điền dữ liệu
            this.InitCustFirstName = addressContact.FirstName;
            this.InitCustLastName = addressContact.LastName;
           
        }
        public string InitCustomerID { get; set; }
        public string InitCustFirstName { get; set; }
        public string InitCustLastName { get; set; }

    }
}
