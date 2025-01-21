using Godot;

public partial class Countdown : Node2D
{
    private Label label;
    private Timer timer;

    private int[] TimeLeftForFish()
    {
        float timeLeft = (float)timer.TimeLeft;

        int minute = Mathf.FloorToInt(timeLeft / 60);
        int second = Mathf.FloorToInt(timeLeft % 60);

        return new int[] { minute, second };
    }

    public override void _Ready()
    {

        label = GetNode<Label>("Label");
        timer = GetNode<Timer>("Timer");
        
        timer.WaitTime = 3600f;
        timer.Start();

        GD.Print("timer started!");
    }

    public override void _Process(double delta)
    {
        int[] time = TimeLeftForFish();

        label.Text = $"{time[0]:D2}:{time[1]:D2}";
        
        //debug: press 0 to make timer go to 00:00 immediately
        if (Input.IsActionJustPressed("debug_timer_finish"))
        {
            timer.Stop();
            OnTimerTimeout();
        }
    }

    private void OnTimerTimeout()
    {
        GD.Print("1 hour is up!");
        label.Text = "00:00";
    }
}