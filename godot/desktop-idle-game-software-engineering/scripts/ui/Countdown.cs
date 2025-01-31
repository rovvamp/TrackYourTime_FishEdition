using Godot;
using desktopidlegamesoftwareengineering.scripts.managers;

namespace desktopidlegamesoftwareengineering.scripts.ui;

public partial class Countdown : Node2D
{
    private Label _label;
    private Label _currencyLabel; 
    private float _timeLeft = 3600f;
    private float _currencyTimer = 0f; 

    public bool IsTimerRunning { get; private set; }

    public float TimeLeft => _timeLeft;

    public override void _Ready()
    {
        _label = GetNode<Label>("Label"); //find countdown label

        //find CurrencyLabel inside Interface and register it
        Label currencyLabel = GetNode<Label>("/root/Main/Interface/MarginContainer2/CurrencyLabel");
        if (currencyLabel != null)
        {
            GameManager.Instance.RegisterCurrencyLabel(currencyLabel);
            GD.Print("currencyLabel registered successfully!");
        }
        else
        {
            GD.PrintErr("currencyLabel not found");
        }

        UpdateLabel();
        IsTimerRunning = false;
    }

    public void StartTimer()
    {
        if (IsTimerRunning)
        {
            GD.Print("timer is already running!");
            return;
        }

        IsTimerRunning = true;
        GD.Print("timer started!");
    }

    public void ResetTimer()
    {
        _timeLeft = 3600f;
        UpdateLabel();
        UpdateCurrencyLabel();
        IsTimerRunning = false;
        GD.Print("timer has been reset!");
    }

    public override void _Process(double delta)
    {
        if (IsTimerRunning && _timeLeft > 0)
        {
            _timeLeft -= (float)delta;
            _currencyTimer += (float)delta;

            if (_currencyTimer >= 1f)
            {
                GameManager.Instance.AddCurrency(1);
                UpdateCurrencyLabel();
                _currencyTimer = 0f; 
            }

            if (_timeLeft <= 0)
            {
                _timeLeft = 0;
                IsTimerRunning = false;
                OnTimerTimeout();
            }

            UpdateLabel();
        }

        //debug: press "0" to instantly finish the timer
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
        if (_label != null)
        {
            int minutes = (int)(_timeLeft / 60);
            int seconds = (int)(_timeLeft % 60);
            _label.Text = $"{minutes:D2}:{seconds:D2}"; 
        }
    }

    private void UpdateCurrencyLabel()
    {
        if (_currencyLabel != null)
        {
            _currencyLabel.Text = $"{GameManager.Instance.Currency}";
        }
    }

    private void OnTimerTimeout()
    {
        GD.Print("time is up!");
        _label.Text = "00:00";
        Visible = false;
    }
}
