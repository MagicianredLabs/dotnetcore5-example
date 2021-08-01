using it.example.dotnetcore5.bl.Services;
using it.example.dotnetcore5.bl.tests.unit.Helpers;
using it.example.dotnetcore5.domain.Interfaces.Repositories;
using it.example.dotnetcore5.domain.Models;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace it.example.dotnetcore5.bl.tests.unit.Services
{
    [TestFixture]
    public class PostsServiceTest
    {
        /// <summary>
        /// PostsService is our System Under Test
        /// </summary>
        private PostsService _sut;

        /// <summary>
        /// A mock of posts repository
        /// </summary>
        private IPostsRepository _postsRepository;

        #region SetUp and TearDown

        [OneTimeSetUp]
        public void SetupUpOneTime()
        {
            // Instance of mock
            _postsRepository = Substitute.For<IPostsRepository>();
            _sut = new PostsService(_postsRepository);
        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            // dispose
            _postsRepository = null;
        }

        #endregion

        [Test]
        [Category("Unit test")]
        public void should_retrieve_all_posts()
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            _postsRepository.GetAll().Returns(mockPosts);

            // Act
            var posts = _sut.GetAll();

            // Assert
            Assert.IsNotNull(posts);
            Assert.AreEqual(posts.Count, mockPosts.Count);
            foreach (var post in posts)
            {
                Assert.IsTrue(mockPosts.Contains(post));
                mockPosts.Remove(post);
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [Category("Unit test")]
        public void should_retrieve_one_post_by_id(int id)
        {
            // Arrange
            var mockPosts = PostsHelper.GetDefaultMockData();
            var mockPost = mockPosts.Where(x => x.Id == id).FirstOrDefault();

            _postsRepository.GetById(mockPost.Id).Returns(mockPost);

            // Act
            var post = _sut.GetById(id);

            // Assert
            Assert.IsNotNull(post);
            Assert.IsTrue(post.Id == id);
        }

        [Test]
        [Category("Unit test")]
        public void should_retrieve_no_one_post()
        {
            // Arrange
            Post mockPost = null;

            _postsRepository.GetById(1000).Returns(mockPost);

            // Act
            var post = _sut.GetById(1000);

            // Assert
            Assert.IsNull(post);
        }
    }
}
