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
            GD.Print("[Decorations] _Ready() function started");

            _castle = GetNodeOrNull<Sprite2D>("/root/Main/Decorations/DecorationCastle");
            _ship = GetNodeOrNull<Sprite2D>("/root/Main/Decorations/DecorationShip");

            if (_castle == null)
                GD.PrintErr("[Decorations] castle decoration not found!");
            else
                GD.Print("[Decorations] castle found successfully");

            if (_ship == null)
                GD.PrintErr("[Decorations] ship decoration not found!");
            else
                GD.Print("[Decorations] ship found successfully");

            //ensure decorations start hidden if not purchased
            if (_castle != null) _castle.Visible = GameManager.Instance.CastlePurchased;
            if (_ship != null) _ship.Visible = GameManager.Instance.ShipPurchased;
        }

        public void TryPurchaseCastle()
        {
            if (GameManager.Instance.PurchaseCastle())
            {
                if (_castle != null) 
                {
                    _castle.Visible = true;
                    GD.Print("[Decorations] castle purchased and now visible!");
                }
                else
                {
                    GD.PrintErr("[Decorations] castle reference is null");
                }
            }
            else
            {
                GD.Print("[Decorations] not enough currency for castle!");
            }
        }

        public void TryPurchaseShip()
        {
            if (GameManager.Instance.PurchaseShip())
            {
                if (_ship != null)
                {
                    _ship.Visible = true;
                    GD.Print("[Decorations] ship purchased and now visible!");
                }
                else
                {
                    GD.PrintErr("[Decorations] ship reference is null!");
                }
            }
            else
            {
                GD.Print("[Decorations] not enough currency or castle not purchased yet!");
            }
        }
    }
}
