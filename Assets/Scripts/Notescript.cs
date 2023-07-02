using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notescript : MonoBehaviour
{
    [TextArea(0, 10)]
    public string textToDisplay;

    private bool isInteractable;
    private bool hasInstantiated;

    [SerializeField]
    private GameObject canvas;

    private GameObject instantiated;

    void Start()
    {
        isInteractable = false;
        hasInstantiated= false;
        canvas.GetComponentInChildren<Text>().text = textToDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.Return ))
        {
            if (!hasInstantiated)
            {
                Debug.Log("Interacted");
                instantiated = Instantiate(canvas);
                hasInstantiated = true;
            }
            else
            {
                Destroy(instantiated);
                hasInstantiated = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInteractable = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isInteractable = false;
        if(hasInstantiated)
            Destroy(instantiated);
        hasInstantiated = false;
    }
}
