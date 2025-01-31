using Godot;
namespace desktopidlegamesoftwareengineering.scripts.main;

public partial class Main : Node2D
{
    private AudioStreamPlayer _piano;
    private AudioStreamPlayer _water;
    public override void _Ready()
    {
        _piano = GetNode<AudioStreamPlayer>("/root/Main/PianoMusic");
        _water = GetNode<AudioStreamPlayer>("/root/Main/Underwater");
    }

    public override void _Process(double delta)
    {
        if (!_piano.Playing)
        {
            _piano.Play();
        }

        if (!_water.Playing)
        {
            _water.Play();
        }
    }
}