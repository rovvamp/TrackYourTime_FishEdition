using Godot;
namespace desktopidlegamesoftwareengineering.scripts.ui;

public partial class FeedFishButton : Button
{
    private CanvasItem _commonFish;
    private Countdown _countdown;

    public override void _Ready()
    {
        //get references to the fish and countdown
        _commonFish = GetNode<CanvasItem>("/root/Main/CommonFish");
        _countdown = GetNode<Countdown>("/root/Main/Countdown");

        //hide both the fish and countdown at the start
        _commonFish.Visible = false;
        _countdown.Visible = false;
        
        this.Pressed += OnButtonPressed;
    }

    private void OnButtonPressed()
    {
        //check if the timer is finished, or if it's not already running
        if (!_countdown.IsTimerRunning || _countdown.TimeLeft <= 0)
        {
            _commonFish.Visible = true;
            _countdown.Visible = true;
            _countdown.ResetTimer();    //reset the timer
            _countdown.StartTimer();    //start the timer
        }
        else
        {
            GD.Print("timer is already running!");
        }
    }
}