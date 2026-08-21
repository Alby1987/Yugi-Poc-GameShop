using System;
using System.Drawing;
using System.Windows.Forms;

namespace Yugi_Poc_GameShop.Helpers
{
    internal class CardFlipper
    {
        private readonly PictureBox _pictureBox;
        private readonly Timer _timer;

        private Image _backImage;
        private Image _frontImage;
        private Action _onComplete;

        private float _scale = 1.0f;
        private bool _showingFront = false;
        private int _step = 0;
        private const int TOTAL_STEPS = 24;

        internal CardFlipper(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
            _timer = new Timer
            {
                Interval = 15 // ~60 FPS
            };
            _timer.Tick += Timer_Tick;
        }

        internal void RevealCard(Image backImage, Image frontImage, Action onComplete = null)
        {
            _backImage = backImage;
            _frontImage = frontImage;
            _onComplete = onComplete;
            _showingFront = false;
            _scale = 1.0f;
            _step = 0;

            _pictureBox.Image = _backImage;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _step++;

            if (!_showingFront)
            {
                _scale = 1.0f - ((float)_step / (TOTAL_STEPS / 2));

                if (_scale <= 0.05f)
                {
                    _scale = 0.0f;
                    _showingFront = true;
                }
            }
            else
            {
                _scale = ((float)(_step - (TOTAL_STEPS / 2)) / (TOTAL_STEPS / 2));

                if (_scale >= 1.0f)
                {
                    _scale = 1.0f;
                    _timer.Stop();
                    _pictureBox.Image = _frontImage;
                    _onComplete?.Invoke();
                    return;
                }
            }

            RenderFrame();
        }

        private void RenderFrame()
        {
            Image currentSource = _showingFront ? _frontImage : _backImage;

            if (currentSource == null || _pictureBox.Width <= 0 || _pictureBox.Height <= 0)
                return;

            Bitmap bmp = new Bitmap(_pictureBox.Width, _pictureBox.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                int newWidth = (int)(_pictureBox.Width * _scale);
                int x = (_pictureBox.Width - newWidth) / 2;

                g.DrawImage(currentSource, x, 0, newWidth, _pictureBox.Height);
            }

            Image oldImage = _pictureBox.Image;
            _pictureBox.Image = bmp;

            if (oldImage != null && oldImage != _backImage && oldImage != _frontImage)
            {
                oldImage.Dispose();
            }
        }
    }
}
