using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace EEWorldMap
{
	public static class Block
	{

		public static Bitmap voidImg;

		public static Bitmap[] all = null;

		public static Bitmap GetBlockImage(int id)
		{
			if (all == null)
			{
				voidImg = new Bitmap(16, 16);
				for (int x = 0; x < 16; x++)
					for (int y = 0; y < 16; y++)
						voidImg.SetPixel(x, y, Color.FromArgb(0, 0, 0));
				Bitmap blx = Properties.Resources.allBlocks;
				all = new Bitmap[blx.Width / 16];
				for (int a = 0; a < blx.Width / 16; a++)
					all[a] = (Bitmap)blx.Clone(new Rectangle(a * 16, 0, 16, 16), blx.PixelFormat);
			}
			if (all.Length > id)
			{
				return all[id];
			}
			else
				return all[0];
		}
		public static Bitmap Overlap(Bitmap current, Bitmap overlap, int x, int y)
		{
				using (Graphics g = Graphics.FromImage(current))
				{
					g.DrawImageUnscaled(overlap, x, y);
				}
				return current;
		}
	}
}
