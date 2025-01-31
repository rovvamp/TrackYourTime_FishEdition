using Godot;
using desktopidlegamesoftwareengineering.scripts.managers;
using desktopidlegamesoftwareengineering.scripts.decorations;

namespace desktopidlegamesoftwareengineering.scripts.ui
{
    public partial class DecorationButton : Button
    {
        private Decorations _decorations;

        public override void _Ready()
        {
            GD.Print("[BuyDecorationButton] _Ready() function started.");

            //get the decorations node
            _decorations = GetNode<Decorations>("/root/Main/Decorations");

            if (_decorations == null)
            {
                GD.PrintErr("[BuyDecorationButton] fecorations node not found!");
                return;
            }
            else
            {
                GD.Print("[BuyDecorationButton] decorations node found successfully");
            }

            //connect button click
            Pressed += OnButtonPressed;
            GD.Print("[BuyDecorationButton] pressed signal connected");
        }

        private void OnButtonPressed()
        {
            GD.Print("[BuyDecorationButton] button clicked");

            if (!GameManager.Instance.CastlePurchased)
            {
                GD.Print("[BuyDecorationButton] attempting to purchase castle...");
                _decorations.TryPurchaseCastle();
            }
            else if (!GameManager.Instance.ShipPurchased)
            {
                GD.Print("[BuyDecorationButton] attempting to purchase ship...");
                _decorations.TryPurchaseShip();
            }
            else
            {
                GD.Print("[BuyDecorationButton] no more decorations left to buy!");
            }
        }
    }
}
