
using AudioShare.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace AudioShare.Application.Commands
{
    public class CreateComment : IRequest<Comment>
    {
        public string Owner { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int AudioFileId { get; set; }
    }
}