using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDraw : Draw
{
	public override void Figure(Texture2D texture, int cx, int cy, int range, Color color)
	{
		int px, nx, py, ny, d;

		for (int x = 0; x <= range; x++)
		{
			d = (int)Mathf.Ceil(Mathf.Sqrt(range * range - x * x));
			for (int y = 0; y <= d; y++)
			{
				px = cx + x;
				nx = cx - x;
				py = cy + y;
				ny = cy - y;

				texture.SetPixel(px, py, color);
				texture.SetPixel(nx, py, color);
				texture.SetPixel(px, ny, color);
				texture.SetPixel(nx, ny, color);
			}
		} 
		Debug.Log("Draw Circle");
	}
}
