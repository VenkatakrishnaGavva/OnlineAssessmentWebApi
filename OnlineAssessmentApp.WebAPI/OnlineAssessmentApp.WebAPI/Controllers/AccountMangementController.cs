using OnlineAssessmentapp.BusinessFactory;
using OnlineAssessmentApp.Business.Entities;
using OnlineAssessmentApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace OnlineAssessmentApp.WebAPI.Controllers
{
    public class AccountMangementController : ApiController
    {
        [HttpPost]
        [Route("api/CreateUser")]
        public async Task<HttpResponseMessage> CreateUser(UserModel user)
        {

            try
            {
                UserEntity userEntity = new UserEntity();

                userEntity.Username = user.Username;
                userEntity.Password = user.Password;
                userEntity.EmailAddress = user.EmailAddress;
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.CreatedBy = user.CreatedBy;
                userEntity.RoleId = user.RoleId;

                BusinessFactory.CreateAccountManagementBusinessInstance().CreateUser(userEntity);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}