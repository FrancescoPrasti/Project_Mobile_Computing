using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
	private RectTransform rectTransform;
	Rect safeArea;
	Vector2 minAnchor;
	Vector2 maxAnchor;

	void Awake()
	{
        rectTransform = GetComponent<RectTransform>();
		safeArea = Screen.safeArea;
		minAnchor = safeArea.position;
		maxAnchor = minAnchor + safeArea.size;
		//normalizzare le coordinate
		minAnchor.x /= Screen.width;
		minAnchor.y /= Screen.height;
		maxAnchor.x /= Screen.width;
		maxAnchor.y /= Screen.height;

		rectTransform.anchorMin = minAnchor;
		rectTransform.anchorMax = maxAnchor;
	}
}

        