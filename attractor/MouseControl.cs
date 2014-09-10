/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 10.09.2014
 * Time: 22:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace attractor
{
	/// <summary>
	/// Description of MouseControl.
	/// </summary>
	public class MouseControl
	{
		private int sx, sy;
		public double dx = 0, dy = 0;
		private double tdx, tdy;
		private bool isPressed = false;
		
		public void OnDown(int x, int y)
		{
			sx = x;
			sy = y;
			tdx = dx;
			tdy = dy;
			isPressed = true;
		}
		
		public void OnMove(int x, int y)
		{
			if (isPressed)
			{
				dx = tdx + 0.01 * (x - sx);
				dy = tdy + 0.01 * (y - sy);
			}
		}
		
		public void OnUp(int x, int y)
		{
			if (isPressed)
			{
				dx = tdx + 0.01 * (x - sx);
				dy = tdy + 0.01 * (y - sy);
				isPressed = false;
			}
		}
		
		
		
	}
}
