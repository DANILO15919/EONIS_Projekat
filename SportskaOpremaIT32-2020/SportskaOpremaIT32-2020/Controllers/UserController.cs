using SportskaOpremaIT32_2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportskaOpremaIT32_2020.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
       ProdavnicaOdeceIT322020Entities1 db = new ProdavnicaOdeceIT322020Entities1 ();

        [HttpPost,Route("signup")]
        public HttpResponseMessage SignUp([FromBody] tblUser user) 
        
        { 
            try
            {
                tblUser userObj = db.tblUser.Where(u =>  u.Email == user.Email).FirstOrDefault();
                if(userObj == null)
                {
                    user.Email = "email";
                    db.tblUser.Add(user);
                    db.SaveChanges(); 
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "uspeh" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Email Already Exist" });
                }
            }   
            catch (Exception ex)
            {
                return Request.CreateResponse (HttpStatusCode.InternalServerError, ex);
            }
        
        }

        [HttpGet, Route("getAllUser")]
        public HttpResponseMessage GetAllUser()

        {
            try
            {
                var result = db.tblUser.Select(u => new { u.UserID, u.Name, u.Surname, u.Email, u.Date, u.City, u.Adress, u.Country, u.Username, u.Password, u.MoneyOnAccount }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, result);
              
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpGet, Route("getAllUser/{userID}")]
        public HttpResponseMessage GetAllUser(int userID)

        {
            try
            {
                var user = db.tblUser.FirstOrDefault(u => u.UserID == userID);
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    user.UserID,
                    user.Name,
                    user.Surname,
                    user.Email,
                    user.Date,
                    user.City,
                    user.Adress,
                    user.Country,
                    user.Username,
                    user.Password,
                    user.MoneyOnAccount
                });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpDelete, Route("deleteUser/{userID}")]
        public HttpResponseMessage DeleteUser(int userID)
        {
            try
            {
                var userToDelete = db.tblUser.FirstOrDefault(u => u.UserID == userID);
                if (userToDelete == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
                }

                db.tblUser.Remove(userToDelete);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
