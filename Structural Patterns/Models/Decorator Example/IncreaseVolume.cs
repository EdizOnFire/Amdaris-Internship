using Models;

namespace Models
{
    public class IncreaseVolume : AudioDecorator
    {
        public IncreaseVolume(IAudioEffect audioEffect) : base(audioEffect)
        {
        }

        public override double GetSize()
        {
            return _audioEffect.GetSize() + 5.54;
        }

        public override string GetType()
        {
            return _audioEffect.GetType() + " volume increased by 1";
        }
    }
}
