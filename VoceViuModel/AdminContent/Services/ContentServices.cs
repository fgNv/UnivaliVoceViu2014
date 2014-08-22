using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.AdminContent.Abstractions;
using VoceViuModel.AdminContent.Messages;

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
            content.File = message.File;
            content.FileName = message.FileName;

            _contentRepository.Add(content);
            _contentRepository.SaveChanges();
        }

        public void Update(int id, SaveContentMessage message)
        {
            var content = _contentRepository.Get(id);
            content.File = message.File;
            content.FileName = message.FileName;

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
