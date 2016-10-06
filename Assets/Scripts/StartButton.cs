using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{
	private Text title;
    private Button button;
    private Image image;
    private Text starttext;
    private GameObject elem;
    // private GameObject addButtons;

	// Use this for initialization
	void Start ()
	{
        elem = GameObject.Find("Elements");
        elem.SetActive(false);
	}

	// Update is called once per frame
	void Update ()
	{
	}

    public void Clicked()
    {
        title = GameObject.Find("Title").GetComponent<Text>();
        button = GameObject.Find("StartButton").GetComponent<Button>();
        image = GameObject.Find("StartButton").GetComponent<Image>();
        starttext = GameObject.Find("StartText").GetComponent<Text>();

        title.enabled = false;
        button.enabled = false;
        image.enabled = false;
        starttext.enabled = false;

        elem.SetActive(true);
    }
}
