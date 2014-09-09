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
		public float ox, oy;
		public float sx, sy;
		private int width, height, stride;
		private int[] scr;
		

		public ViewPort()
		{
		}
		
		public void Setup(int width, int height, float size, int[] scr, int stride)
		{
			ox = size * 0.5f;
			oy = 0.5f * size * (float)height / (float)width;
			sx = (float)width / (size);
			sy = sx;
			this.width = width;
			this.height = height;
			this.scr = scr;
			this.stride = stride;
		}
		
		public void PixelSet(float x, float y, int color)
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
