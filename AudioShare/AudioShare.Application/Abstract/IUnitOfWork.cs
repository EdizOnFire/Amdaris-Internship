﻿using System;
using System.Threading.Tasks;

namespace AudioShare.Application.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public IAudioFileRepository AudioFileRepository { get; }
        public ICommentRepository CommentRepository { get; }
        Task SaveAsync();
    }
}
