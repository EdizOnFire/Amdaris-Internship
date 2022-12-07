using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AudioEditor.Core.Entities;
using MediatR;

namespace AudioEditor.Application.Commands
{
    public class CreateAudioFile : IRequest<AudioFile>
    {
        public string FileName { get; set; } = null!;
        public string Format { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
