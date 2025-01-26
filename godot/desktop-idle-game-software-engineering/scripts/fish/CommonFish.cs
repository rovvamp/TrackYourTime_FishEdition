using Godot;
namespace desktopidlegamesoftwareengineering.scripts.fish;

public partial class CommonFish : Control
{
    private ui.Countdown _countdown;   //reference to the Countdown script
    private bool _isFishHidden = false; //stop sting print when fish is hidden
    public override void _Ready()
    {
        _countdown = GetNode<ui.Countdown>("/root/Main/Countdown");
    }

    public override void _Process(double delta)
    {
        //check if the countdown is finished
        if (_countdown.TimeLeft <= 0 && !_isFishHidden)
        {
            Visible = false;    //hide the fish
            GD.Print("the fish is hidden because there is no more fish food :(");
            _isFishHidden = true;
        }
    }
}