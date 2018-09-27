using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchParameterTest : MonoBehaviour {
    public Text dataDump;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        if (dataDump != null)
        {
            dataDump.text = "Hello Branch";
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
