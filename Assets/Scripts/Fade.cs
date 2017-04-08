using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	Animator anim;
	bool isFading = false;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	void AnimationComplete() 
	{
		isFading = false;
	}

	public IEnumerator FadeToClear(){
		isFading = true;
		anim.SetTrigger ("FadeIn");

		while (isFading) 
		{
			yield return null;
		}
	}

	public IEnumerator FadeToBlack() {
		isFading = true;
		anim.SetTrigger ("FadeOut");

		while (isFading) 
		{
			yield return null;
		}
	}

}
