using System;

namespace Models
{
    public abstract class AudioDecorator : IAudioEffect
    {
        protected IAudioEffect _audioEffect;
        public AudioDecorator(IAudioEffect audioEffect)
        {
            _audioEffect = audioEffect;
        }

        public abstract double GetSize();
        public abstract string GetType();
    }
}
