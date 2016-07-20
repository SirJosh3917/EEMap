using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EEWorldMap
{

	/// <summary>
	/// Create an instance of an EEMap.
	/// </summary>
	public class EEMap : Panel
	{
		#region double buffered panel
		
		private int width = 0;
		private int height = 0;

		public int Width
		{
			get
			{
				return width;
			}
			set
			{
				if (value % 16 > 8)
					width = value - (value % 16) + 1;
				else
					width = value - (value % 16);
				base.Width = width;
			}
		}
		public int Height
		{
			get
			{
				return height;
			}
			set
			{
				if (value % 16 > 8)
					height = value - (value % 16) + 1;
				else
					height = value - (value % 16);
				base.Height = height;
			}
		}
		public delegate void OnClickEvent(object sender, BlockDrawArgs e);
		#endregion

		//private variables
		private int pWidth = 2;
		private int pHeight = 2;
		private int key = 0;

		//event
		[Description("The event handler for when the map is clicked."), Category("EEMap Events")] 
		public event OnClickEvent OnBlockDraw;

		//make private public
		[Description("The map's width"), Category("EEMap Properties")] 
		public int MapWidth
		{
			get
			{
				return pWidth;
			}
			set
			{
				pWidth = value;
				InitMap(pWidth, pHeight);
			}
		}

		[Description("The map's height"), Category("EEMap Properties")] 
		public int MapHeight
		{
			get
			{
				return pHeight;
			}
			set
			{
				pHeight = value;
				InitMap(pWidth, pHeight);
			}
		}

		public uint[, ,] MapBlocks
		{
			get
			{
				return ArrayManager.maps[key];
			}
			set
			{
				if (value.Rank == 3)
					if (value.GetLength(0) == 2)
						if (value.GetLength(1) == pWidth)
							if (value.GetLength(2) == pHeight)
								ArrayManager.maps[key] = value;
							else
								throw new ArgumentException("The size of the array's height does not match the map's height.");
						else
							throw new ArgumentException("The size of the array's width does not match the map's width.");
					else
						throw new ArgumentException("The first dimension of the array should be equal to 2, foreground and background.");
				else
					throw new ArgumentException("The array needs to have three dimensions.");
			}
		}

		//functions

		/// <summary>
		/// Changes the size of the map.
		/// </summary>
		/// <param name="newWidth">The new width of the map.</param>
		/// <param name="newHeight">The new height of the map.</param>
		public void ChangeSize(int newWidth, int newHeight)
		{
			uint[, ,] newMap = new uint[2, newWidth, newHeight];
			for (int y = 0; y < newHeight; y++)
				for (int x = 0; x < newWidth; x++)
					if (x < ArrayManager.maps[key].GetLength(1) && y < ArrayManager.maps[key].GetLength(2))
					{
						newMap[0, x, y] = ArrayManager.maps[key][0, x, y];
						newMap[1, x, y] = ArrayManager.maps[key][1, x, y];
					} else {
						newMap[0, x, y] = 0;
						newMap[1, x, y] = 0;
					}
			ArrayManager.maps[key] = newMap;
		}

		#region Rendering

		/// <summary>
		/// Render the image starting from the upper left X and the upper left Y, 16x16 measurements.
		/// Try to not use this alot, as it will cause delay.
		/// </summary>
		/// <param name="xUpperLeft">The upper-left corner X position of the block to render on.</param>
		/// <param name="yUpperLeft">The upper-left corner Y position of the block to render on.</param>
		public void Render(int xUpperLeft, int yUpperLeft)
		{
			Bitmap img = new Bitmap((base.Size.Width - (base.Size.Width % 16) / 16), (base.Size.Height - (base.Size.Width % 16) / 16));
			for (int x = 0; x < (base.Size.Width - (base.Size.Width % 16) / 16); x++)
				for (int y = 0; y < (base.Size.Height - (base.Size.Height % 16) / 16); y++)
					if (!(xUpperLeft + x >= ArrayManager.maps[key].GetLength(1) || yUpperLeft + y >= ArrayManager.maps[key].GetLength(2)))
						if (xUpperLeft + x < 0 || yUpperLeft + y < 0)
							Block.Overlap(img, Block.emptyBitmap, x * 16, y * 16);
						else
						{
							Block.Overlap(img, Block.GetBlockImage(Convert.ToInt32(ArrayManager.maps[key][1, x + xUpperLeft, y + yUpperLeft])), x * 16, y * 16);
							if (ArrayManager.maps[key][0, x + xUpperLeft, y + yUpperLeft] != 0)
								Block.Overlap(img, Block.GetBlockImage(Convert.ToInt32(ArrayManager.maps[key][0, x + xUpperLeft, y + yUpperLeft])), x * 16, y * 16);
						}
					else
						Block.Overlap(img, Block.emptyBitmap, x * 16, y * 16);
			base.BackgroundImage = img;
		}

		/// <summary>
		/// Used to render just one block being placed.
		/// </summary>
		/// <param name="xUpperLeft">The upper-left corner X position of the block to render on.</param>
		/// <param name="yUpperLeft">The upper-left corner Y position of the block to render on.</param>
		/// <param name="blockX">The X position of the block to render.</param>
		/// <param name="blockY">The Y position of the block to render.</param>
		public void RenderBlockPlace(int xUpperLeft, int yUpperLeft, int blockX, int blockY)
		{
			Bitmap over = new Bitmap(16, 16);
			over = Block.Overlap(over, Block.GetBlockImage(Convert.ToInt32(ArrayManager.maps[key][1, blockX + xUpperLeft, blockY + yUpperLeft])), 0, 0);
			if (ArrayManager.maps[key][0, blockX + xUpperLeft, blockY + yUpperLeft] != 0)
				over = Block.Overlap(over, Block.GetBlockImage(Convert.ToInt32(ArrayManager.maps[key][0, blockX + xUpperLeft, blockY + yUpperLeft])), 0, 0);
			base.BackgroundImage = Block.Overlap(new Bitmap(base.BackgroundImage), over, (blockX) * 16, (blockY) * 16);
		}

		#region Web Render

		/// <summary>
		/// Does the same as Render() but uses web block requests to grab the latest and greatest blocks.
		/// </summary>
		/// <param name="xUpperLeft">The upper-left corner X position of the block to render on.</param>
		/// <param name="yUpperLeft">The upper-left corner Y position of the block to render on.</param>
		public void RenderUsingWeb(int xUpperLeft, int yUpperLeft)
		{
			Bitmap img = new Bitmap((base.Size.Width - (base.Size.Width % 16) / 16), (base.Size.Height - (base.Size.Width % 16) / 16));
			for (int x = 0; x < (base.Size.Width - (base.Size.Width % 16) / 16); x++)
				for (int y = 0; y < (base.Size.Height - (base.Size.Height % 16) / 16); y++)
					if (!(xUpperLeft + x >= ArrayManager.maps[key].GetLength(1) || yUpperLeft + y >= ArrayManager.maps[key].GetLength(2)))
						if (xUpperLeft + x < 0 || yUpperLeft + y < 0)
							Block.Overlap(img, Block.emptyBitmap, x * 16, y * 16);
						else
						{
							Block.Overlap(img, Block.GetBlockImageFromWeb(Convert.ToInt32(ArrayManager.maps[key][1, x + xUpperLeft, y + yUpperLeft])), x * 16, y * 16);
							if (ArrayManager.maps[key][0, x + xUpperLeft, y + yUpperLeft] != 0)
								Block.Overlap(img, Block.GetBlockImageFromWeb(Convert.ToInt32(ArrayManager.maps[key][0, x + xUpperLeft, y + yUpperLeft])), x * 16, y * 16);
						}
					else
						Block.Overlap(img, Block.emptyBitmap, x * 16, y * 16);
			base.BackgroundImage = img;
		}

		/// <summary>
		/// Does the same as RenderBlockPlace() but uses web block requests to grab the latest and greatest blocks.
		/// </summary>
		/// <param name="xUpperLeft">The upper-left corner X position of the block to render on.</param>
		/// <param name="yUpperLeft">The upper-left corner Y position of the block to render on.</param>
		/// <param name="blockX">The X position of the block to render.</param>
		/// <param name="blockY">The Y position of the block to render.</param>
		public void RenderBlockPlaceUsingWeb(int xUpperLeft, int yUpperLeft, int blockX, int blockY)
		{
			Bitmap over = new Bitmap(16, 16);
			over = Block.Overlap(over, Block.GetBlockImageFromWeb(Convert.ToInt32(ArrayManager.maps[key][1, blockX + xUpperLeft, blockY + yUpperLeft])), 0, 0);
			if (ArrayManager.maps[key][0, blockX + xUpperLeft, blockY + yUpperLeft] != 0)
				over = Block.Overlap(over, Block.GetBlockImageFromWeb(Convert.ToInt32(ArrayManager.maps[key][0, blockX + xUpperLeft, blockY + yUpperLeft])), 0, 0);
			base.BackgroundImage = Block.Overlap(new Bitmap(base.BackgroundImage), over, (blockX) * 16, (blockY) * 16);
		}

		#endregion

		#endregion

		/// <summary>
		/// Creates a new instance of an EEMap
		/// </summary>
		/// <param name="mapWidth"></param>
		/// <param name="mapHeight"></param>
		public EEMap() : base()
		{
			this.DoubleBuffered = true;
			key = ArrayManager.keyNum;
			ArrayManager.maps.Add(new uint[2,1,1]);
			ArrayManager.keyNum++;
		}

		/// <summary>
		/// Initialize the map
		/// </summary>
		/// <param name="mapWidth">The map's width</param>
		/// <param name="mapHeight">The map's height</param>
		public void InitMap(int mapWidth, int mapHeight)
		{
			uint[, ,] map = new uint[2, mapWidth, mapHeight];
			for (int x = 0; x < mapWidth; x++)
				for (int y = 0; y < mapHeight; y++)
				{
					map[0, x, y] = 0;
					map[1, x, y] = 0;
				}
			pWidth = mapWidth;
			pHeight = mapHeight;
			ArrayManager.maps[key] = map;
			MouseClick += EEMap_MouseClick;
		}

		/// <summary>
		/// Occurs when the panel is clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void EEMap_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (OnBlockDraw != null)
			{
				int BlockX = (e.X - (e.X % 16)) / 16,
					BlockY = (e.Y - (e.Y % 16)) / 16;
				BlockDrawArgs send = new BlockDrawArgs();
				send.BlockX = BlockX;
				send.BlockY = BlockY;
				send.MapToPlaceOn = this;
				OnBlockDraw(this, send);
			}
		}
	}

	public static class ArrayManager
	{
		public static List<uint[, ,]> maps = new List<uint[, ,]>();
		public static int keyNum = 0;
	}
}
