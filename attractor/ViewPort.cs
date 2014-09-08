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
		private int width, height;

		public ViewPort(int width, int height, float size)
		{
			ox = -size * 0.5f;
			oy = -0.5f * size * (float)height / (float)width;
			sx = (float)width / (size);
			sy = sx;
			this.width = width;
			this.height = height;
		}
		
		public int PixelIndex(float x, float y, int stride)
		{
			int px = (int)((x + ox) * sx);
			int py = (int)((y + oy) * sy);
			
			if (px >= 0 && px < width && py >= 0 && py < height)
			{
				return px + py * stride;
			}
			else
			{
				return 0;
			}
		}
	}
}
