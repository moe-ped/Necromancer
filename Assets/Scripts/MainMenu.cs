using UnityEngine;
using System.Collections;
// ahaaa!
using UnityEngine.UI;

public class MainMenu : MonoBehaviour, ICustomMessageTarget 
{

	public string[] phrases;

	public Text subtitle;

	// Use this for initialization
	void Start () 
	{
		// test
		selectSubtitle ();
	}

	public void OnStartGame () 
	{
		// test
		Application.LoadLevel (Application.loadedLevel+1);
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
			subtitle.text = "Memoirs of " + phrases[phrase1] + " and " + phrases[phrase2];
		}
	}
}
