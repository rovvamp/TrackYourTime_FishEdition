using Godot;

public partial class CommonFish : Control
{
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("/root/Main/Countdown/Timer");
    }

    public override void _Process(double delta)
    {
        if (timer.TimeLeft <= 0)
        {
            Visible = false;
            GD.Print("fish is hidden because there is no more fish food :(");
        }
    }
}