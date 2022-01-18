using AutoMapper;
using Marmara.Api.DTOs;
using Marmara.Api.Identity;
using Marmara.Api.Mapping;
using Marmara.Entity.Entities;
using Marmara.Entity.Services;
using Marmara.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public BlogController(IBlogService blogService, IMapper mapper, UserManager<User> userManager)
        {
            _blogService = blogService;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAll();
            var map_blogs = _mapper.Map<IEnumerable<BlogDto>>(blogs.OrderBy(i=>i.Date));
            foreach (var item in map_blogs)
            {
                item.User= await _userManager.FindByIdAsync(item.PersonId);
            }
            return Ok(map_blogs);
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetById(id);
            var map_blog = _mapper.Map<BlogDto>(blog);
            map_blog.User = await _userManager.FindByIdAsync(blog.PersonId);
            return Ok(map_blog);
        }
        [HttpGet("{id}", Name = "GetBlogwithComments")]
        public async Task<IActionResult> GetBlogwithComments(int id)
        {
            var blog = await _blogService.GetBlogwithComments(id);
            var map_blog = _mapper.Map<BlogwithCommentDto>(blog);
            List<CommentDto> map_comments = new List<CommentDto>();
            foreach (var item in map_blog.Comments)
            {
               map_comments.Add( _mapper.Map<CommentDto>(item));
                
            }
            
            map_blog.User = await _userManager.FindByIdAsync(blog.PersonId);
            return Ok(map_blog);
        }

        [HttpGet("{id}", Name = "AddLikes")]
        public async Task<IActionResult> AddLikes(int id)
        {
            _blogService.AddLikes(id);
            var blog = await _blogService.GetBlogwithComments(id);
            var map_blog = _mapper.Map<BlogwithCommentDto>(blog);
            List<CommentDto> map_comments = new List<CommentDto>();
            foreach (var item in map_blog.Comments)
            {
                map_comments.Add(_mapper.Map<CommentDto>(item));

            }

            map_blog.User = await _userManager.FindByIdAsync(blog.PersonId);
            return Ok(map_blog);
        }
        [HttpGet("{id}", Name = "RemoveLikes")]
        public async Task<IActionResult> RemoveLikes(int id)
        {
            _blogService.RemoveLikes(id);
            var blog = await _blogService.GetBlogwithComments(id);
            var map_blog = _mapper.Map<BlogwithCommentDto>(blog);
            List<CommentDto> map_comments = new List<CommentDto>();
            foreach (var item in map_blog.Comments)
            {
                map_comments.Add(_mapper.Map<CommentDto>(item));

            }

            map_blog.User = await _userManager.FindByIdAsync(blog.PersonId);
            return Ok(map_blog);
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(BlogDto blog)
        {
            var username = HttpContext.User.Identity.Name;  //oturumu açan kullanıcı adını yazdığı bloğa ekledik kullanmak istediğimiz zaman ıdentity yardımı ile isim üzerinden bulabileeğiz.
            blog.PersonId = _userManager.FindByNameAsync(username).Result.Id; //oturumu açan kullanıcının kullanıcı adı ile ıd sini bulduk.
            var new_blog = await _blogService.Add(_mapper.Map<Blog>(blog));
            return Created(string.Empty, _mapper.Map<BlogDto>(new_blog));
        }
        [Authorize]
        [HttpPut]
        public IActionResult Update(BlogDto blog)
        {
            var updated_blog = _blogService.Update(_mapper.Map<Blog>(blog));
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _blogService.Remove(_blogService.GetById(id).Result);
            return NoContent();
        }

    }
}
