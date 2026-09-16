using System;
using System.Windows.Forms;

namespace Yugi_Poc_GameShop.View
{
    internal partial class OptionsControl : YgoControl
    {
        private readonly YgoGameShopForm _form;
        private readonly Context _context;

        public OptionsControl(YgoGameShopForm form, Context context)
        {
            InitializeComponent();
            _form = form;
            _context = context;
        }

        private void LanguageSelect_Load(object sender, EventArgs e)
        {
            LanguagesComboBox.Items.AddRange(_context.GetLanguages());
            LanguagesComboBox.SelectedItem = _context.GetLanguage();
        }

        public override void Reset()
        {
            LanguagesComboBox.SelectedItem = _context.GetLanguage();
            TokensCountdownLabel.Text = _context.GetTokenCountdown().ToString();
            TokenGenerationProgressBar.Value = _context.GetTokenProgressPercentage();
            InstalledGamesLabel.Text = _context.InstalledGames.ToString();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Reset();
            _form.BackMenu();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var newLang = (string)LanguagesComboBox.SelectedItem;
            if (newLang == _context.GetLanguage())
            {
                Reset();
                _form.BackMenu();
                return;
            }

            _context.SetLanguage(newLang);
            MessageBox.Show("Please restart the software", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        private void OptionsTimer_Tick(object sender, EventArgs e)
        {
            TokensCountdownLabel.Text = _context.GetTokenCountdown().ToString();
            TokenGenerationProgressBar.Value = _context.GetTokenProgressPercentage();
        }
    }
}
