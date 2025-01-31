using Godot;
using desktopidlegamesoftwareengineering.scripts.managers;

namespace desktopidlegamesoftwareengineering.scripts.ui
{
    public partial class Countdown : Node2D
    {
        private Label _label;
        private float _timeLeft = 3600f;
        private float _currencyTimer = 0f;

        public bool IsTimerRunning { get; private set; }
        public float TimeLeft => _timeLeft;

        public override void _Ready()
        {
            _label = GetNode<Label>("Label");

            Label currencyLabel = GetNode<Label>("/root/Main/Interface/MarginContainer2/CurrencyLabel");
            if (currencyLabel != null)
            {
                GameManager.Instance.RegisterCurrencyLabel(currencyLabel);
            }
            else
            {
                GD.PrintErr("[Countdown] ERROR: CurrencyLabel not found!");
            }

            UpdateLabel();
            IsTimerRunning = false;
        }

        public void StartTimer()
        {
            if (IsTimerRunning)
            {
                GD.Print("[Countdown] timer is already running!");
                return;
            }

            IsTimerRunning = true;
            GD.Print("[Countdown] timer started!");
        }

        public void ResetTimer()
        {
            _timeLeft = 3600f;
            UpdateLabel();
            IsTimerRunning = false;
            GD.Print("[Countdown] timer has been reset!");
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
                    _currencyTimer = 0f;
                }

                if (_timeLeft <= 0)
                {
                    _timeLeft = 0;
                    IsTimerRunning = false;
                    GD.Print("[Countdown] time is up!");
                }

                UpdateLabel();
            }

            //press 0 to finsih timer
            HandleDebugInputs();
        }

        private void HandleDebugInputs()
        {
            if (Input.IsActionJustPressed("debug_timer_finish"))
            {
                GD.Print("[DEBUG] timer manually finished!");
                _timeLeft = 0;
                IsTimerRunning = false;
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
    }
}
