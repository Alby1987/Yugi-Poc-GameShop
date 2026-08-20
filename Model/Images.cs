using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Yugi_Poc_GameShop.Properties;

namespace Yugi_Poc_GameShop.Model
{
    internal class Images
    {
        internal ImageList _thumbnails;
        
        private readonly Dictionary<string, Image> _imageCache = new Dictionary<string, Image>();
        private readonly Context _context;

        internal Images(Context context)
        {
            _context = context;
        }

        internal ImageList Thumbnails => _thumbnails;
        internal Dictionary<string, Image> ImageCache => _imageCache;
        internal string Unknown => "card_ura.bmp";
        internal Bitmap Y {get; private set;}
        internal Bitmap Y1 {get; private set;}
        internal Bitmap K {get; private set;}
        internal Bitmap K1 {get; private set;}
        internal Bitmap J {get; private set;}
        internal Bitmap J1 {get; private set;}

        internal void LoadImages()
        {
            _thumbnails = new ImageList
            {
                ImageSize = new Size(20, 29),
                ColorDepth = ColorDepth.Depth32Bit
            };

            var showCards = _context.GetCardListCopy();

            for (int i = 0; i < showCards.Count; i++)
            {
                Image imgToAdd = null;
                var cardData = _context.GetCard(i);

                if (!cardData.VersionYugi && !cardData.VersionKaiba && !cardData.VersionJoey && i != 0)
                {
                    continue;
                }

                if (cardData != null)
                {
                    string imgPath = _context.GetImagePath(cardData.ImageName);

                    if (File.Exists(imgPath))
                    {
                        using (FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image img = Image.FromStream(fs))
                            {
                                imgToAdd = new Bitmap(img);
                            }
                        }
                    }
                }

                _thumbnails.Images.Add(cardData.ImageName, imgToAdd);
                _imageCache.Add(cardData.ImageName, imgToAdd);
            }

            Y = Resources.Y;
            Y1 = Resources.Y1;
            K = Resources.K;
            K1 = Resources.K1;
            J = Resources.J;
            J1 = Resources.J1;
        }
    }
}
