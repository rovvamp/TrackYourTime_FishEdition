using Godot;

namespace desktopidlegamesoftwareengineering.scripts.ui
{
    public partial class FeedFishButton : Button
    {
        private CanvasItem _commonFish;
        private Countdown _countdown;

        public override void _Ready()
        {
            _commonFish = GetNode<CanvasItem>("/root/Main/CommonFish");
            _countdown = GetNode<Countdown>("/root/Main/Countdown");

            _commonFish.Visible = false;
            _countdown.Visible = false;
            
            Pressed += OnButtonPressed;
        }

        private void OnButtonPressed()
        {
            if (!_countdown.IsTimerRunning || _countdown.TimeLeft <= 0)
            {
                _commonFish.Visible = true;
                _countdown.Visible = true;
                _countdown.ResetTimer();
                _countdown.StartTimer();
            }
            else
            {
                GD.Print("[FeedFishButton] timer is already running!");
            }
        }
    }
}
