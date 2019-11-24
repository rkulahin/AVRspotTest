using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareDraw : Draw
{
	public override void Figure(Texture2D texture, int cx, int cy, int range, Color color)
	{
		int px, nx, py;
		for(int x = 0; x <= range; x++)
		{
			for(int y = 0; y <= range; y++)
			{
				px = cx + x;
				nx = cx - x;
				py = cy + y;

				texture.SetPixel(px, py, color);
				texture.SetPixel(nx, py, color);
			}

		}
		Debug.Log("Draw Square");
	}
}
