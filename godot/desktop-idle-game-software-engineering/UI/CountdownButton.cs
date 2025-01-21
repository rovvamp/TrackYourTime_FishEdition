using Godot;

public partial class CountdownButton : Button
{
    public override void _Ready()
    {
        Connect("pressed", Callable.From(OnButtonPressed));
    }
    private void OnButtonPressed()
    {
        GD.Print("button was pressed!");
        GetTree().ChangeSceneToFile("res://UI/Countdown.tscn");
    }
}