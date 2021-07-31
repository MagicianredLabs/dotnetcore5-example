using it.example.dotnetcore5.dal.ef.sqlite.EfModels;
using it.example.dotnetcore5.domain.Interfaces.Models;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using it.example.dotnetcore5.dal.ef.sqlite.Factories;
using ModelPost = it.example.dotnetcore5.domain.Models.Post;

namespace it.example.dotnetcore5.dal.ef.sqlite.Repositories
{
    /// <summary>
    /// Repository of posts
    /// </summary>
    public class PostsRepository : IPostsRepository
    {
        protected BlogContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public PostsRepository(BlogContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieve all Posts items
        /// </summary>
        /// <returns>list of post</returns>
        public IEnumerable<IPost> GetAll()
        {
            var posts = _context.Posts.ToList();

            return posts.ToModelsDomain();
        }

        /// <summary>
        /// Retrieve post by own id
        /// </summary>
        /// <param name="id">id of the post to retrieve</param>
        /// <returns>the post, null if id not found</returns>
        public IPost GetById(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            return post.ToModelDomain();
        }

        /// <summary>
        /// Save the post in database
        /// </summary>
        /// <param name="item">post to save</param>
        public void AddPost(IPost item)
        {
            var entry = ((ModelPost)item).ToEfEntity();
            _context.Posts.Add(entry);
            _context.SaveChanges();
        }
    }
}