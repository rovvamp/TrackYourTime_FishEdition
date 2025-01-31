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
            _decorations = GetNode<Decorations>("/root/Main/Decorations");

            Pressed += OnButtonPressed;
        }

        private void OnButtonPressed()
        {
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
