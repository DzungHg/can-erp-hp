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
            //Tổng char của customerID là 10
            const int totalLengthOfCustomerID = 10; //gồm cả ký tự C
            int total0CharAdded;
            string str0 = "C"; //Thêm C trước

            total0CharAdded = totalLengthOfCustomerID - contactID.ToString().Length - 1; //Trừ đi C đã add vô rồi

            for (int i = 0; i < total0CharAdded; i++)
            {
                str0 += "0";
            }

            if (contactID > 0)
            {
                this.InitCustomerID = string.Format("{0}{1}", str0, contactID);
                var addressContact = getTblGnAddressBooksResult.Where(x => x.AddressBook_SEQ == contactID).FirstOrDefault();

                //điền dữ liệu
                this.InitCustFirstName = addressContact.FirstName;
                this.InitCustLastName = addressContact.LastName;
            }
           
        }
        public string InitCustomerID { get; set; }
        public string InitCustFirstName { get; set; }
        public string InitCustLastName { get; set; }

    }
}
