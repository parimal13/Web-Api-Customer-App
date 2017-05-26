using BussinesLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api_App.Models;

namespace Web_Api_App.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        BusinessLogic c = new BusinessLogic();
        ResponceDetail RD = new ResponceDetail();
        [Authorize]
        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {                
                    List<CCustomer> CList = c.GetCustomers();
                    if (CList != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, CList);
                    }
                    else
                    {
                        RD.Status = "Success";
                        RD.Message = "Customer not found";
                        return Request.CreateResponse(HttpStatusCode.NotFound, RD);
                    }          
            }
            catch (Exception ex)
            {
                RD.Status = "Unsuccess";
                RD.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
            }
        }
        public HttpResponseMessage Get(int id)
        {
            try
            {
               
                    CCustomer C = c.GetCustomerById(id);
                    if (C != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, C);
                    }
                    else
                    {
                        RD.Status = "Unsuccess";
                        RD.Message = "Customer not found";
                        return Request.CreateResponse(HttpStatusCode.NotFound, RD);
                    }              
            }
            catch (Exception Ex)
            {
                RD.Status = "Unsuccess";
                RD.Message = Ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
            }
        }
        public HttpResponseMessage Post(string Name, string No, string Address)
        {
            try
            {               
                    if (c.InsertCustomer(Name, No, Address))
                    {
                        RD.Status = "Success";
                        RD.Message = "Customer Created !";
                        return Request.CreateResponse(HttpStatusCode.OK, RD);
                    }
                    else
                    {
                        RD.Status = "Unsuccess";
                        RD.Message = "You can not Create.";
                        return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
                    }              
            }
            catch (Exception Ex)
            {
                RD.Status = "Unsuccess";
                RD.Message = Ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
            }
        }
        public HttpResponseMessage Put(int Id, string Name, string No, string Address)
        {
            try
            {               
                    if (c.UpdateCustomerDetail(Id, Name, No, Address))
                    {
                        RD.Status = "Success";
                        RD.Message = "Customer updated !";
                        return Request.CreateResponse(HttpStatusCode.OK, RD);
                    }
                    else
                    {
                        RD.Status = "Unsuccess";
                        RD.Message = "You can not Update.";
                        return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
                    }               
            }
            catch (Exception Ex)
            {
                RD.Status = "Unsuccess";
                RD.Message = Ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {               
                if (c.DeleteCustomerById(id))
                {
                    RD.Status = "Success";
                    RD.Message = "Customer deleted !";
                    return Request.CreateResponse(HttpStatusCode.OK, RD);
                }
                else
                {
                    RD.Status = "Unsuccess";
                    RD.Message = "You can not delete.";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
                }              
            }
            catch (Exception Ex)
            {
                RD.Status = "Unsuccess";
                RD.Message = Ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, RD);
            }
        }
    }
}
