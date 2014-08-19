using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.Filters;
using VoceViuWeb.Models;

namespace VoceViuWeb.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var httpMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var messages = new[] { context.Exception.Message };
            var response = new NotificationResponse("Houve uma falha na requisicação", messages, "error");
            httpMessage.Content = new ObjectContent<NotificationResponse>(response, new JsonMediaTypeFormatter());
            context.Response = httpMessage;
        }
    }
}