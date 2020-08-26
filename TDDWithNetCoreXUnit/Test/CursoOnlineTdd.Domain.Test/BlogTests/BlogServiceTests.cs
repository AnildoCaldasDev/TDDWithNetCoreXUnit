using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TddNetCoreDev.Api.Controllers;
using TddNetCoreDev.Api.Domain;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.BlogTests
{
    public class BlogServiceTests
    {

        //fonte dos testes: https://github.com/mrsimi/BlogAPIusingTDD/blob/master/blog-using-tdd/blog-using-tdd.tests/BlogService_Tests.cs
        private readonly BlogController _blogController;
        private Mock<List<Post>> _mockPostList;

        public BlogServiceTests()
        {
            _mockPostList = new Mock<List<Post>>();
            _blogController = new BlogController(_mockPostList.Object);
        }

        [Fact]
        public void GetTest_ReturnsListOfPosts()
        {
            //arrange: Cenário
            var mockPosts = new List<Post>
            {
                new Post{Title = "Tdd One"},
                new Post{Title = "Tdd and Bdd"}
            };

            _mockPostList.Object.AddRange(mockPosts);

            //act: Ação
            var result = _blogController.Get();

            //assert: Validação
            //Verifico se o objeto dado é do tipo pssado ou de um tipo deriv ado a este.
            var model = Assert.IsAssignableFrom<ActionResult<List<Post>>>(result);

            Assert.Equal(2, model.Value.Count);
        }

        [Fact]
        public void GetByIdTest_ReturnsNotFound_WhenIdNotProvided()
        {
            //act
            var result = _blogController.GetById(null);

            //assertion
            Assert.IsAssignableFrom<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdTest_ReturnNotFound_WhenPostNotExists()
        {
            //arrange:
            var post = new Post() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad") };
            _mockPostList.Object.SingleOrDefault(m => m.Id == post.Id);

            //act:
            var result = _blogController.GetById(post.Id);

            //assert:
            Assert.IsAssignableFrom<NotFoundObjectResult>(result.Result);
        }


        [Fact]
        public void GetByIdTest_ReturnsSinglePost_WhenPostExist()
        {
            //arrange
            var post = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Title = "Learn TDD",
                Content = "Learning is fun"
            };

            _mockPostList.Object.Add(post);

            //act:
            var result = _blogController.GetById(post.Id);

            //assert
            var model = Assert.IsType<ActionResult<Post>>(result);
            Assert.Equal(post, model.Value);
        }

        [Fact]
        public void AddTest_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            //arrange:
            var post = new Post() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"), Content = "Learning is fun" };
            _blogController.ModelState.AddModelError("Title", "Titulo é Obrigatorio");

            //act:
            var result = _blogController.Add(post);

            //assert:
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);

        }

        [Fact]
        public void AddTest_ReturnsCreatedResponse_WhenValidObjectPassed()
        {
            var post = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Title = "Titulo teste",
                Content = "Learning is fun"
            };

            var result = _blogController.Add(post);

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
        }


        [Fact]
        public void AddTest_ReturnsResponseHasCreatedItem_WhenValidObjectPassed()
        {
            var mockPost = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Content = "Post Created",
                Title = "Begining to learn is the fun part about being learned"
            };

            var result = _blogController.Add(mockPost) as CreatedAtActionResult;
            var item = result.Value as Post;

            Assert.IsType<Post>(item);
            Assert.Equal("Post Created", item.Content);
        }

        [Fact]
        public void RemoveTest_ReturnsNotFound_WhenGuidNotExisting()
        {
            var guidNotExisting = Guid.NewGuid();

            var result = _blogController.Remove(guidNotExisting);

            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public void RemoveTest_ReturnsOkResult_WhenGuidIsExisting()
        {
            var mockPost = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Content = "Post Created",
                Title = "Begining to learn is the fun part about being learned"
            };

            _mockPostList.Object.Add(mockPost);


            var result = _blogController.Remove(mockPost.Id);


            //assertion:
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void RemoveTest_RemovesOneItem_WhenGuidIsExisting()
        {
            var mockPost = new List<Post>()
            {
                new Post(){Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                                    Title = "Learning One" },
                new Post(){Id = Guid.NewGuid(), Title = "Learning Two" },
                new Post(){Id = Guid.NewGuid(), Title = "Learning Three"}
            };

            _mockPostList.Object.AddRange(mockPost);

            var result = _blogController.Remove(new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"));

            Assert.Equal(2, _blogController.Get().Value.Count());

        }

        [Fact]
        public void UpdateTest_ReturnsNull_WhenIdAndPostAreNull()
        {
            //act:
            var result = _blogController.Update(null, null);

            Assert.IsAssignableFrom<NotFoundObjectResult>(result);

        }


        [Fact]
        public void UpdateTest_ReturnsNull_WhenIdIsNotNullAndPostIsNull()
        {

            var mockId = Guid.NewGuid();

            //act:
            var result = _blogController.Update(mockId, null);

            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void UpdateTest_ReturnsNull_WhenIdIsNullAndPostIsNotNull()
        {
            var mockPost = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Content = "Post Created",
                Title = "Begining to learn is the fun part about being learned"
            };

            //act:
            var result = _blogController.Update(null, mockPost);

            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void UpdateTest_ReturnNotFoundResult_WhenIdNotExisting()
        {
            var mockPost = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Content = "Post Created",
                Title = "Begining to learn is the fun part about being learned"
            };

            //act:
            var result = _blogController.Update(mockPost.Id, mockPost);

            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void UpdateTest_ReturnsOkResult_WhenIdIsPresent()
        {
            var mockPostLis = new List<Post>()
            {
                new Post(){Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                                    Title = "Learning One" },
                new Post(){Id = Guid.NewGuid(), Title = "Learning Two" },
                new Post(){Id = Guid.NewGuid(), Title = "Learning Three"}
            };

            var mockUpdate = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Title = "Learning One"
            };

            _mockPostList.Object.AddRange(mockPostLis);

            var result = _blogController.Update(mockUpdate.Id, mockUpdate);

            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateTest_ReturnsNewItemAfterUpdate_WhenIdIsPresent()
        {
            //arrange
            var mockpost = new Post()
            {
                Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                Title = "Learning is fun",
                Content = "Learn well"
            };

            _mockPostList.Object.Add(mockpost);

            var mockpostToUpdate = new Post()
            {
                Title = "Learning is fun",
                Content = "Learn well again"
            };

            //act
            var result = _blogController.Update(mockpost.Id, mockpostToUpdate);

            //assert
            var model = Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(mockpostToUpdate.Content, _blogController.GetById(mockpost.Id).Value.Content);
        }

    }
}
