﻿using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using OnlineAssessmentapp.BusinessFactory;
using OnlineAssessmentApp.Business;
using OnlineAssessmentApp.Business.Entities;
using OnlineAssessmentApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OnlineAssessmentApp.WebAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials
        (OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //**Replace below user authentication code as per your Entity Framework Model ***


            //if (entry == null)
            //{
            //    context.SetError("invalid_grant",
            //    "The user name or password is incorrect.");
            //    return;
            //}

            IAccountManagementBusiness objAccountManagementBusiness =  BusinessFactory.CreateAccountManagementBusinessInstance();
            UserModel accountDetailModel = new UserModel();
            UserEntity accountDetailEntity = new UserEntity();
            accountDetailEntity.Username = context.UserName;
            accountDetailEntity.Password = context.Password;

           
            if (!objAccountManagementBusiness.IsValidUser(accountDetailEntity))
            {
                context.SetError("invalid_grant",
                "The user name or password is incorrect.");
                return;
            }
            else
            {
               
            }
            ClaimsIdentity oAuthIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            ClaimsIdentity cookiesIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(context.UserName, Convert.ToString(accountDetailEntity.UserId), Convert.ToString(accountDetailEntity.Role.RoleId), Convert.ToString(@"content/profilepics/"+accountDetailEntity.ProfilePicPath));
            AuthenticationTicket ticket =
            new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
            
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string,
            string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication
        (OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri
        (OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName,string userid,string RoleId,string profilePicPath)
        {
            IDictionary<string, string>
            data = new Dictionary<string, string>
            {
                { "userName", userName },
                { "userid", userid},
                 { "RoleId", RoleId},
                {"ProfilePicPath", profilePicPath}

            };
            return new AuthenticationProperties(data);
        }
    }
}