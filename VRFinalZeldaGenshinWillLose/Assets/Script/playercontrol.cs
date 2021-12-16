using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class playercontrol : MonoBehaviour
{
    public int health = 30;
    public TMPro.TextMeshProUGUI objective;
    public TMPro.TextMeshProUGUI hp;
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
        //hello;
        //to commit
        
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
            objective.text = "Objective: Talk to the villager at the village";
        }else if (phase == 1){
            objective.text = "Objective: Bring the sceptor of icarus to the abandoned horse statue";
        }else if (phase == 2){
            objective.text = "Objective: Eliminiate the minions";
        }else if (phase ==3){
           //
        }else if (phase == 4){
            objective.text = "Objective: Go back to the villagers";
        }else if (phase == 5){
             objective.text = "Objective: Bring the staff to the Greek statue";
        }else if (phase ==6){
            objective.text = "Objective: Eliminate the minions";
        }else if (phase == 7){
            //
        }else if (phase ==8){
            objective.text = "After all the fights that Pun been through...HE WIN ! ";
        }

        hp.text = "Pun the fighter: "+health.ToString() + " hp";

        //Debug.Log(phase);
        
        //Debug.Log(health);
        if (health <= 0){
            //Debug.Log("lost");
            hp.text = "0 hp";
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
