using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademicShare.Web.Models;
using AcademicShare.Web.Models.Dtos;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace AcademicShare.Web.Profiles;

public class AutoMapperProfiles : Profile
{   
    public AutoMapperProfiles()
    {
        CreateMap<UserProfile, UserProfile>() 
            .IgnoreAllPropertiesWithAnInaccessibleSetter()
            .ReverseMap();

        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
            .ForMember(dest => dest.University, opt => opt.MapFrom(src => src.University))
            .ForMember(dest => dest.Registration, opt => opt.MapFrom(src => src.Registration))
            .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => new UserProfile { Bio = "Hello World!", ProfilePicture = "default.png", Banner = "default.png", FullName = src.UserName }))
            .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => new List<Post>()))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => new List<Comment>()))
            .ReverseMap();

        CreateMap<Post, GetPostDto>()
            .ReverseMap();
            
        
        CreateMap<Post, ViewPostDto>()
            .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Posts))
            .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PostContent, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.PostImage, opt => opt.MapFrom(src => src.Image))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.CommentContent, opt => opt.MapFrom(src => src.Comments.FirstOrDefault()!.Content))
            .ForMember(dest => dest.CommentUserId, opt => opt.MapFrom(src => src.Comments.FirstOrDefault()!.User))
            .ReverseMap();

        CreateMap<User, ViewProfileDto>()
            .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dest => dest.Follow, opt => opt.MapFrom(src => src.Follow))
            .ReverseMap();
        
    }
}
