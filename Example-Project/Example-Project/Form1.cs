using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EEWorldMap;

namespace ExampleProject
{
	public partial class Form1 : Form
	{
		public Form1()
		{

			//Its a good idea to take a look at the form designer code for eeMap1

			InitializeComponent();
		}

		//Our rendering variables
		public static int RenderX = 0, RenderY = 0;

		//Render
		private void Render()
		{
			eeMap1.Render(RenderX, RenderY);

			//Update the numerics on the form design
			renderXNumeric.Value = RenderX;
			renderYNumeric.Value = RenderY;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//Let the block array load
			Block.GetBlockImage(1); //Takes 45 seconds (On my 1.6 GHz proccessor)
			Render();
		}

		private void EEBlockDraw(object sender, BlockDrawArgs e)
		{
			//copy & pasted code from readme
			int BlockLayer = Convert.ToInt32(blockLayer.Value);
			uint BlockID = Convert.ToUInt32(blockId.Value);
			eeMap1 = e.PlaceOnMap(BlockLayer, RenderX, RenderY, BlockID);
			eeMap1.RenderBlockPlace(RenderX, RenderY, e.BlockX, e.BlockY);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			//Fill the map
			int BlockLayer = Convert.ToInt32(blockLayer.Value);
			uint BlockID = Convert.ToUInt32(blockId.Value);
			for (int x = 0; x < eeMap1.MapBlocks.GetLength(1); x++) //Get the 2nd dimension in the 3d array
				for (int y = 0; y < eeMap1.MapBlocks.GetLength(2); y++) //Get the 3rd dimension in the 3d array
					eeMap1.MapBlocks[BlockLayer, x, y] = BlockID; //set the block to that
			Render(); //render it
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// up button
			RenderY--;
			Render();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// left button
			RenderX--;
			Render();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// down button
			RenderY++;
			Render();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// right button
			RenderX++;
			Render();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			//A quick render button
			RenderX = Convert.ToInt32(renderXNumeric.Value);
			RenderY = Convert.ToInt32(renderYNumeric.Value);
			Render();
		}

		private void blockId_ValueChanged(object sender, EventArgs e)
		{
			//Make a little picturebox show what block they're using
			showBlock.Image = Block.GetBlockImage(Convert.ToInt32(blockId.Value));
		}
	}
}
