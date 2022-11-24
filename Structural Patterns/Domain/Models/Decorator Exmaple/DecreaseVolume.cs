using System;

namespace Models
{
    public class DecreaseVolume : AudioDecorator
    {
        public DecreaseVolume(IAudioEffect audioEffect) : base(audioEffect)
        {
        }

        public override double GetSize()
        {
            return _audioEffect.GetSize() - 5.54;
        }

        public override string GetType()
        {
            return _audioEffect.GetType() + " volume decreased by 1";
        }
    }
}
