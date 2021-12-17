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
    public GameObject mon_prefab;
    float[] xm1 = new float[8]{258.03332f,339.921f, 349.547f, 268.0177f, 268.1826f, 310.5743f, 343.926f, 312.0763f};
    float[] ym1 = new float[8]{26.9236f, 22.20671f, 25.06455f, 23.16452f, 23.99924f, 23.74437f, 21.5595f, 25.07163f};
    float[] zm1 = new float[8]{103.4496f, 110.0378f, 50.87915f, 52.61578f, 76.84064f, 108.9281f, 81.35338f, 50.7186f};
    //public GameObject mysocket;
    // Start is called before the first frame update
    void Start()
    {
        spawn_timer = UnityEngine.Random.Range(2,5);
        
        // float xm1[8] = {258.03332f,339.921f, 349.547f, 268.0177f, 268.1826f, 310.5743f, 343.926f, 312.0763f};
        // float ym1[8] = {26.9236f, 22.20671f, 25.06455f, 23.16452f, 23.99924f, 23.74437f, 21.5595f, 25.07163f};
        // float zm1[8] = {103.4496f, 110.0378f, 50.87915f, 52.61578f, 76.84064f, 108.9281f, 81.35338f, 50.7186f};


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
            // to vi
        }else if (phase == 1){
            objective.text = "Objective: Bring the scepter of Icarus to the abandoned horse statue";
            // to horse from vil
        }else if (phase == 2){
            objective.text = "Objective: Eliminiate the minions";
            // place1 from printer
        }else if (phase ==3){
           //
        }else if (phase == 4){
            objective.text = "Objective: Go back to champ";
        }else if (phase == 5){
             objective.text = "Objective: Bring the staff to the Greek statue";
        }else if (phase ==6){
            objective.text = "Objective: Eliminate the minions";
        }else if (phase == 7){
            //
        }else if (phase ==8){
            //objective.text = "After all the fights that Pun been through...HE WIN ! ";
            objective.text = "Objective: Get back to champ";
        }else if(phase == 9){
            //objective.text = "Objective: Find the magical removal stone in the deep forest and bring back to the champ";
            objective.text = "Objective: Find the magical removal stone in the deep forest and bring back to champ";
        }else if(phase == 10){
            //objective.text = "Objective: Take the gem to the rock of freedom and go home";
            objective.text = "Objective: Take the gem to ignite the rock of freedom and go home";
        }else if(phase == 11){
            //send home
        }


        hp.text = "Pun The Fighter: "+health.ToString() + " HP";

        Debug.Log("phase: " + phase.ToString());
        
        //Debug.Log(health);
        if (health <= 0){
            //Debug.Log("lost");
            hp.text = "Pun The Fighter: DEAD";
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
            Debug.Log("spawn_timer: " + spawn_timer.ToString());
            spawn_timer -= Time.deltaTime;
        }
        if(mon_left > 0 && spawn_timer <= 0){
            mon_left -= 1;
            spawn_timer = UnityEngine.Random.Range(2,5);
            //Debug.Log("spawn here");
            Debug.Log("sp");
            if (phase == 3){
                Debug.Log("sp2");
                // spawn horse statue area Instanitiate(mon_prefab);
                int placement = UnityEngine.Random.Range(0,7);
                Instantiate(mon_prefab, new Vector3(xm1[placement], ym1[placement], zm1[placement]), this.transform.rotation);

            }else if (phase == 7){
                // spawn greek statue area

            }


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
