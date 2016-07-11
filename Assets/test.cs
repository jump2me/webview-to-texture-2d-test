using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class test : MonoBehaviour {

	public RectTransform box;
	public Canvas canvas;
	public CanvasScaler canvasScaler;

	public WebViewObject google;

	void Awake()
	{
		google.Init (e => Debug.Log (e));

		var scale = Screen.width / canvasScaler.referenceResolution.x;
	
		var width = box.rect.width * scale;
		var height = box.rect.height * scale;

		var xSign = box.localPosition.x >= 0;
		var ySign = box.localPosition.y >= 0;

		var x = Mathf.Abs(box.localPosition.x * scale);
		var y = Mathf.Abs(box.localPosition.y * scale);

		var left = (int)((Screen.width - (x + width / 2f)) - Screen.width / 2f);
		var right = (int)((Screen.width - left) - width);

		var top = (int)((Screen.height - (y + height / 2f)) - Screen.height / 2f);
		var bottom = (int)((Screen.height - top) - height);

		google.SetMargins (xSign ? right : left, ySign ? top : bottom, xSign ? left : right, ySign ? bottom : top);
		google.LoadURL ("http://www.google.com");
		google.SetVisibility (true);
	}

	void OpenWebView (CanvasScaler canvasScaler, RectTransform guide, string url)
	{

	}

	public Image img;
	void Update()
	{
		if (google == null)
			return;

		var texture = google.Texture;
		if (texture == null)
			return;

		var sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero, 1f);

		img.sprite = sprite;
		img.transform.localScale = new Vector3 (1, -1);
	}
}
