using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeydoorScript : MonoBehaviour
{
    public int roomNumber;

    private bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        canInteract= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                UseKey();
            }
        }

        if(GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().getKeyStatus(roomNumber))
        {
            Destroy(this.gameObject);
        }
    }

    public void UseKey()
    {
        if(GameObject.FindGameObjectWithTag("Logic").GetComponent<KeyMechanics>().UseKey()) 
        {
            GameObject.FindGameObjectWithTag("Logic").GetComponent<SolvedPuzzles>().solveRoomKey(roomNumber);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
            canInteract= true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            canInteract = false;
    }
}
