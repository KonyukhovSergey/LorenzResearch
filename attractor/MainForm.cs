/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 06.09.2014
 * Time: 0:44
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace attractor
{
	public partial class MainForm : Form
	{
		private Bitmap bmp;
		private Graphics gr;
		private ViewPort vp = new ViewPort();
		
		private int[] scr;
		private int width, height;
		
		private Random rnd = new Random(Environment.TickCount);
		private volatile bool isWork = true;
		
		private GravityPoint[] points = new GravityPoint[2];
		
		public MainForm()
		{
			InitializeComponent();
			
			Task task = Task.Factory.StartNew(() =>
			{
				Thread.Sleep(200);
				
				while (isWork)
				{
					OnDraw();
					//Thread.Sleep(1000);
					frames++;
			
					if (Environment.TickCount - ticks > 1000)
					{
						UI(() =>
						{
							Text = "fps = " + frames.ToString();
						});
						ticks = Environment.TickCount;
						frames = 0;
					}
					
				}
			});
			
			Task screen = Task.Factory.StartNew(() =>
			{
				Thread.Sleep(100);
				while (isWork)
				{
					Invalidate();
					Thread.Sleep(16);
				}
			});
			
			Init();
		}
		
		private void Init()
		{
			for (int i = 0; i < points.Length; i++)
			{
				points[i] = new GravityPoint();
				points[i].Init((float)rnd.NextDouble() * 3 - 1, (float)rnd.NextDouble() * 3 - 1, 1, (float)rnd.NextDouble() * .02f - 0.01f, (float)rnd.NextDouble() * .02f - 0.01f);
			}
		}
		
		private void Tick(float dt)
		{
			
		}
		
		private void CalculateForces()
		{
			// zero forces
			for (int i = 0; i < points.Length; i++)
			{
				points[i].fx = 0;
				points[i].fy = 0;
			}
		
			for (int i = 0; i < points.Length - 1; i++)
			{
				GravityPoint gp1 = points[i];
								
				for (int j = i + 1; j < points.Length; j++)
				{
					// f = G * m1 * m2 / r ^ 2
					
					GravityPoint gp2 = points[j];

					float r = (float)Math.Sqrt((gp1.x - gp2.x) * (gp1.x - gp2.x) + (gp1.y - gp2.y) * (gp1.y - gp2.y));
					
					float fx = (gp2.x - gp1.x) / r;
					float fy = (gp2.y - gp1.y) / r;
					
					gp1.fx += fx;
					gp1.fy += fy;
					
					gp2.fx -= fx;
					gp2.fy -= fy;
				}
			}
		}
		
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			isWork = false;
			base.OnClosing(e);
		}
		
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
			base.OnKeyDown(e);
		}
		
		void UI(Action action)
		{ 
			Invoke(action);
		}
		
		private void OnDraw()
		{
			for (int i = 0; i < scr.Length; i++)
			{
				//scr[i] = (scr[i] & 0x00fefefe) >> 1;
				scr[i] = scr[i] > 0 ? scr[i] - 1 : 0;
			}
			
			vp.PixelSet(-1, -1, 0xffffff);
			vp.PixelSet(1, -1, 0xffffff);
			vp.PixelSet(1, 1, 0xffffff);
			vp.PixelSet(-1, 1, 0xffffff);
			
		}
		
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//base.OnPaintBackground(e);
		}
		
		private int frames = 0;
		private long ticks = Environment.TickCount;
		
		protected override void OnPaint(PaintEventArgs e)
		{
			if (scr == null)
			{
				width = ClientSize.Width;
				height = ClientSize.Height;
				bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
				gr = Graphics.FromImage(bmp);
				scr = new int[width * height];
				vp.Setup(width, height, 10, scr, width);
			}
			
			BitmapData bd = bmp.LockBits(ClientRectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			Marshal.Copy(scr, 0, bd.Scan0, scr.Length);
			bmp.UnlockBits(bd);
			
			e.Graphics.DrawImage(bmp, 0, 0);
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{
			scr = null;
			
			if (bmp != null)
			{
				gr.Dispose();
				bmp.Dispose();
				bmp = null;
				
			}
			base.OnSizeChanged(e);
		}
	}
	
	
}
