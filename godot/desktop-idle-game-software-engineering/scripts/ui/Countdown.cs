using Godot;
namespace desktopidlegamesoftwareengineering.scripts.ui;

public partial class Countdown : Node2D
{
    private Label _label;
    private float _timeLeft = 3600f;
    public bool IsTimerRunning { get; private set; }

    public float TimeLeft
    {
        get { return _timeLeft; }
    }

    public override void _Ready()
    {
        //get the label node
        _label = GetNode<Label>("Label");
        UpdateLabel();
        IsTimerRunning = false; //timer is not running at the start
    }

    public void StartTimer()
    {
        if (IsTimerRunning)
        {
            GD.Print("timer is already running!");
            return;
        }

        IsTimerRunning = true;  //start the timer
        GD.Print("timer started!");
    }

    public void ResetTimer()
    {
        _timeLeft = 3600f;  //reset time to 1 hour
        UpdateLabel();  //update the label immediately
        IsTimerRunning = false; //make sure the timer is stopped
        GD.Print("timer has been reset!");
    }

    public override void _Process(double delta)
    {
        //reduce the timer if it's running
        if (IsTimerRunning && _timeLeft > 0)
        {
            _timeLeft -= (float)delta;

            if (_timeLeft <= 0)
            {
                _timeLeft = 0;  //stop at zero
                IsTimerRunning = false;
                OnTimerTimeout();
            }

            UpdateLabel();
        }

        //debug: press 0 to finish the timer instantly
        if (Input.IsActionJustPressed("debug_timer_finish"))
        {
            GD.Print("debug key pressed!");
            _timeLeft = 0;
            IsTimerRunning = false;
            OnTimerTimeout();
            UpdateLabel();
        }
    }

    private void UpdateLabel()
    {
        int minutes = (int)(_timeLeft / 60);
        int seconds = (int)(_timeLeft % 60);
        _label.Text = $"{minutes:D2}:{seconds:D2}"; //set the label text
    }

    private void OnTimerTimeout()
    {
        GD.Print("time is up!");
        _label.Text = "00:00";
        Visible = false;
    }
}