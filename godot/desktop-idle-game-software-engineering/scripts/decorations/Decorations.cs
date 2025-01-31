using Godot;
using desktopidlegamesoftwareengineering.scripts.managers;

namespace desktopidlegamesoftwareengineering.scripts.decorations
{
    public partial class Decorations : Node
    {
        private Sprite2D _castle;
        private Sprite2D _ship;

        public override void _Ready()
        {
            GD.Print("[Decorations] Initializing decorations...");

            _castle = GetNodeOrNull<Sprite2D>("/root/Main/Decorations/DecorationCastle");
            _ship = GetNodeOrNull<Sprite2D>("/root/Main/Decorations/DecorationShip");

            // Verify nodes were found
            if (_castle == null)
                GD.PrintErr("[Decorations] ERROR: castle decoration not found!");
            else
                GD.Print("[Decorations] castle found successfully.");

            if (_ship == null)
                GD.PrintErr("[Decorations] ERROR: ship decoration not found!");
            else
                GD.Print("[Decorations] ship found successfully.");

            // Ensure decorations start hidden if not purchased
            UpdateDecorationsVisibility();
        }

        private void UpdateDecorationsVisibility()
        {
            if (_castle != null)
                _castle.Visible = GameManager.Instance.CastlePurchased;

            if (_ship != null)
                _ship.Visible = GameManager.Instance.ShipPurchased;

            GD.Print($"[Decorations] updated visibility → castle: {_castle?.Visible}, ship: {_ship?.Visible}");
        }

        public void TryPurchaseCastle()
        {
            if (GameManager.Instance.PurchaseCastle())
            {
                if (_castle != null)
                {
                    _castle.Visible = true;
                    GD.Print("[Decorations] castle purchased! now visible :)");
                }
                else
                {
                    GD.PrintErr("[Decorations] ERROR: castle reference is null!");
                }
            }
            else
            {
                GD.Print("[Decorations] not enough currency for the castle!");
            }
        }

        public void TryPurchaseShip()
        {
            if (GameManager.Instance.PurchaseShip())
            {
                if (_ship != null)
                {
                    _ship.Visible = true;
                    GD.Print("[Decorations] Ship purchased! now visible :)");
                }
                else
                {
                    GD.PrintErr("[Decorations] ERROR: ship reference is null!");
                }
            }
            else
            {
                GD.Print("[Decorations] not enough currency or castle not purchased yet!");
            }
        }
    }
}
