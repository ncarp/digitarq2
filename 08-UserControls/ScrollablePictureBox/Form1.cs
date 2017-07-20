using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ScrollablePictureBox
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private PictureBoxControl.UserPictureBox userPictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
            this.userPictureBox1 = new PictureBoxControl.UserPictureBox();
            this.SuspendLayout();
            // 
            // userPictureBox1
            // 
            this.userPictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("userPictureBox1.Image")));
            this.userPictureBox1.Location = new System.Drawing.Point(48, 48);
            this.userPictureBox1.Name = "userPictureBox1";
            this.userPictureBox1.OffsetX = 0;
            this.userPictureBox1.OffsetY = 0;
            this.userPictureBox1.Size = new System.Drawing.Size(312, 248);
            this.userPictureBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(400, 317);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.userPictureBox1});
            this.Name = "Form1";
            this.Text = "Scrollable Picture Box";
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
