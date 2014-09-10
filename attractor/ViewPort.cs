/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 07.09.2014
 * Time: 0:13
 */
using System;

namespace attractor
{
	/// <summary>
	/// Description of ViewPort.
	/// </summary>
	public class ViewPort
	{
		public double ox, oy;
		public double sx, sy;
		private int width, height, stride;
		private int[] scr;
		
		public double xmin, ymin, xmax, ymax;
		

		public ViewPort()
		{
		}
		
		public void Setup(int width, int height, double size, int[] scr, int stride)
		{
			ox = size * 0.5f;
			oy = 0.5f * size * (double)height / (double)width;
			sx = (double)width / (size);
			sy = sx;
			this.width = width;
			this.height = height;
			this.scr = scr;
			this.stride = stride;
			
			xmin = -ox;
			xmax = ox;
			ymin = -oy;
			ymax = oy;
		}
		
		public void PixelSet(double x, double y, int color)
		{
			int px = (int)((x + ox) * sx);
			int py = (int)((y + oy) * sy);
			
			if (px >= 0 && px < width && py >= 0 && py < height)
			{
				scr[px + py * stride] = color;
			}
		}
	}
}
