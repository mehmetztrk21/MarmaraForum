using AutoMapper;
using Marmara.Api.DTOs;
using Marmara.Api.Identity;
using Marmara.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marmara.Api.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogwithCommentDto>();
            CreateMap<BlogwithCommentDto, Blog>();
            CreateMap<Category, CategoryWithBlogDto>();
            CreateMap<CategoryWithBlogDto, Category>();
        }
    }
}
