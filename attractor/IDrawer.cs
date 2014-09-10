/*
 * Created by SharpDevelop.
 * User: serjik
 * Date: 10.09.2014
 * Time: 21:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace attractor
{
	/// <summary>
	/// Description of IDrawer.
	/// </summary>
	public interface IDrawer
	{
		void TickAndDraw(ViewPort vp);
	}
}
