using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace EEWorldMap
{
	public static class Block
	{
		public static Bitmap emptyBitmap = new Bitmap(16, 16);
		public static Dictionary<int, Bitmap> blocksDictionary = new Dictionary<int, Bitmap>();

		static Block()
		{
			using (Graphics graphics = Graphics.FromImage(emptyBitmap))
			{
				graphics.Clear(Color.FromArgb(0, 0, 0));
			}
		}

		public static Bitmap GetBlockImage(int id)
		{
			Bitmap blocksBitmap = Properties.Resources.allBlocks;

			if (blocksDictionary.Count == 0)
			{
				for (int i = 0; i < blocksBitmap.Width / 16; i++)
				{
					blocksDictionary.Add(i, blocksBitmap.Clone(new Rectangle(i * 16, 0, 16, 16), blocksBitmap.PixelFormat));
				}

			}

			return (blocksDictionary.ContainsKey(id) ? blocksDictionary[id] : emptyBitmap);
		}

		public static Bitmap GetBlockImageFromWeb(int id)
		{
			if (blocksDictionary.ContainsKey(id))
			{
				return blocksDictionary[id];
			}

			try
			{
				using (WebClient client = new WebClient()
				{
					Proxy = null
				})
				{
					byte[] blockBytes = client.DownloadData("https://raw.githubusercontent.com/EEJesse/EEBlocks/master/Bricks/b" + id + ".png");
					Bitmap blockBitmap = (Bitmap)Image.FromStream(new MemoryStream(blockBytes));

					blocksDictionary.Add(id, blockBitmap);
					return blockBitmap;
				}
			}
			catch (WebException ex)
			{
				Console.WriteLine("Error: {0}", ex.Message);
				return emptyBitmap;
			}
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

//toaster code

/*if (all == null)
{
	voidImg = new Bitmap(16, 16);
	for (int x = 0; x < 16; x++)
		for (int y = 0; y < 16; y++)
			voidImg.SetPixel(x, y, Color.FromArgb(0, 0, 0));

	//splitting
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
	return all[0];*/
