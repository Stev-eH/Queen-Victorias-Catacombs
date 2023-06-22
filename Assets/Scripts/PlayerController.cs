using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RoomTransition;

namespace Minifantasy
{
    public class PlayerController : MonoBehaviour
    {
        private Animator animator;

        public string parameterName = "Idle";
        public float x = 1;
        public float y = 1;
        public float waitTime = 0f;

        public float speed = 3;
        private GameObject logic;
        private entry roomSpawn;

        private AudioSource footsteps;

        [SerializeField]
        private GameObject exclamation;

        private GameObject instantiated;

        private void Start()
        {
            logic = GameObject.FindGameObjectWithTag("Logic");
            footsteps = this.GetComponent<AudioSource>();
            roomSpawn = logic.GetComponent<RoomTransition>().GetComponent<RoomTransition>().passTransition();
            if(roomSpawn == entry.Up)
            {
                transform.position = GameObject.Find("SpawnerN").transform.position;
            }
            else if(roomSpawn == entry.Down)
            {
                transform.position = GameObject.Find("SpawnerS").transform.position;
            }
            else if(roomSpawn == entry.Left)
            {
                transform.position = GameObject.Find("SpawnerW").transform.position;
            }
            else if(roomSpawn == entry.Right)
            {
                transform.position = GameObject.Find("SpawnerE").transform.position;
            }

            animator = GetComponentInChildren<Animator>();
            ToggleAnimation("Idle");
            ToggleDirection();
        }

         void Update()
        {
            if(Input.GetKey(KeyCode.W))
            {
                this.transform.position += Vector3.up * Time.deltaTime * speed;
                ToggleAnimation("Walk");
                if(!footsteps.isPlaying)
                    footsteps.Play();
                y = 1;
                ToggleDirection();
                
            }
            if(Input.GetKey(KeyCode.S))
            {
                this.transform.position += Vector3.down * Time.deltaTime * speed;
                ToggleAnimation("Walk");
                if (!footsteps.isPlaying)
                    footsteps.Play();
                y = -1;
                ToggleDirection();
            }
            if(Input.GetKey(KeyCode.A))
            {
                this.transform.position += Vector3.left * Time.deltaTime * speed;
                ToggleAnimation("Walk");
                if (!footsteps.isPlaying)
                    footsteps.Play();
                x = -1;
                ToggleDirection();
            }
            if(Input.GetKey(KeyCode.D))
            {
                this.transform.position += Vector3.right * Time.deltaTime * speed;
                ToggleAnimation("Walk");
                if (!footsteps.isPlaying)
                    footsteps.Play();
                x = 1;
                ToggleDirection();
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
                ToggleAnimation("Idle");

        }

        public void ToggleAnimation(string nextParameter)
        {
            animator.SetBool(parameterName, false);
            animator.SetBool(nextParameter, true);
            parameterName = nextParameter;
            ToggleDirection();
        }
        public void ToggleDirection()
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Interactable"))
                instantiated = Instantiate(exclamation, this.transform.position + Vector3.up, this.transform.rotation);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Interactable"))
                Destroy(instantiated);
        }
    }
}