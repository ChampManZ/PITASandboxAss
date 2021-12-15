using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playercontrol : MonoBehaviour
{
    public int health = 30;
    public int endphase = 0;
    public int mon_count =0;
    public float spawn_timer = 0;
    public int phase = 0;
    public int mon_left = 0;
    public int fence_one = 0;
    public int fence_two = 0;
    //public GameObject mysocket;
    // Start is called before the first frame update
    void Start()
    {
        spawn_timer = UnityEngine.Random.Range(2,5);
        //mysocket = GameObject.Find("Socket");
        
    }

    // phase: 0 start, 1 talked1, 2 place1, 3 fight1, 4 endfight1, 5 talked2, 6 place2, 7 fight2, 8 endfight2

    // Update is called once per frame
    void Update()
    {
        //XRSocketInteractor socket = mysocket.GetComponent<XRSocketInteractor>();
        //IXRSelectInteractable placed = socket.GetOldestInteractableSelected();
        //Debug.Log(placed.transform.name + " placed..");

        // phase: 0 start, 1 talked1, 2 place1, 3 fight1, 4 endfight1, 5 talked2, 6 place2, 7 fight2, 8 endfight2
        if (phase == 0){
            //0 (set text with textmesh pro in canvas)
        }else if (phase == 1){
            //1
        }else if (phase == 2){
            //2
        }else if (phase ==3){
            //3
        }else if (phase == 4){
            //4
        }else if (phase == 5){
            //5
        }else if (phase ==6){
            //6
        }else if (phase == 7){
            //7
        }



        Debug.Log(phase);

        //Debug.Log(health);
        if (health <= 0){
            //Debug.Log("lost");
        }
        if (phase == 2){
            phase += 1;
            mon_left = 10;
            fence_one = 1;
        }
        if (phase == 6){
            phase += 1;
            mon_left = 10;
            fence_two = 1;
        }


        if(mon_left > 0 && spawn_timer > 0){
            spawn_timer -= Time.deltaTime;
        }
        if(mon_left > 0 && spawn_timer <= 0){
            mon_left -= 1;
            spawn_timer = UnityEngine.Random.Range(2,5);
            //Debug.Log("spawn here");


        }


        if(mon_count == 10){
            endphase = 1;
            mon_count = 0;
        }




        if (endphase == 1){
            health = 30;
            phase += 1;
            endphase = 0;
            if (fence_one == 2){
                fence_two = 2;
            }else{
                fence_one = 2;
            }
        }
        
    }
}
