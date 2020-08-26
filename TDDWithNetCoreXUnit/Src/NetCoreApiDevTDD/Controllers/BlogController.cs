using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TddNetCoreDev.Api.Domain;

namespace TddNetCoreDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly List<Post> _posts;

        public BlogController(List<Post> posts)
        {
            _posts = posts;
        }

        public ActionResult<List<Post>> Get()
        {
            return _posts;
        }


        [HttpGet("{Id}")]
        public ActionResult<Post> GetById(Guid? id)
        {
            if (id == null)
                return new NotFoundObjectResult("Id Not provided");

            var singlePost = _posts.SingleOrDefault(x => x.Id == id);

            if (singlePost == null)
                return new NotFoundObjectResult("PostNotFound");

            return singlePost;
        }

        [HttpPost]
        public ActionResult Add(Post post)
        {
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);

            post.Id = Guid.NewGuid();
            _posts.Add(post);

            return CreatedAtAction("Add", post);
        }


        [HttpDelete("{id}")]
        public ActionResult Remove(Guid? id)
        {
            if (id == null)
                return new NotFoundObjectResult("Id Not provided");

            var postDelete = _posts.SingleOrDefault(p => p.Id == id);

            if (postDelete == null)
                return new NotFoundObjectResult(postDelete);

            _posts.Remove(postDelete);

            return new OkObjectResult(postDelete.Title + " deleted");
        }


        [HttpPut]
        public ActionResult Update(Guid? id, Post post)
        {
            if (id == null || post == null)
                return new NotFoundObjectResult("Id ou Post not provided");

            var postUpdate = _posts.FirstOrDefault(p => p.Id == id);

            if (postUpdate == null)
                return new NotFoundObjectResult("Post Not Found By Id");

            _posts.Remove(postUpdate);

            postUpdate.Id = (Guid)id;
            postUpdate.Content = post.Content;
            postUpdate.Title = post.Title;

            _posts.Add(postUpdate);

            return new OkObjectResult(postUpdate);
        }


    }
}
