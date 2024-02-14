﻿
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infraestructure.Repositories;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPost()
        {
            var posts = new PostRepository().GetPosts();
            return Ok(posts);
        }
    }
}
