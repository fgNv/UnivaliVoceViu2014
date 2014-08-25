using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.AdminContent.Abstractions;
using VoceViuModel.AdminContent.Messages;
using VoceViuModel.Attachments;

namespace VoceViuModel.AdminContent.Services
{
    public class ContentServices
    {
        private readonly IContentRepository _contentRepository;
        public ContentServices(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public void Add(SaveContentMessage message)
        {
            var content = new Content();
            var attachment = new Attachment();
            attachment.Name = message.FileName;
            attachment.File = message.File;
            content.Attachment = attachment;

            _contentRepository.Add(content);
            _contentRepository.SaveChanges();
        }

        public void Remove(int id)
        {
            var content = _contentRepository.Get(id);
            _contentRepository.Remove(content);
            _contentRepository.SaveChanges();
        }
    }
}
