using it.example.dotnetcore5.domain.Interfaces.Models;
using it.example.dotnetcore5.domain.Interfaces.Services;
using it.example.dotnetcore5.domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace it.example.dotnetcore5.webapi.Controllers
{
    /// <summary>
    /// Handle Posts of blog
    /// </summary>
    [Route("api/[controller]")]
    //[ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostsService _postsService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="postsService"></param>
        /// <param name="logger"></param>
        public HomeController(IPostsService postsService, ILogger<HomeController> logger)
        {
            _postsService = postsService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve all Posts
        /// GET: api/<HomeController>
        /// </summary>
        /// <returns>list of Posts</returns>
        [HttpGet]
        public IEnumerable<IPost> Get()
        {
            var posts = _postsService.GetAll();

            return posts;
        }

        /// <summary>
        /// Retrieve the post with the id
        /// GET api/<HomeController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>the post with requested id</returns>
        [HttpGet("{id}")]
        public IPost Get(int id)
        {
            var post = _postsService.GetById(id);

            return post;
        }

        [HttpPost]
        public void Add()
        {
            Post newPost = new()
            {
                Title = "New test post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis enim eu augue tincidunt tincidunt. Nam luctus pharetra tortor, sit amet sodales odio bibendum non.",
                CreateDate = System.DateTime.Now
            };
            _postsService.Add(newPost);
            _logger.LogInformation("Added fake post!");
        }
    }
}