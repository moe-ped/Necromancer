using UnityEngine;
using System.Collections;
// ahaaa!
using UnityEngine.UI;

public class SubtitleSelector : MonoBehaviour, ICustomMessageTarget 
{

	public string[] phrases;

	// Use this for initialization
	void Start () 
	{
		selectSubtitle ();
	}

	public void OnStartGame () 
	{
		// test
		selectSubtitle ();
	}

	void selectSubtitle ()
	{
		// randomly pick 2 different phrases
		if (phrases.Length >= 2)
		{
			int phrase1 = Random.Range (0, phrases.Length);
			int phrase2 = phrase1;
			while (phrase2 == phrase1) {
				phrase2 = Random.Range (0, phrases.Length);
			}
			Text textComponent = GetComponent<Text>();
			textComponent.text = "Memoirs of " + phrases[phrase1] + " and " + phrases[phrase2];
		}
	}
}
