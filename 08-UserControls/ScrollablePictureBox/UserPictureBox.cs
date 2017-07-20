using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace PictureBoxControl
{
	/// <summary>
	/// Summary description for UserPictureBox.
	/// </summary>
	/// 

	public class UserPictureBox : System.Windows.Forms.UserControl
	{
		private string TheBitmap = "";
		private int iOffsetX = 0;

		
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UserPictureBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(0, 128);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(136, 16);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(136, 8);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(16, 112);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // UserPictureBox
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.vScrollBar1,
                                                                          this.hScrollBar1});
            this.Name = "UserPictureBox";
            this.SizeChanged += new System.EventHandler(this.UserPictureBox_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserPictureBox_Paint);
            this.ResumeLayout(false);

        }
		#endregion

        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar1;

        private Image TheImage = null;

        private void UserPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White,this.ClientRectangle);
            if (TheImage != null)
            {
                g.DrawImageUnscaled(TheImage, -OffsetX, -OffsetY, TheImage.Width, TheImage.Height);
                g.FillRectangle(Brushes.Gray, ClientRectangle.Width - vScrollBar1.Width, ClientRectangle.Height - hScrollBar1.Height, vScrollBar1.Width, hScrollBar1.Height);
            }
        }
    
        public Image Image
        {
            get 
            {
                return TheImage;
            }
            set
            {
                TheImage = value;
                SizeScrollBars();
            }
        }



       public int OffsetX
        {
            get
            {
                return iOffsetX;
            }
            set
            {
              iOffsetX = value;
              Invalidate();
            }
        }

        private int iOffsetY = 0;

        private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            int nVal = e.NewValue ;
            OffsetX = nVal;

        }

        private void vScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            int nVal = e.NewValue ;
            OffsetY = nVal;
        }

        private void SizeScrollBars()
        {
            hScrollBar1.Minimum = 0;
            vScrollBar1.Minimum = 0;
            hScrollBar1.SetBounds(0, ClientRectangle.Height - hScrollBar1.Height, ClientRectangle.Width - vScrollBar1.Width, hScrollBar1.Height);
            vScrollBar1.SetBounds(ClientRectangle.Right - vScrollBar1.Width, 0, vScrollBar1.Width, ClientRectangle.Height - hScrollBar1.Height);  

            if (TheImage != null)
            {
                hScrollBar1.Maximum = TheImage.Width + vScrollBar1.Width/2 - ClientRectangle.Width;
                vScrollBar1.Maximum = TheImage.Height + hScrollBar1.Height/2 - ClientRectangle.Height;
            }
            else
            {
                hScrollBar1.Maximum =  10;
                vScrollBar1.Maximum = 10;
            }

            Invalidate();
        }

        private void UserPictureBox_SizeChanged(object sender, System.EventArgs e)
        {
            SizeScrollBars();
        }
    
        public int OffsetY
        {
            get
            {
                return iOffsetY;
            }
            set
            {
                iOffsetY = value;
                Invalidate();
            }
        }


	}


}
