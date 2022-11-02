using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum states
    {
        IdleState,
        BlockState
    }

    public class Statez : MonoBehaviour
    {


        states states = states.IdleState;
        public HealthScript health;
        private Animator anim;
        public BeatManager bm;
        public int StateChangeAmount = 5;
        public int currentAmount = 0;
        //currentAmount keeps track of the amount of beats that have happened and StateChangeAmount is a set value that gets used later to indicate when the state should change
        // Start is called before the first frame update
        void Start()
        {
            FindObjectOfType<BeatManager>().BeatHappened.AddListener(OnBeat);
            //This makes it so that the void OnBeat can notice when it needs to switch states
        }

        // Update is called once per frame
        void Update()
        {
            switch (states)
            {
                case states.IdleState:
                    //anim = gameObject.GetComponent<Animator>();
                    //anim.Play("idle");
                    health.Damage = 10f;
                    if (bm.Hit == true)
                    {
                       // anim = gameObject.GetComponent<Animator>();
                        //anim.Play("hit");
                        bm.Hit = false;
                    }

                    //This is supposed to play the idle animation
                    //all of your code here

                    break;
                case states.BlockState:
                    {
                        //anim = gameObject.GetComponent<Animator>();
                        //anim.Play("block");
                        //if damage stays 0 revert damage back to original damage.
                        health.Damage = 0f;
                        //plays the block animation
                        if (bm.Hit == true)
                        {
                            //anim = gameObject.GetComponent<Animator>();
                            //anim.Play("blockhit");
                            bm.Hit = false;

                        }
                    }
                    break;
            }
        }

        void OnBeat()
        {
            currentAmount++;
            if(currentAmount > StateChangeAmount)
            //If current amount reaches the beat amount of StateChangeAmount it tells it to change state and reset the value of currentAmount
            {
                if (states == states.IdleState)
                {
                    states = states.BlockState;
                }
                else
                {
                    states = states.IdleState;
                }
                currentAmount = 0;
            }
            Debug.Log("Beat happened" + health.Damage);
        }


    }
}