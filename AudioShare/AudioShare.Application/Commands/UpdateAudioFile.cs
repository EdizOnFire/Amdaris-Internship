﻿using MediatR;
using AudioShare.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AudioShare.Application.Commands
{
    public class UpdateAudioFile : IRequest<AudioFile>
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string User { get; set; } = null!;
    }
}
