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
		public float x, y, vx, vy, m,fx=0,fy=0;
	
		public GravityPoint()
		{
		}
		
		public void Init(float x, float y, float m, float vx, float vy)
		{
			this.x = x;
			this.y = y;
			this.m = m;
			this.vx = vx;
			this.vy = vy;		
		}
	}
}
