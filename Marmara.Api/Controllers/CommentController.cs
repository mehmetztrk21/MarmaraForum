using AutoMapper;
using Marmara.Api.DTOs;
using Marmara.Api.Identity;
using Marmara.Entity.Entities;
using Marmara.Entity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericService<Comment> _comments;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public CommentController(IGenericService<Comment> comments,IMapper mapper,UserManager<User> userManager)
        {
            _comments = comments;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _comments.GetAll();
            var map_comments = _mapper.Map<IEnumerable<CommentDto>>(comments);
            foreach (var item in map_comments)
            {
                item.User = await _userManager.FindByIdAsync(item.PersonId);
            }

            return Ok(map_comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _comments.GetById(id);
            var map_comment = _mapper.Map<CommentDto>(comment);
            map_comment.User = await _userManager.FindByIdAsync(comment.PersonId);
            return Ok(map_comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            var created_comment = await _comments.Add(comment);
            return Created(string.Empty, created_comment);
        }
        [HttpPut]
        public IActionResult Update(Comment comment)
        {
            var updated_comment = _comments.Update(comment);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _comments.Remove(_comments.GetById(id).Result);
            return NoContent();
        }
    }
}
