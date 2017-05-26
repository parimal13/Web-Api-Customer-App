using System;
using Web_Api_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntity
{
    public class DataAccess
    {
        DBWebApiTestEntities DB = new DBWebApiTestEntities();
        public bool AddCustomer(string Name, string No, string Address)
        {
            try
            {
                Customer C = new Customer();
                C.Name = Name;
                C.PhoneNo = No;
                C.Address = Address;
                DB.Customers.Add(C);
                DB.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                throw new System.Exception("There is some error.");
            }
        }
        public List<CCustomer> GetCustomerList()
        {
            try
            {                
                var CList = (from c in DB.Customers
                             select new CCustomer { Id=c.Id, Name = c.Name, Address = c.Address, PhoneNo = c.PhoneNo });
                return CList.ToList<CCustomer>();
            }
            catch (Exception Ex)
            {
                throw new System.Exception("There is some error.");
            }            
        }
        public CCustomer GetCustomer(int Id)
        {
            CCustomer Cust = new CCustomer();
            try
            {
                //Cust = DB.Customers.Where(x => x.Id == Id).FirstOrDefault();
                Cust = (from c in DB.Customers
                        where c.Id == Id
                        select new CCustomer {Id=c.Id, Name=c.Name,Address=c.Address,PhoneNo=c.PhoneNo }).FirstOrDefault();
            }
            catch (Exception Ex)
            {
                throw new System.Exception("There is some error.");
            }
            return Cust;
        }
        public bool DeleteCustomer(int Id)
        {
            try
            {
                Customer Cust = DB.Customers.Where(x => x.Id == Id).FirstOrDefault();
                if (Cust != null)
                {
                    DB.Customers.Attach(Cust);
                    DB.Customers.Remove(Cust);
                    DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                throw new System.Exception("There is some error.");
            }
        }
        public bool UpdateCustomer(int id, string Name, string No, string Address)
        {
            try
            {
                Customer Cust = DB.Customers.Where(x => x.Id == id).FirstOrDefault();
                if (Cust != null)
                {
                    Cust.Name = Name;
                    Cust.PhoneNo = No;
                    Cust.Address = Address;
                    DB.Entry(Cust).State = System.Data.EntityState.Modified;
                    DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                throw new System.Exception("There is some error.");
            }
        }
    }
}
