using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;

namespace VoceViuModel.AdminContent.Abstractions
{
    public interface IContentRepository : IRepository
    {
        void Add(Content content);
        Content Get(int id);
        IEnumerable<Content> GetAll();
        void Remove(Content content);
    }
}
