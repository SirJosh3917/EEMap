using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EEWorldMap
{
	public delegate void OnClickEvent(object sender, BlockDrawArgs e);
	public class BlockDrawArgs
	{
		internal EEMap MapToPlaceOn;
		public int BlockX;
		public int BlockY;
		public EEMap PlaceOnMap(int Layer, int RenderX, int RenderY, uint BlockID)
		{
			if (MapToPlaceOn == null)
				throw new Exception("The EEMap is not defined.");

			if (MapToPlaceOn.MapBlocks == null)
				throw new Exception("The EEMap doesn't yet have a map attached.");

			if (!(Layer == 1 || Layer == 0))
				throw new ArgumentException("The layer has to be 1 or 0, 0 for foreground, 1 for background.");

			if (RenderX + BlockX >= MapToPlaceOn.MapBlocks.GetLength(1))
				throw new ArgumentException("The RenderX + BlockX is greater than the X axis of the map.");

			if (RenderY + BlockY >= MapToPlaceOn.MapBlocks.GetLength(2))
				throw new ArgumentException("The RenderY + BlockY is greater than the Y axis of the map.");

			if (RenderX + BlockX <= -1)
				throw new ArgumentException("The RenderX + BlockX is less than 0");

			if (RenderY + BlockY <= -1)
				throw new ArgumentException("The RenderY + BlockY is less than 0");

			MapToPlaceOn.MapBlocks[Layer, RenderX + BlockX, RenderY + BlockY] = Convert.ToUInt32(BlockID);

			return MapToPlaceOn;
		}
	}
}