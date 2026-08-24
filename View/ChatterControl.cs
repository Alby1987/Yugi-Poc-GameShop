using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Yugi_Poc_GameShop.Controller;

namespace Yugi_Poc_GameShop.View
{
    internal partial class ChatterControl : YgoControl
    {
        private readonly YgoGameShopForm _form;
        private readonly Context _context;
        private readonly Queue<string> _phrases = new Queue<string>();

        internal ChatterControl(YgoGameShopForm form, Context context)
        {
            InitializeComponent();
            _form = form;
            _context = context;
        }

        public override void Reset()
        {
            ChatterLabel.Text = null;
            _phrases.Clear();
        }

        internal void GetChatter(bool justUpdate)
        {
            var phrases = Chatter.GetChat(_context, justUpdate);
            if (phrases.Count() > 0)
            {
                _context.SaveSettings();
            }
            foreach (var chatter in phrases)
            {
                _phrases.Enqueue(chatter);
            }
            Next();
        }

        private void Next()
        {
            while (_phrases.Count != 0)
            {
                var text = _phrases.Dequeue();
                if (!string.IsNullOrEmpty(text))
                {
                    ChatterLabel.Text = text;
                    return;
                }
            }

            Reset();
            _form.BackMenuChatter();
        }

        private void ChatterControl_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void ChatterControl_KeyDown(object sender, KeyEventArgs e)
        {
            Next();
        }

        private void ChatterLabel_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
