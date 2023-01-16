using AutoMapper;
using AudioShare.Core.Entities;
using AudioShare.API.Dtos;
using AudioShare.Application.Commands;
using System.Numerics;

namespace AudioShare.API.Profiles
{
    public class AudioFileProfile : Profile
    {
        public AudioFileProfile()
        {
            CreateMap<AudioFile, GetAudioFileDto>();
            CreateMap<UpdateAudioFileDto, UpdateAudioFile>();
        }
    }
}
