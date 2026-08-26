using System;

namespace Yugi_Poc_GameShop.View
{
    internal partial class MenuControl : YgoControl
    {
        private readonly YgoGameShopForm _form;
        private readonly Context _context;
        private int _tokens;
        private int _points;

        public MenuControl(YgoGameShopForm form, Context context)
        {
            InitializeComponent();
            _form = form;
            _context = context;
            Reset();
        }

        public override void Reset()
        {
            _tokens = _context.GetTokens();
            _points = _context.GetPoints();

            if (_context.GetWinningDuelsExpired())
            {
                OpenBoosterPackButton.Enabled = false;
                OpenBoosterPackButton.Text = $"Open Booster Pack - Tokens: {_tokens} - Points: {_points} - Win a duel to open it";
            }
            else
            {
                OpenBoosterPackButton.Enabled = _tokens > 0 || _points > 9;
                OpenBoosterPackButton.Text = $"Open Booster Pack - Tokens: {_tokens} - Points: {_points}";
            }
        }

        private void OpenBoosterPackButton_Click(object sender, EventArgs e)
        {
            _form.OpenNewBooster();
        }

        private void OpenCardTraderButton_Click(object sender, EventArgs e)
        {
            _form.CardTrader();
        }

        private void OpenMagicBoosterButton_Click(object sender, EventArgs e)
        {
            _form.OpenMagicBooster();
        }

        private void OpenOptionsButton_Click(object sender, EventArgs e)
        {
            _form.ChangeCardsLanguage();
        }
    }
}
