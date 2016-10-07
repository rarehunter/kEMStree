using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ChemistryController : MonoBehaviour
{
	private Text congratsText;
	private Text hintText;
	private Text subscriptText;
	private Text goalText;
	private GameObject returnButton;

	private string[] molecules_text;
	private string[] molecules_chem;

	private int current_level;
	public static int success; // set by 'CheckSolution' if the molecule is successfully constructed

	void Start ()
	{
		current_level = 1; // Start at Level 1
		success = 0;

		// Play background music
		GetComponent<AudioSource>().Play();


		// build arrays
		molecules_text = new string[] {"water", "carbon dioxide", "salt", "ozone", "bleach"};
		molecules_chem = new string[] {"H2O", "CO2", "NaCl", "O3", "NaOCl"};

		// get the text components
		congratsText = GameObject.Find("CongratsText").GetComponent<Text>();
		hintText = GameObject.Find("HintText").GetComponent<Text>();
		goalText = GameObject.Find("GoalText").GetComponent<Text>();
		returnButton = GameObject.Find("ReturnButton");

		// hide stuff
		congratsText.enabled = false;
		hintText.enabled = false;
		returnButton.SetActive(false);

		// show what molecule to build
		goalText.text = molecules_text[current_level-1];

	}


	void Update ()
	{
		// If the CheckSolutionHelper function sets the 'success' variable,
		// then show the "Success" message and return button.
		if(Convert.ToBoolean(success))
		{
			congratsText.enabled = true;
			returnButton.SetActive(true);
		}
	}

	public void HintButtonClick()
	{
		// show the hint text
		hintText.enabled = true;
		hintText.text = molecules_chem[current_level-1];

		// make button un-clickable now
		GameObject.Find("HintButton").GetComponent<Button>().interactable = false;
	}

	public void CheckSolution()
	{
		Debug.Log("Checking solution...");

		success = CheckSolutionHelper();
	}

	public int CheckSolutionHelper()
	{
		GameObject go;
		if(current_level == 1) // Checking solution for H2O level
		{
			// Make sure that oxygen exists and that it has two hydrogen children
			if((go = GameObject.Find("OxygenPrefab(Clone)")) != null && go.transform.childCount == 2)
			{
				foreach (Transform child in go.transform)
				{
					if(child.gameObject.name != "HydrogenPrefab(Clone)")
						return 0; //if child is not just hydrogen, fail
				}
				return 1; //otherwise, success
			}
			else // if oxygen doesn't exist or it doesn't have exactly two children, fail
			{
				return 0;
			}
		}
		else // add more levels here
		{
			return 0;
		}
	}


}
