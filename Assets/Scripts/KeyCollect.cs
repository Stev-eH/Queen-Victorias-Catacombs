using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    private bool direction;
    private float changeTime;

    public int keyId;

    [SerializeField]
    private float changeTimer;

    private Transform keyPos;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Logic").GetComponent<GlobalVariables>().key0Picked)
        {
            Destroy(this.gameObject);
        }
        direction= true;
        changeTime = 1f;
        changeTimer = changeTime;

        keyPos = this.transform;
        keyPos.position += new Vector3(0f, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;

        if(direction)
        {
            keyPos.position -= new Vector3(0f, 0.2f * Time.deltaTime, 0f);
        }
        else
        {
            keyPos.position += new Vector3(0f, 0.2f * Time.deltaTime, 0f);
        }

        if(changeTime <= 0)
        {
            direction = !direction;
            changeTime = changeTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            GameObject.FindGameObjectWithTag("Logic").GetComponent<KeyMechanics>().GetKey();
            GameObject.FindGameObjectWithTag("Logic").GetComponent<GlobalVariables>().toggleKey(keyId);
            this.GetComponentInParent<AudioSource>().Play();
            Destroy(this.gameObject);

        }
    }
}
