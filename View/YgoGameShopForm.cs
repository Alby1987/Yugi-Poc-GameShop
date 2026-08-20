using System.Windows.Forms;
using Yugi_Poc_GameShop.Model;
using Yugi_Poc_GameShop.View;

namespace Yugi_Poc_GameShop
{
    public partial class YgoGameShopForm : Form
    {
        private readonly YgoControl[] _controls;

        internal YgoGameShopForm(Context context, Images images)
        {
            InitializeComponent();
            context.LoadLibrary();
            context.LoadGameSave();
            images.LoadImages();
            _controls = new YgoControl[6];
            _controls[0] = new MenuControl(this, context)
            {
                Dock = DockStyle.Fill
            };
            _controls[1] = new OpenNewBoosterControl(this, context, images, false)
            {
                Dock = DockStyle.Fill
            };
            _controls[2] = new TraderChoiceCardsControl(this, context, images, false)
            {
                Dock = DockStyle.Fill
            };
            _controls[3] = new TraderChoiceCardsControl(this, context, images, true)
            {
                Dock = DockStyle.Fill
            };
            _controls[4] = new OpenNewBoosterControl(this, context, images, true)
            {
                Dock = DockStyle.Fill
            };
            _controls[5] = new OptionsControl(this, context)
            {
                Dock = DockStyle.Fill
            };

            Controls.Clear();
            Controls.Add(_controls[0]);
        }

        internal void BackMenu()
        {
            _controls[0].Reset();
            Controls.Clear();
            Controls.Add(_controls[0]);
        }

        internal void OpenNewBooster()
        {
            _controls[1].Reset();
            Controls.Clear();
            Controls.Add(_controls[1]);
        }

        internal void CardTrader()
        {
            _controls[2].Reset();
            Controls.Clear();
            Controls.Add(_controls[2]);
        }

        internal void OpenMagicBooster()
        {
            _controls[3].Reset();
            Controls.Clear();
            Controls.Add(_controls[3]);
        }

        internal void OpenMagicBoosterOpen()
        {
            _controls[4].Reset();
            Controls.Clear();
            Controls.Add(_controls[4]);
        }

        internal void ChangeCardsLanguage()
        {
            _controls[5].Reset();
            Controls.Clear();
            Controls.Add(_controls[5]);
        }
    }
}
