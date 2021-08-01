using it.example.dotnetcore5.domain.Interfaces.Models;
using it.example.dotnetcore5.domain.Models;
using System;
using System.Collections.Generic;

namespace it.example.dotnetcore5.bl.tests.unit.Helpers
{
    public static class PostsHelper
    {
        public static List<IPost> GetDefaultMockData()
        {
            List<IPost> mockPosts = new();
            mockPosts.Add(new Post()
            {
                Id = 1,
                Title = "This is a title for post 1",
                Text = "This is a text for post 1",
                CreateDate = DateTime.Now.AddDays(-2)
            });
            mockPosts.Add(new Post()
            {
                Id = 2,
                Title = "This is a title for post 2",
                Text = "This is a text for post 2",
                CreateDate = DateTime.Now.AddDays(-1)
            });
            return mockPosts;
        }
    }
}
