/********************************** Module Header **********************************\
Module Name:  RecipeThumbnailProvider.cs
Project:      CSShellExtThumbnailHandler
Copyright (c) Microsoft Corporation.

The RecipeThumbnailProvider.cs file defines a thumbnail handler for .recipe files.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***********************************************************************************/

#region Using directives
using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.ShellExtensions;
using CSharpTricks.Photoshop;
using System.Windows.Forms;
#endregion


namespace CSShellExtThumbnailHandler
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("8B95D7DF-2DB4-4A8D-8BE0-DBC986D385BD"), ComVisible(true)]
    [ThumbnailProvider("KulahciThumbnailProvider", ".psd", DisableProcessIsolation=true)]
    public class KulahciPsdThumbnailProvider : ThumbnailProvider, IThumbnailFromFile
    {
        #region IThumbnailFromStream Members

        public Bitmap ConstructBitmap(Stream stream, int sideSize)
        {
            return null;
            try
            {
               // MessageBox.Show("1. adim");   stream.Position = 0;
             
                CPSD psd = new CPSD();
                psd.Load(stream);
               // MessageBox.Show("3. adim");
                //FileStream tmpStrm = new FileStream(@"c:\sil.psd", FileMode.Create);
                
                //stream.CopyTo(tmpStrm);
                Bitmap psdBitmap = Image.FromHbitmap(psd.GetHBitmap());
                Size size = new Size();

                if (psdBitmap.Width > psdBitmap.Height)
                {
                    size.Height = psdBitmap.Height * sideSize / psdBitmap.Width;
                    size.Width = sideSize;
                }
                else
                {
                    size.Width = psdBitmap.Width * sideSize / psdBitmap.Height;
                    size.Height = sideSize;
                }
               // ((Bitmap)ThumbCreator.ThumbCreator.ResizeImage(psdBitmap, size)).Save(@"c:\sil.bmp");

                return ThumbCreator.ThumbCreator.ResizeImage(psdBitmap, size) as Bitmap;
                //using (var Thumbnail = new Bitmap(cx, cx))
                //{
                //  using (var G = Graphics.FromImage(Thumbnail))
                //  {
                //    G.Clear(Color.Red);
                //  }
                //  hBitmap = Thumbnail.GetHbitmap();
                //}
            }
            catch { } // A dirty cop-out.
            return Resource1.Dummy;
        }

        #endregion

        public Bitmap ConstructBitmap(FileInfo info, int sideSize)
        {
            CPSD psd = new CPSD();
            psd.Load(info.FullName);
                //MessageBox.Show(psd.IsThumbnailIncluded().ToString());
                return Bitmap.FromStream(new MemoryStream(psd.m_ThumbNail.Data)) as Bitmap;
            
        }
    }
}