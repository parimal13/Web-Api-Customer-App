using System;
using Web_Api_App;
using DBEntity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Api_App.Models;

namespace BussinesLogics
{
    public class BusinessLogic
    {
        DataAccess DA = new DataAccess();
        public List<CCustomer> GetCustomers()
        {
            return DA.GetCustomerList();
        }
        public CCustomer GetCustomerById(int CId)
        {
            return DA.GetCustomer(CId);
        }
        public bool InsertCustomer(string Name, string No, string Address)
        {
            return DA.AddCustomer(Name, No, Address);
        }
        public bool DeleteCustomerById(int Id)
        {
            return DA.DeleteCustomer(Id);
        }
        public bool UpdateCustomerDetail(int id, string Name, string No, string Address)
        {
            return DA.UpdateCustomer(id, Name, No, Address);
        }
    }
}
