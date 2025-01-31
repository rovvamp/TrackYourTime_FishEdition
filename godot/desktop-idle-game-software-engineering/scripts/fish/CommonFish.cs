using Godot;
namespace desktopidlegamesoftwareengineering.scripts.fish;

public partial class CommonFish : Control
{
    private ui.Countdown _countdown;
    private bool _isFishHidden = false;
    public override void _Ready()
    {
        _countdown = GetNode<ui.Countdown>("/root/Main/Countdown");
    }

    public override void _Process(double delta)
    {
        if (_countdown.TimeLeft <= 0 && !_isFishHidden)
        {
            Visible = false;
            GD.Print("the fish is hidden because there is no more fish food :(");
            _isFishHidden = true;
        }
    }
}