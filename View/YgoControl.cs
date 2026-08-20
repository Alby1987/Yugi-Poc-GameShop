using System.Drawing;
using System.Windows.Forms;
using Yugi_Poc_GameShop.PoCTools;

namespace Yugi_Poc_GameShop.View
{
    internal class YgoControl : UserControl
    {
        public virtual void Reset()
        {
        }

        internal void SetText(RichTextBox richTextBox, Card card, bool newCard, bool knownCard = true)
        {
            richTextBox.Clear();
            if (card == null)
            {
                return;
            }

            if (newCard)
            {
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                richTextBox.SelectionColor = Color.Red;
                richTextBox.AppendText($"NEW!\n\n");
                richTextBox.SelectionColor = Color.Black;
            }

            var name = knownCard ? card.Name : "???";
            var description = knownCard ? card.Description : "???";

            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
            richTextBox.AppendText($"{name}\n\n");
            richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Italic);
            richTextBox.AppendText(description);
        }
    }
}
