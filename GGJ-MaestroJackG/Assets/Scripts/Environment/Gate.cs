using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour {

    public int collectibleRequirement;
    public Text requirementDisplay;

	void Start () {
        requirementDisplay.text = string.Format("X "+ collectibleRequirement);
	}
		
	void Update () {
		
	}
}
