using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.AdminContent;
using VoceViuModel.AdminContent.Abstractions;
using System.Data.Entity;

namespace VoceViuPersistence.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly VoceViuDbContext _context;

        public ContentRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public void Add(VoceViuModel.AdminContent.Content content)
        {
            _context.AdminContents.Add(content);
        }

        public VoceViuModel.AdminContent.Content Get(int id)
        {
            return _context.AdminContents
                           .Include(c => c.Attachment)
                           .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<VoceViuModel.AdminContent.Content> GetAll()
        {
            return _context.AdminContents
                           .Include(c => c.Attachment);
        }

        public void Remove(Content content)
        {
            _context.AdminContents.Remove(content);
        }

        public void SaveChanges()
        {
            _context.SaveChanges() ;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
