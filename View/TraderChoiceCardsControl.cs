using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Yugi_Poc_GameShop.Model;

namespace Yugi_Poc_GameShop.View
{
    internal partial class TraderChoiceCardsControl : YgoControl
    {
        private readonly YgoGameShopForm _form;
        private readonly Context _context;
        private readonly bool _tradeCards;
        private readonly Images _images;
        private Dictionary<int, byte> _showCards;
        private int _currentSortColumn = -1;
        private SortOrder _currentSortOrder = SortOrder.Ascending;

        public TraderChoiceCardsControl(YgoGameShopForm form, Context context, Images images, bool tradeCards)
        {
            InitializeComponent();
            _form = form;
            _context = context;
            _tradeCards = tradeCards;
            if (!tradeCards)
            {
                UpperGroupBox.Text = "Drop three cards to tribute";
                LowerGroupBox.Hide();
                LowerListView.Hide();
            }
            _images = images;
        }

        public override void Reset()
        {
            _showCards = _context.GetCardListCopy();

            ConfirmButton.Enabled = false;

            LeftListView.SelectedIndices.Clear();
            UpperListView.Items.Clear();
            LowerListView.Items.Clear();

            CardPictureBox.Image = null;
            DescriptionRichTextBox.Clear();

            UpdateCardAmounts();
        }

        private void CardTraderNewCards_Load(object sender, EventArgs e)
        {
            _showCards = _context.GetCardListCopy();

            LeftListView.SmallImageList = _images.Thumbnails;
            LeftListView.Items.Clear();
            LeftListView.BeginUpdate();

            for (int i = 0; i < _showCards.Count; i++)
            {
                var cardData = _context.GetCard(i);
                if (!cardData.VersionYugi && !cardData.VersionKaiba && !cardData.VersionJoey)
                {
                    continue;
                }

                var name = "???";
                var item = new ListViewItem(name);
                item.SubItems.Add("0");
                item.SubItems.Add("-");
                item.SubItems.Add("-");
                item.SubItems.Add("-");
                item.Tag = i;
                LeftListView.Items.Add(item);
            }

            LeftListView.EndUpdate();
            UpdateCardAmounts();
        }

        private void UpdateCardAmounts()
        {
            LeftListView.BeginUpdate();
            foreach (ListViewItem item in LeftListView.Items)
            {
                int cardId = (int)item.Tag;
                byte amount = _showCards.ContainsKey(cardId) ? _showCards[cardId] : (byte)0;
                var cardData = _context.GetCard(cardId);
                item.Text = amount > 0 ? cardData.Name : "???";
                item.BackColor = amount < 4 ? Color.LightBlue : Color.White;
                item.SubItems[1].Text = amount.ToString();
                item.SubItems[2].Text = amount > 0 && cardData.VersionYugi ? "Y" : "-";
                item.SubItems[3].Text = amount > 0 && cardData.VersionKaiba ? "K" : "-";
                item.SubItems[4].Text = amount > 0 && cardData.VersionJoey ? "J" : "-";
                item.ImageKey = amount > 0 ? cardData.ImageName : _images.Unknown;
            }

            var limit = _tradeCards ? 1 : 3;
            if (UpperListView.Items.Count == limit
                && (!_tradeCards || LowerListView.Items.Count == 1))
            {
                ConfirmButton.Enabled = true;
            }
            LeftListView.Invalidate();
            LeftListView.EndUpdate();
        }

        private void LeftListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var internalIndex = LeftListView.SelectedIndices.Count > 0 ? (int)LeftListView.SelectedItems[0].Tag : 0;
            var card = _context.GetCard(internalIndex);
            var amount = _showCards[internalIndex];
            CardPictureBox.Image = amount > 0 ? _images.ImageCache[card.ImageName] : _images.ImageCache[_images.Unknown];
            SetText(DescriptionRichTextBox, card, false, amount > 0);
        }

        private void UpperListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                var tag = (int)draggedItem.Tag;
                if (_showCards[tag] < 4)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                var limit = _tradeCards ? 1 : 3;
                if (_showCards[tag] > 3 && UpperListView.Items.Count < limit)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void UpperListView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                var tag = (int)draggedItem.Tag;
                _showCards[tag]--;
                draggedItem.SubItems[1].Text = _showCards[(int)draggedItem.Tag].ToString();

                UpperListView.Items.Add(new ListViewItem(draggedItem.Text)
                {
                    Tag = tag
                });
            }

            UpdateCardAmounts();
        }

        private void LeftListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void LowerListView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

                var tag = (int)draggedItem.Tag;
                draggedItem.SubItems[1].Text = _showCards[(int)draggedItem.Tag].ToString();

                LowerListView.Items.Add(new ListViewItem(draggedItem.Text)
                {
                    Tag = tag
                });
            }

            UpdateCardAmounts();
        }

        private void LowerListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                var tag = (int)draggedItem.Tag;
                if (_showCards[tag] > 0 && _showCards[tag] != 255 && LowerListView.Items.Count < 1)
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Reset();
            _form.BackMenu();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var limit = _tradeCards ? 1 : 3;
            if (UpperListView.Items.Count == limit
                && (!_tradeCards || LowerListView.Items.Count == 1))
            {
                foreach (ListViewItem item in UpperListView.Items)
                {
                    _context.RemoveOne((int)item.Tag);
                }
                foreach (ListViewItem item in LowerListView.Items)
                {
                    _context.AddOne((int)item.Tag);
                }

                if (_tradeCards)
                {
                    _context.Apply();
                    _context.Reset();
                    Reset();
                    _form.BackMenu();
                }
                else
                {
                    Reset();
                    _form.OpenMagicBoosterOpen();
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var search = LeftListView.FindItemWithText(SearchTextBox.Text);
            if (search != null)
            {
                search.Selected = true;
                search.EnsureVisible();
            }
        }

        private void LeftListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _currentSortColumn)
            {
                _currentSortOrder = (_currentSortOrder == SortOrder.Ascending)
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                _currentSortColumn = e.Column;
                _currentSortOrder = SortOrder.Ascending;
            }

            LeftListView.ListViewItemSorter = new ListViewItemComparer(_currentSortColumn, _currentSortOrder);
            LeftListView.Sort();
        }
    }

    internal class ListViewItemComparer : IComparer
    {
        private readonly int _columnIndex;
        private readonly SortOrder _sortOrder;

        public ListViewItemComparer(int columnIndex, SortOrder sortOrder)
        {
            _columnIndex = columnIndex;
            _sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            string nameX = itemX.Text ?? "";
            string nameY = itemY.Text ?? "";

            bool isXUnknown = nameX.Trim() == "???";
            bool isYUnknown = nameY.Trim() == "???";

            if (isXUnknown && isYUnknown)
            {
                return 0;
            }

            if (isXUnknown)
            {
                return 1;
            }

            if (isYUnknown)
            {
                return -1;
            }

            string textX = itemX.SubItems.Count > _columnIndex ? itemX.SubItems[_columnIndex].Text : "";
            string textY = itemY.SubItems.Count > _columnIndex ? itemY.SubItems[_columnIndex].Text : "";

            int result = string.Compare(textX, textY, StringComparison.CurrentCultureIgnoreCase);

            return _sortOrder == SortOrder.Descending ? -result : result;
        }
    }
}
