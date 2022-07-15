namespace P5.Core
{
    public class GameTime
    {
        // time elapsed since the last frame
        public float ElapsedTime { get; private set; }
        private float _totalTime;
        public float TotalTime
        {
            get { return _totalTime; }
            set
            {
                ElapsedTime = value - _totalTime;
                _totalTime = value;
            }
        }


    }
}