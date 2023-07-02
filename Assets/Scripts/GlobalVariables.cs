using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public bool tutorialShown = false;
    public bool key0Picked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleTutorial()
    {
        tutorialShown = true;
    }

    public void toggleKey(int keyId)
    {
        if(keyId== 0)
        {
            key0Picked= true;
        }
    }
}
