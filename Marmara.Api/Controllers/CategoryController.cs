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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CategoryController(ICategoryService categoryService, IMapper mapper, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GeById(int id)
        {
            var category = await _categoryService.GetById(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpGet("{apiname}/{id}", Name = "GetWithBlogs")]   //kategoriyi bloglar ile beraber getirecek olan api fonksiyonu.  localhost/api/category/getwithBlog/1
        public async Task<IActionResult> GetWithBlog(int id)
        {
            var category = await _categoryService.GetByIdWithProducts(id);
            var map_categories = _mapper.Map<CategoryWithBlogDto>(category);
            foreach (var item in map_categories.Blogs)
            {
                item.User = await _userManager.FindByIdAsync(item.PersonId);
            }
            return Ok(map_categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            var category = await _categoryService.Add(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(category));
        }
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _categoryService.Remove(_categoryService.GetById(id).Result);
            return NoContent();
        }
    }
}
