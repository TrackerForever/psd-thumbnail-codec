using System;
/* *************************************************
 * Development / Enhancements Programmer: Rajesh Lal(connectrajesh@hotmail.com)
 * Date: 03/29/2007
 * Company Info: www.csharptricks.com
 * See EULA.txt and Copyright.txt for additional information
 * **************************************************/

namespace CSharpTricks.Photoshop
{
	/// <summary>
	/// ColorModeData class
	/// </summary>
	public class ColorModeData
	{
		public int nLength;
		public byte[] ColourData;

		public ColorModeData()
		{
			nLength = -1;
		}
	}
}
