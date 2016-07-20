namespace ExampleProject
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.eeMap1 = new EEWorldMap.EEMap();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.renderGroupbox = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.renderYNumeric = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.renderXNumeric = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.blockId = new System.Windows.Forms.NumericUpDown();
			this.blockLayer = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.showBlock = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.renderGroupbox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.renderYNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.renderXNumeric)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.blockId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blockLayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.showBlock)).BeginInit();
			this.SuspendLayout();
			// 
			// eeMap1
			// 
			this.eeMap1.Location = new System.Drawing.Point(21, 23);
			this.eeMap1.MapHeight = 10;
			this.eeMap1.MapWidth = 10;
			this.eeMap1.Name = "eeMap1";
			this.eeMap1.Size = new System.Drawing.Size(160, 160);
			this.eeMap1.TabIndex = 0;
			this.eeMap1.OnBlockDraw += new EEWorldMap.EEMap.OnClickEvent(this.EEBlockDraw);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.eeMap1);
			this.groupBox1.Location = new System.Drawing.Point(88, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(204, 199);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Picture";
			// 
			// renderGroupbox
			// 
			this.renderGroupbox.Controls.Add(this.button6);
			this.renderGroupbox.Controls.Add(this.label2);
			this.renderGroupbox.Controls.Add(this.renderXNumeric);
			this.renderGroupbox.Controls.Add(this.label1);
			this.renderGroupbox.Controls.Add(this.renderYNumeric);
			this.renderGroupbox.Controls.Add(this.button4);
			this.renderGroupbox.Controls.Add(this.button3);
			this.renderGroupbox.Controls.Add(this.button2);
			this.renderGroupbox.Controls.Add(this.button1);
			this.renderGroupbox.Location = new System.Drawing.Point(12, 217);
			this.renderGroupbox.Name = "renderGroupbox";
			this.renderGroupbox.Size = new System.Drawing.Size(214, 163);
			this.renderGroupbox.TabIndex = 2;
			this.renderGroupbox.TabStop = false;
			this.renderGroupbox.Text = "Rendering";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(37, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "^";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(23, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "<";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(59, 48);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(23, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = ">";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(37, 77);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(23, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "v";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// renderYNumeric
			// 
			this.renderYNumeric.Location = new System.Drawing.Point(107, 137);
			this.renderYNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.renderYNumeric.Name = "renderYNumeric";
			this.renderYNumeric.Size = new System.Drawing.Size(101, 20);
			this.renderYNumeric.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Render X Position";
			// 
			// renderXNumeric
			// 
			this.renderXNumeric.Location = new System.Drawing.Point(107, 111);
			this.renderXNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.renderXNumeric.Name = "renderXNumeric";
			this.renderXNumeric.Size = new System.Drawing.Size(101, 20);
			this.renderXNumeric.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 139);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Render Y Position";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.showBlock);
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.blockLayer);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.blockId);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(232, 217);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(166, 163);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Block Placing";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Block ID";
			// 
			// blockId
			// 
			this.blockId.Location = new System.Drawing.Point(60, 64);
			this.blockId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.blockId.Name = "blockId";
			this.blockId.Size = new System.Drawing.Size(101, 20);
			this.blockId.TabIndex = 8;
			this.blockId.ValueChanged += new System.EventHandler(this.blockId_ValueChanged);
			// 
			// blockLayer
			// 
			this.blockLayer.Location = new System.Drawing.Point(74, 90);
			this.blockLayer.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.blockLayer.Name = "blockLayer";
			this.blockLayer.Size = new System.Drawing.Size(86, 20);
			this.blockLayer.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(5, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Block Layer";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 116);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(152, 36);
			this.button5.TabIndex = 11;
			this.button5.Text = "Fill Map";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(107, 82);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(101, 23);
			this.button6.TabIndex = 8;
			this.button6.Text = "Render";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// showBlock
			// 
			this.showBlock.Location = new System.Drawing.Point(144, 42);
			this.showBlock.Name = "showBlock";
			this.showBlock.Size = new System.Drawing.Size(16, 16);
			this.showBlock.TabIndex = 12;
			this.showBlock.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 392);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.renderGroupbox);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "EE Map Example";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.renderGroupbox.ResumeLayout(false);
			this.renderGroupbox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.renderYNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.renderXNumeric)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.blockId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blockLayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.showBlock)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private EEWorldMap.EEMap eeMap1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox renderGroupbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown renderXNumeric;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown renderYNumeric;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown blockId;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.NumericUpDown blockLayer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.PictureBox showBlock;
	}
}

