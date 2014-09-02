using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.AdminContent;
using VoceViuModel.AdminContent.Abstractions;
using VoceViuModel.AdminContent.Messages;
using VoceViuModel.AdminContent.Services;
using VoceViuWeb.Filters;
using VoceViuWeb.Models;

namespace VoceViuWeb.Api
{
    [ExceptionHandler]
    public class AdminContentController : ApiController
    {
        private readonly IContentRepository _contentRepositoy;
        private readonly ContentServices _contentServices;

        public AdminContentController(IContentRepository contentRepositoy, ContentServices contentServices)
        {
            _contentRepositoy = contentRepositoy;
            _contentServices = contentServices;
        }

        public IEnumerable<ContentViewModel> GetAll()
        {
            return _contentRepositoy.GetAll()
                                    .Select(c => new ContentViewModel(c));
        }

        public void Remove(int id)
        {
            _contentServices.Remove(id);
        }
    }
}