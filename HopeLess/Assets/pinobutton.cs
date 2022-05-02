using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pinobutton : MonoBehaviour
{
	[SerializeField]
	Text codeText;
	string codeTextValue = "";

	public AudioSource source;
	public AudioClip audio1, audio2;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update()
	{
		codeText.text = codeTextValue;

		if (codeTextValue == "131315247")
		{
			PlayerController.isSafeOpened = true;
		}

		if (codeTextValue.Length == 9)
			codeTextValue = "";
	}

	public void AddDigit(string digit)

	{
		source.PlayOneShot(audio1);
		codeTextValue += digit;
		
	}

	public void AddDigit2(string digit)
	{
		codeTextValue += digit;
		source.PlayOneShot(audio2);
	}
}
