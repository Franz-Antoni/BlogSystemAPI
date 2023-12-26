using AutoMapper;
using BlogSystem.Core.Dtos;
using BlogSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<UserLogin, UserLoginDto>();
            CreateMap<UserLoginDto, UserLogin>();
        }
    }
}
