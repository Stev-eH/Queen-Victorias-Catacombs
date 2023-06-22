using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Sprite up;
    public Sprite down;

    public bool isUp = true;

    private SpriteRenderer spR;
    private AudioSource click;

    public int internalId;
    private bool beingPressed = false;
    private bool pressable = false;

    // Start is called before the first frame update
    void Start()
    {
        spR= GetComponent<SpriteRenderer>();
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spR.sprite == up && !isUp)
        {
            spR.sprite= down;
            click.Play();
        }
        if(spR.sprite == down && isUp)
        {
            spR.sprite= up;
            click.Play();
        }

        if (Input.GetKeyDown(KeyCode.Return) && pressable)
        {
            beingPressed= true;
        }

        if (beingPressed)
        {
            isUp = !isUp;
            beingPressed = false;
        }


    }

    public bool getState()
    {
        return isUp;
    }

    public int getId()
    {
        return internalId;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pressable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        pressable= false;
    }
}
