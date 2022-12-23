using AutoMapper;
using AudioEditor.Core.Entities;
using AudioEditor.API.Dtos;
using AudioEditor.Application.Commands;
using System.Numerics;

namespace AudioEditor.API.Profiles
{
    public class AudioFileProfile : Profile
    {
        public AudioFileProfile()
        {
            CreateMap<AudioFile, GetAudioFileDto>();
            CreateMap<AudioFile, CreateAudioFileDto>();
            CreateMap<UpdateAudioFileDto, UpdateAudioFile>();
        }
    }
}
