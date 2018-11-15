using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasManager : MonoBehaviour
{
    public Text WarningText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarningMessage(string _text)
    {
        WarningText.GetComponent<TextTimeNonActive>().ActivateText(_text);
    }
}
