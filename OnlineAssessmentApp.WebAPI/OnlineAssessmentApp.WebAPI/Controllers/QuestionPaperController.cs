using ExcelDataReader;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using OnlineAssessmentapp.BusinessFactory;
using OnlineAssessmentApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;


namespace OnlineAssessmentApp.WebAPI.Controllers
{
    public class QuestionPaperController : ApiController
    {
        [Route("api/GetQuestionPaper")]
        public async Task<HttpResponseMessage> GetQuestionPaper()
        {
            try
            {
                int id = 9;
                var questionPaper = BusinessFactory.CreateQuestionPaperBusinessInstance().GetQuestionPaperById(id);

                return Request.CreateResponse(HttpStatusCode.OK, questionPaper);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }


        }

        [HttpPost]
        [Route("api/fileupload")]
        public async Task<HttpResponseMessage> PostFormData(string description)
        {
           
            try
            {

                BusinessFactory.CreateQuestionPaperBusinessInstance().QuestionPaperUpload(HttpContext.Current.Request.Files[0].InputStream, description);


               return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

    }
}