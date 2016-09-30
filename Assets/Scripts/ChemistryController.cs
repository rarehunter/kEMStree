using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChemistryController : MonoBehaviour
{
	private Text congratsText;
	private Text hintText;
	private Text subscriptText;
	private Text goalText;
	private GameObject nextBuildButton;

	private string[] molecules_text;
	private string[] molecules_chem;

	private int current_level;
	private int max_level = 5; // Level 5 is the last level

	void Start ()
	{
		current_level = 1; // Start at Level 1

		// build arrays
		molecules_text = new string[] {"water", "carbon dioxide", "salt", "ozone", "bleach"};
		molecules_chem = new string[] {"H2O", "CO2", "NaCl", "O3", "NaOCl"};

		// get the text components
		congratsText = GameObject.Find("CongratsText").GetComponent<Text>();
		hintText = GameObject.Find("HintText").GetComponent<Text>();
		goalText = GameObject.Find("GoalText").GetComponent<Text>();
		nextBuildButton = GameObject.Find("NextButton");

		// hide stuff
		congratsText.enabled = false;
		hintText.enabled = false;
		nextBuildButton.SetActive(false);

		// show what molecule to build
		goalText.text = molecules_text[current_level-1];

	}


	void Update ()
	{

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
	}


}
