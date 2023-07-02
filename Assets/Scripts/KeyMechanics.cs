using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyMechanics : MonoBehaviour
{
    public int numKeys;
    private Text keyText;


    public void Start()
    {
        numKeys= 0;
        keyText = GameObject.Find("Keytext").GetComponent<Text>();
    }

    public void Update()
    {
        
    }
    public void GetKey()
    {
        keyText = GameObject.Find("Keytext").GetComponent<Text>();
        numKeys++;
        keyText.text = "x " + numKeys.ToString();
    }

    public bool UseKey()
    {
        if(numKeys > 0)
        {
            keyText = GameObject.Find("Keytext").GetComponent<Text>();
            numKeys--;
            keyText.text = "x " + numKeys.ToString();
            return true;
        }

        return false;
    }
}
