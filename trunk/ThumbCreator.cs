using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace ThumbCreator
{
  public class ThumbCreator
  {
    private string _TargetFolder;
    public string TargetFolder
    {
      get { return _TargetFolder; }
      set { _TargetFolder = value; }
    }

    const int DefaltTumbWidth = 150;
    const int DefaltTumbHeight = 150;

    public void ConvertImageFile(string file)
    {
      // create an image object, using the filename we just retrieved
      System.Drawing.Image image = System.Drawing.Image.FromFile(file);
      int thumbWidth = DefaltTumbWidth;
      int thumbHeight = DefaltTumbHeight;
      Rectangle cropArea = new Rectangle(0, 0, DefaltTumbWidth - 1, DefaltTumbHeight - 1);

      if (image.Width > image.Height)
      {
        thumbWidth = DefaltTumbWidth * image.Width / image.Height;
        cropArea.X = (thumbWidth - DefaltTumbWidth) / 2;
      }
      else
      {
        thumbHeight = DefaltTumbHeight * image.Height / image.Width;
        cropArea.Y = (thumbHeight - DefaltTumbHeight) / 2;
      }
      System.Drawing.Image thumbnailImage = CropImage(ResizeImage(image, new Size(thumbWidth, thumbHeight)), cropArea);
      //thumbnailImage = CropImage(thumbnailImage, cropArea);

      string thumbFile = Path.Combine(TargetFolder, Path.GetFileName(file));
      // put the image into the memory stream
      thumbnailImage.Save(thumbFile, System.Drawing.Imaging.ImageFormat.Png);
    }

    public static Image ResizeImage(Image imgToResize, Size size)
    {
      int sourceWidth = imgToResize.Width;
      int sourceHeight = imgToResize.Height;

      float nPercent = 0;
      float nPercentW = 0; 
      float nPercentH = 0;

      nPercentW = ((float)size.Width / (float)sourceWidth);
      nPercentH = ((float)size.Height / (float)sourceHeight);

      if (nPercentH < nPercentW)
        nPercent = nPercentH;
      else
        nPercent = nPercentW;

      int destWidth = (int)(sourceWidth * nPercent);
      int destHeight = (int)(sourceHeight * nPercent);

      Bitmap b = new Bitmap(destWidth, destHeight);
      Graphics g = Graphics.FromImage((Image)b);
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;

      g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
      g.Dispose();

      return (Image)b;
    }

    public static Image CropImage(Image img, Rectangle cropArea)
    {
      Bitmap bmpImage = new Bitmap(img);
      Bitmap bmpCrop = bmpImage.Clone(cropArea,
      bmpImage.PixelFormat);
      return (Image)(bmpCrop);
    }
  }
}
