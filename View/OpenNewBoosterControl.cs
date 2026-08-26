using System;
using Yugi_Poc_GameShop.Helpers;
using Yugi_Poc_GameShop.Model;
using Yugi_Poc_GameShop.PoCTools;

namespace Yugi_Poc_GameShop.View
{
    internal partial class OpenNewBoosterControl : YgoControl
    {
        private readonly YgoGameShopForm _form;
        private readonly Context _context;
        private readonly bool _onlyNew;
        private readonly Images _images;
        private readonly CardFlipper _leftCardFlipper;
        private readonly CardFlipper _centerCardFlipper;
        private readonly CardFlipper _rightCardFlipper;

        public OpenNewBoosterControl(YgoGameShopForm form, Context context, Images images, bool onlyNew)
        {
            InitializeComponent();
            _form = form;
            _context = context;
            _onlyNew = onlyNew;
            _images = images;
            _leftCardFlipper = new CardFlipper(LeftPictureBox);
            _centerCardFlipper = new CardFlipper(CenterPictureBox);
            _rightCardFlipper = new CardFlipper(RightPictureBox);
            Reset();
        }

        public override void Reset()
        {
            var ynew = _onlyNew ? _context.GetRandomNewCard(CardFilter.Only_Yugi) != -1 : _context.GetRandomCard(CardFilter.Only_Yugi) != -1;
            var knew = _onlyNew ? _context.GetRandomNewCard(CardFilter.Only_Kaiba) != -1 : _context.GetRandomCard(CardFilter.Only_Kaiba) != -1;
            var jnew = _onlyNew ? _context.GetRandomNewCard(CardFilter.Only_Joey) != -1 : _context.GetRandomCard(CardFilter.Only_Joey) != -1;
            LeftPictureBox.Enabled = _context.InstalledGames.Yugi && ynew;
            CenterPictureBox.Enabled = _context.InstalledGames.Kaiba && knew;
            RightPictureBox.Enabled = _context.InstalledGames.Joey && jnew;
            LeftPictureBox.Image = LeftPictureBox.Enabled ? _images.Y : _images.Y1;
            CenterPictureBox.Image = CenterPictureBox.Enabled ? _images.K : _images.K1;
            RightPictureBox.Image = RightPictureBox.Enabled ? _images.J : _images.J1;
            LeftRichTextBox.Clear();
            CenterRichTextBox.Clear();
            RightRichTextBox.Clear();
        }

        private void LeftPictureBox_Click(object sender, EventArgs e)
        {
            OpenBooster(CardFilter.Only_Yugi);
        }

        private void CenterPictureBox_Click(object sender, EventArgs e)
        {
            OpenBooster(CardFilter.Only_Kaiba);
        }

        private void RightPictureBox_Click(object sender, EventArgs e)
        {
            OpenBooster(CardFilter.Only_Joey);
        }

        private void OpenBooster(CardFilter filter)
        {
            LeftPictureBox.Enabled = false;
            CenterPictureBox.Enabled = false;
            RightPictureBox.Enabled = false;
            if (_onlyNew)
            {
                var newCard = _context.GetRandomNewCard(filter);
                if (newCard == -1)
                {
                    return;
                }

                var card = _context.GetCard(newCard);
                _context.AddOne(newCard);
                _context.Apply();
                LeftPictureBox.Image = null;
                RightPictureBox.Image = null;
                LeftRichTextBox.Clear();
                RightRichTextBox.Clear();
                _centerCardFlipper.RevealCard(_images.ImageCache[_images.Unknown], _images.ImageCache[card.ImageName], () =>
                {
                    SetText(CenterRichTextBox, card, true);
                });
                return;
            }

            if (_context.GetTokens() == 0 && _context.GetPoints() == 0)
            {
                return;
            }

            _context.ConsumeTokensOrPoints();
            var cardIndexes = new int[3];
            var cards = new Card[3];
            var newCards = new bool[3];
            for (int i = 0; i < cards.Length; i++)
            {
                cardIndexes[i] = _context.GetRandomCard(filter);
                if (cardIndexes[i] == -1)
                {
                    continue;
                }
                cards[i] = _context.GetCard(cardIndexes[i]);
                newCards[i] = !_context.IsKnown(cardIndexes[i]);
                _context.AddOne(cardIndexes[i]);
            }

            _context.Apply();
            _leftCardFlipper.RevealCard(_images.ImageCache[_images.Unknown], _images.ImageCache[cards[0]?.ImageName ?? _images.Unknown], () =>
            {
                SetText(LeftRichTextBox, cards[0], newCards[0]);
            });
            _centerCardFlipper.RevealCard(_images.ImageCache[_images.Unknown], _images.ImageCache[cards[1]?.ImageName ?? _images.Unknown], () =>
            {
                SetText(CenterRichTextBox, cards[1], newCards[1]);
            });
            _rightCardFlipper.RevealCard(_images.ImageCache[_images.Unknown], _images.ImageCache[cards[2]?.ImageName ?? _images.Unknown], () =>
            {
                SetText(RightRichTextBox, cards[2], newCards[2]);
            });
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Reset();
            _form.BackMenu();
        }
    }
}
