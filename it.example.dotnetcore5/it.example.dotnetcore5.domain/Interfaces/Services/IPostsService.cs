using it.example.dotnetcore5.domain.Interfaces.Models;
using System.Collections.Generic;

namespace it.example.dotnetcore5.domain.Interfaces.Services
{
    public interface IPostsService
    {
        public List<IPost> GetAll();
        public IPost GetById(int id);
        public void Add(IPost entry);
    }
}
