using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BranchUnityTest : MonoBehaviour {
    public Text dataDump;
    public Text urlDump;

    void Start()
    {
        Branch.initSession(CallbackWithBranchUniversalObject);
    }

    void CallbackWithBranchUniversalObject(BranchUniversalObject buo,
                                            BranchLinkProperties linkProps,
                                            string error)
    {
        if (error != null)
        {
            System.Console.WriteLine("Error : "
                                    + error);
        }
        else if (linkProps.controlParams.Count > 0)
        {
            System.Console.WriteLine("Deeplink params : "
                                    + buo.ToJsonString()
                                    + linkProps.ToJsonString());
            dataDump.text = "Deeplink params : "
                                    + buo.ToJsonString()
                                    + linkProps.ToJsonString();
        }
    }

    private void Awake()
    {
        BranchLinkProperties linkProperties = new BranchLinkProperties();
        linkProperties.alias = "UnityAndroidAddTest" + System.DateTime.Now;
        linkProperties.tags.Add("VlaFlip" + System.DateTime.Now);
        linkProperties.controlParams.Add("PostMoment", System.DateTime.Now.ToString());
        // Feature link is associated with. Eg. Sharing
        linkProperties.feature = "Boodschappen";
        // The channel where you plan on sharing the link Eg.Facebook, Twitter, SMS etc
        linkProperties.channel = "Twitter";
        linkProperties.stage = "1";
        // Parameters used to control Link behavior
        linkProperties.controlParams.Add("$desktop_url", "http://roxelane.nl/portfolio-items/a2-racer/?portfolioCats=162");

        var universalObject = new BranchUniversalObject();
        
        

        Branch.getShortURL(universalObject, linkProperties, (p, error) => {
            if (error != null)
            {
                Debug.LogError("Branch.getShortURL failed: " + error);
                urlDump.text = "Branch.getShortURL failed: " + error;
            }
            else if (p != null) {
                Debug.Log("Branch.getShortURL shared params: " + p);
                urlDump.text = "Branch.getShortURL shared params: " + p;
            }
        });
    }

    // Update is called once per frame
    void Update () {
		
	}
}
