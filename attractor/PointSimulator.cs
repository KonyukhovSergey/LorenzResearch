/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 10.09.2014
 * Time: 21:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace attractor
{
	/// <summary>
	/// Description of PointSimulator.
	/// </summary>
	public class PointSimulator:IDrawer
	{
		private Random rnd = new Random(Environment.TickCount);
		private GravityPoint[] points = new GravityPoint[10];
		private double dt = 0.001;
		
		public PointSimulator()
		{
			Init();
		}

		private void Init()
		{
			for (int i = 0; i < points.Length; i++)
			{
				points[i] = new GravityPoint();
				points[i].Init(rnd.NextDouble() * 3 - 1, rnd.NextDouble() * 3 - 1, rnd.NextDouble() * 3 + 1, rnd.NextDouble() * .2f - 0.1f, rnd.NextDouble() * .2f - 0.1f);
				//points[i].Init((double)rnd.NextDouble() * 4 - 2, (double)rnd.NextDouble() * 4 - 2, 1, 0, 0);
			}			
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

					double r = Math.Sqrt((gp1.x - gp2.x) * (gp1.x - gp2.x) + (gp1.y - gp2.y) * (gp1.y - gp2.y));
					
					double fx = (gp2.x - gp1.x) / r;
					double fy = (gp2.y - gp1.y) / r;
					
					gp1.fx += fx * gp2.m;
					gp1.fy += fy * gp2.m;
					
					gp2.fx -= fx * gp1.m;
					gp2.fy -= fy * gp1.m;
				}
			}
		}
		
		#region IDrawer implementation

		public void TickAndDraw(ViewPort vp)
		{
			for (int j = 0; j < 500; j++)
			{
				CalculateForces();
				for (int i = 0; i < points.Length; i++)
				{
					points[i].Tick(dt, vp);
					vp.PixelSet(points[i].x, points[i].y, 0xff);
				}
			}
		}

		#endregion
	}
}
