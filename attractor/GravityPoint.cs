/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 09.09.2014
 * Time: 21:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace attractor
{
	/// <summary>
	/// Description of GravityPoint.
	/// </summary>
	public class GravityPoint
	{
		public double x, y, vx, vy, m, fx = 0, fy = 0;
	
		public GravityPoint()
		{
		}
		
		public void Init(double x, double y, double m, double vx, double vy)
		{
			this.x = x;
			this.y = y;
			this.m = m;
			this.vx = vx;
			this.vy = vy;		
		}
		
		public void Tick(double dt, ViewPort vp)
		{
			if (x + vx * dt <= vp.xmin || x + vx * dt >= vp.xmax)
			{
				vx = -vx;
			}
			
			if (y + vy * dt <= vp.ymin || y + vy * dt >= vp.ymax)
			{
				vy = -vy;
			}
			
			x += vx * dt;
			y += vy * dt;
			
			vx += fx * dt / m;
			vy += fy * dt / m;
			
			vx *= 0.999995;
			vy *= 0.999995;
		}
	}
}
