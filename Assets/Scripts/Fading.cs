﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
	public Texture2D fadeOutTexture; // the texture which you want to overlay to the screen
	public float fadeSpeed = 0.8f;
	private int drawDepth = -1000; // Low number will render on top
	private float alpha = 1.0f; // texture alpha value
	private int fadeDir = -1; // the direction to fade: in = -1 or out = 1
	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
	public float BeginFade(int direction)
	{
		alpha = 1;
		fadeDir = direction;
		return (fadeSpeed);
	}
}