using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleDraw : Draw
{
	public override void Figure(Texture2D texture, int cx, int cy, int range, Color color)
	{
		int d, ny, nx, py, px;

		d = range;
		for(int x = 0; x <= range; x++)
		{
			for(int y = 0; y < d; y++)
			{
				nx = cx + x;
				ny = cy + y;
				px = cx - x;
				py = cy + y;
				texture.SetPixel(nx,ny,color);
				texture.SetPixel(px,py,color);
			}
			d -= 1;
		}
		Debug.Log("Draw Triangle");
	}
}
