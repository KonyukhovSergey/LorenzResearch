/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 10.09.2014
 * Time: 21:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace attractor
{
	/// <summary>
	/// Description of Tractor.
	/// </summary>
	public class Tractor:IDrawer
	{
		double x = 3.051522, y = 1.582542, z = 15.62388, x1, y1, z1;
		const double dt = 0.01;
		
		double t = 0;
    
		public double _a = 5, _b = 15, _c = 1;
		
		private MouseControl mc;
		
		public Tractor(MouseControl mc)
		{
			this.mc = mc;
		}
		
		public void TickAndDraw(ViewPort vp)
		{
			t += dt;
			double a = _a + mc.dx;
			double b = _b + mc.dy;
			double c = _c;
			for (int i = 0; i < 5000; i++)
			{
				x1 = x + a * (-x + y) * dt;
				y1 = y + (b * x - y - z * x) * dt;
				z1 = z + (-c * z + x * y) * dt;
				x = x1;
				y = y1;
				z = z1;
				
				vp.PixelSet(y - x * 0.292893, 0.5*z + x * 0.292893-8, 255);
			}
		}
	}
}
