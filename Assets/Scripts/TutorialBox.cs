using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Logic").GetComponent<GlobalVariables>().tutorialShown)
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            GameObject.FindGameObjectWithTag("Logic").GetComponent<GlobalVariables>().toggleTutorial();
            Destroy(this.gameObject);
        }
    }
}
