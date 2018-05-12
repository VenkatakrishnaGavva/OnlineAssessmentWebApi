using ExcelDataReader;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using OnlineAssessmentapp.BusinessFactory;
using OnlineAssessmentApp.Business.Entities;
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
    public class QuestionPaper
    {
      
        public string Description { get; set; }

        public string QuestionPaperName { get; set; }
    }

    public class UserAssessmentModel
    {

        public int UserId { get; set; }

        public int AssessmentId { get; set; }
    }
    public class QuestionPaperController : ApiController
    {
        [Route("api/GetQuestionPaper")]
        public async Task<HttpResponseMessage> GetQuestionPaper(int userId)
        {
            try
            {
                var questionPaper = BusinessFactory.CreateQuestionPaperBusinessInstance().GetQuestionPaperById(userId);

                return Request.CreateResponse(HttpStatusCode.OK, questionPaper);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }


        }

        [HttpGet]
        [Route("api/GetAllAssessments")]
        public async Task<HttpResponseMessage> GetAllAssessments()
        {
            try
            {

                var questionPaperDetails = BusinessFactory.CreateQuestionPaperBusinessInstance().GetAllAsseementsDetails();
                List<AssessmentModel> assessmentDeatilsList = new List<AssessmentModel>();

                foreach (var assessment in questionPaperDetails)
                {
                    AssessmentModel assessmentModel = new AssessmentModel();
                    assessmentModel.AssessmentId = assessment.AssessmentId;
                    assessmentModel.AssessmentName = assessment.AssessmentName;
                    assessmentDeatilsList.Add(assessmentModel);

                }

                return Request.CreateResponse<List<AssessmentModel>>(HttpStatusCode.OK, assessmentDeatilsList);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }


        [HttpGet]
        [Route("api/GetQuestionPaperNames")]
        public async Task<HttpResponseMessage> GetQuestionPaperNames()
        {
            try
            {

               var questionPaperDetails= BusinessFactory.CreateQuestionPaperBusinessInstance().GetAllQuestionPapersDetails();
                List<QuestionPaperDetailsModel> questionPaperDetailsList = new List<QuestionPaperDetailsModel>();

                foreach(var questionPaper in questionPaperDetails)
                {
                    QuestionPaperDetailsModel questionPaperDetailsModel = new QuestionPaperDetailsModel();
                    questionPaperDetailsModel.Id = questionPaper.Id;
                    questionPaperDetailsModel.QuestionPaperName = questionPaper.QuestionPaperName;
                    questionPaperDetailsList.Add(questionPaperDetailsModel);

                }

                return Request.CreateResponse<List<QuestionPaperDetailsModel>>(HttpStatusCode.OK, questionPaperDetailsList);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }
        [HttpPost]
        [Route("api/CreateAssessment")]
        public async Task<HttpResponseMessage> CreateAssessment(AssessmentModel assesmentModel)
        {

            try
            {
                AssessmentEntity assessmentEntity = new AssessmentEntity();

                assessmentEntity.AssessmentName = assesmentModel.AssessmentName;
                assessmentEntity.AssessmentDescription = assesmentModel.AssessmentDescription;
                assessmentEntity.QuestionPaperDetails = new QuestionPaperDetailsEntity();
                assessmentEntity.QuestionPaperDetails.Id = assesmentModel.QuestionPaperId;
                assessmentEntity.StartTime = assesmentModel.StartTime;
                assessmentEntity.EndTime = assesmentModel.EndTime;
                assessmentEntity.CreatedBy = assesmentModel.CreatedBy;

                BusinessFactory.CreateQuestionPaperBusinessInstance().CreateAssessment(assessmentEntity);


                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
                  
        [HttpPost]
        [Route("api/fileupload")]
        public async Task<HttpResponseMessage> PostFormData(string Description,string QuestionPaperName)
        {
           
            try
            {

                BusinessFactory.CreateQuestionPaperBusinessInstance().QuestionPaperUpload(HttpContext.Current.Request.Files[0].InputStream, Description,QuestionPaperName);


               return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [HttpPost]
        [Route("api/MapAnAssessmentToUser")]
        public async Task<HttpResponseMessage> MapAnAssessmentToUser(UserAssessmentModel userAssessmentModel)
        {
         try
            {
              
                BusinessFactory.CreateQuestionPaperBusinessInstance().MapAnAssessmentToUser(userAssessmentModel.UserId, userAssessmentModel.AssessmentId);
                
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }


    }
}