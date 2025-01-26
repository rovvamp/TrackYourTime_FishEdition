using Godot;
namespace desktopidlegamesoftwareengineering.scripts.main;

public partial class Main : Node2D
{
    //declare the AudioStreamPlayer variable
    private AudioStreamPlayer _piano;
    private AudioStreamPlayer _water;
    public override void _Ready()
    {
        //get the AudioStreamPlayer node
        _piano = GetNode<AudioStreamPlayer>("/root/Main/PianoMusic");
        _water = GetNode<AudioStreamPlayer>("/root/Main/Underwater");
    }

    public override void _Process(double delta)
    {
        //if the piano is not playing, start playing it
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