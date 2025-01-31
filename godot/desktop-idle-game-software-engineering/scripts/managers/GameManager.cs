using Godot;

namespace desktopidlegamesoftwareengineering.scripts.managers;

public partial class GameManager : Node
{
    private static GameManager _instance;
    public static GameManager Instance 
    { 
        get 
        { 
            if (_instance == null)
                GD.PrintErr("GameManager is null");
            return _instance; 
        } 
    }

    public int Currency { get; private set; } = 0;  //tracks currency
    public Label CurrencyLabel { get; private set; } //stores reference to the label

    public override void _Ready()
    {
        if (_instance == null)
        {
            _instance = this; //assign singleton instance
            GD.Print("GameManager is now active");
        }
        else
        {
            GD.PrintErr("multiple GameManager instances detected!");
            QueueFree(); //delete duplicate instances
        }
    }

    //register the currency label from another script
    public void RegisterCurrencyLabel(Label label)
    {
        CurrencyLabel = label;
        GD.Print("currencyLabel registered in GameManager");
    }


    //add currency and update label
    public void AddCurrency(int amount)
    {
        Currency += amount;
        GD.Print($"currency updated: {Currency}");

        if (CurrencyLabel != null)
            CurrencyLabel.Text = $"{Currency}";
        else
            GD.PrintErr("CurrencyLabel is null");
    }
}
