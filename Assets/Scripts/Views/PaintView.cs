using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using Managers;

public class PaintView : View
{
	[Inject] public UIManager uIManager {get;set;}
	private Draw _curBrush;
	private Color _color;
	private Texture2D _texture;
	private Renderer _renderer;
	private Vector2 vect;
	private bool paint;
	private int _range;


	protected override void Awake()
	{
		SizeToScreen();
		_range = 1;
		_texture = new Texture2D(Screen.width / 2, Screen.height / 2);
		_renderer = GetComponent<Renderer>();
		_renderer.material.mainTexture = _texture;
		_color = Color.black;
		_curBrush = new CircleDraw();
		FillPaper(Color.white);
	}

	private void Update()
	{
		if (!uIManager.menuView.gameObject.activeInHierarchy &&
			!uIManager.startView.gameObject.activeInHierarchy)
			DrawTex();	
	}

	private void SizeToScreen()
	{
		Camera mainCamera;
		Vector3 bottomLeft;
		Vector3 topRight;
		mainCamera = Camera.main;
		bottomLeft = mainCamera.ScreenToWorldPoint(Vector2.zero);
		topRight = mainCamera.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));
		float height = topRight.y - bottomLeft.y;
		float width = topRight.x - bottomLeft.x;

		transform.localScale = new Vector3(width , height , 1f);		
	}

	private void DrawTex()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit))
			{
				Vector2 pixelUV = hit.textureCoord;
				Debug.Log(pixelUV);
				pixelUV.x *= _texture.width;
				pixelUV.y *= _texture.height;
				Debug.Log(pixelUV);
				Vector2 position = new Vector2 (pixelUV.x, pixelUV.y);
				if (paint == false)
					DrawLine(position, position);
				else
					DrawLine(vect, position);
				vect = position;
				_texture.Apply ();
			}
			paint = true;	
		}
		else
			paint = false;
	}

	private void DrawLine(Vector2 vec0, Vector2 vec1)
	{
		int dy = (int)(vec1.y-vec0.y);
		int dx = (int)(vec1.x-vec0.x);
		int stepx, stepy;
		float fraction = 0;
	
		if (dy < 0)
		{
			dy = -dy;
			stepy = -1;
		}
		else 
			stepy = 1;
		if (dx < 0)
		{
			dx = -dx;
			stepx = -1;
		}
		else
			stepx = 1;
		dy <<= 1;
		dx <<= 1;
		_curBrush.Figure(_texture,(int)vec0.x,(int)vec0.y, _range, _color);
		if (dx > dy)
		{
			fraction = dy - (dx >> 1);
			while (Mathf.Abs(vec0.x - vec1.x) > 1)
			{
				if (fraction >= 0)
				{
					vec0.y += stepy;
					fraction -= dx;
				}
				vec0.x += stepx;
				fraction += dy;
				_curBrush.Figure(_texture,(int)vec0.x,(int)vec0.y, _range, _color);
			}
		}
		else
		{
			fraction = dx - (dy >> 1);
			while (Mathf.Abs(vec0.y - vec1.y) > 1)
			{
				if (fraction >= 0)
				{
					vec0.x += stepx;
					fraction -= dy;
				}
				vec0.y += stepy;
				fraction += dx;
				_curBrush.Figure(_texture,(int)vec0.x,(int)vec0.y, _range, _color);
			}
		}
	}

	private IEnumerator SaveToPNG()
	{
		yield return new WaitForEndOfFrame();

		Texture2D image = _texture;
		image.Apply();
		byte[] bytes = image.EncodeToPNG();
		string filename = "Screenshot" + Random.value + ".png";
		NativeGallery.SaveImageToGallery(bytes, "LvivTest", filename);
	}

	public void Screenshot()
	{
		StartCoroutine(SaveToPNG());
	}

	public void FillPaper()
	{
		_curBrush.Figure(_texture, 0, 0, 1024, _color);
		_texture.Apply();
	}

	public void FillPaper(Color color)
	{
		_curBrush.Figure(_texture, 0, 0, 1024, color);
		_texture.Apply();
	}

	public void SetColor(Color newColor)
	{
		_color = newColor;
	}

	public void SetRange(int newRange)
	{
		_range = newRange;
	}

	public void SetBrush(Draw newBrash)
	{
		_curBrush = newBrash;
	}
}
