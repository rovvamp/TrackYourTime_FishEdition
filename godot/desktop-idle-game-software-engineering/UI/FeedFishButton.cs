using Godot;

public partial class FeedFishButton : Button
{
    private CanvasItem commonFish;

    public override void _Ready()
    {
        commonFish = GetNode<CanvasItem>("/root/Main/Fish");
        commonFish.Visible = false;
        
        this.Pressed += OnButtonPressed;
    }

    private void OnButtonPressed()
    {
        commonFish.Visible = !commonFish.Visible;
    }
}