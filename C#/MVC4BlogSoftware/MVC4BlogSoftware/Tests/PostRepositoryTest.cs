using System;
using System.Collections.Generic;
using Xunit;
using Should;

namespace FirstSteps.Tests
{
    public class PostRepositoryTest
    {
        private FirstSteps.StubPostRepository repository;
        private List<Post> posts;

        public void FillWithFakeData()
        {
            posts.Add(new Post("First", "first post", new DateTime(34, 4, 23), "John Doe"));
            posts.Add(new Post("Second", "second post", new DateTime(98, 7, 25), "John Doe"));
            posts.Add(new Post("Third", "third post", new DateTime(34, 6, 23), "John Doe"));
            posts.Add(new Post("Fourth", "fourth post", new DateTime(53, 7, 13), "Some Guy"));
            posts.Add(new Post("Fifth", "fifth post", new DateTime(26, 6, 27), "John Doe"));
        }

        public PostRepositoryTest()
        {
            repository = new StubPostRepository();
            posts = repository.posts;
//            FillWithFakeData();
        }
        [Fact]
        public void TestGetAll()
        {
            repository.GetAll().ShouldEqual(posts.ToArray());
        }

        [Fact]
        public void TestGetPost()
        {
            repository.Get(posts[3].Nickname).ShouldEqual(posts[3]);
        }

        [Fact]
        public void TestDelete() // all thats really needed
        {
            var tmp = new Post[4];
            for (int i = 0; i < 4; i++)
            {
                tmp[i] = posts[i];
            }
            repository.Delete(repository.Get("fifth"));
            repository.GetAll().ShouldEqual(tmp);
        }
    }
}
