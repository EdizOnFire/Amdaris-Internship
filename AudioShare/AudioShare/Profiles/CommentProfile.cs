using AutoMapper;
using AudioShare.Core.Entities;
using AudioShare.API.Dtos;
using AudioShare.Application.Commands;
using System.Numerics;

namespace AudioShare.API.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, GetCommentDto>();
        }
    }
}
