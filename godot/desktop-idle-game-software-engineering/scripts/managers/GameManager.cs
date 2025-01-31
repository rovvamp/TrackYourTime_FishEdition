using Godot;

namespace desktopidlegamesoftwareengineering.scripts.managers
{
    public partial class GameManager : Node
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;
        private Label _currencyLabel;

        public int Currency { get; private set; } = 0;
        public bool CastlePurchased { get; private set; } = false;
        public bool ShipPurchased { get; private set; } = false;

        public override void _Ready()
        {
            GD.Print("[GameManager] _Ready() function started...");

            if (_instance == null)
            {
                _instance = this;
                GD.Print("[GameManager] GameManager is now active!");
            }
            else
            {
                QueueFree();
            }
        }

        public void RegisterCurrencyLabel(Label currencyLabel)
        {
            _currencyLabel = currencyLabel;
            UpdateCurrencyLabel();
        }

        public void AddCurrency(int amount)
        {
            Currency += amount;
            GD.Print($"[GameManager] currency updated: {Currency}");
            UpdateCurrencyLabel();
        }

        private void UpdateCurrencyLabel()
        {
            if (_currencyLabel != null)
            {
                _currencyLabel.Text = $"{Currency}";
            }
            else
            {
                GD.PrintErr("[GameManager] CurrencyLabel is null!");
            }
        }

        public bool PurchaseCastle()
        {
            if (Currency >= 100 && !CastlePurchased)
            {
                Currency -= 100;
                CastlePurchased = true;
                UpdateCurrencyLabel();
                return true;
            }
            return false;
        }

        public bool PurchaseShip()
        {
            if (Currency >= 200 && CastlePurchased && !ShipPurchased)
            {
                Currency -= 200;
                ShipPurchased = true;
                UpdateCurrencyLabel();
                return true;
            }
            return false;
        }

        public override void _Process(double delta)
        {
            if (Input.IsActionJustPressed("debug_add_currency"))
            {
                AddCurrency(300);
                GD.Print("added 300 currency!");
            }
        }
    }
}
