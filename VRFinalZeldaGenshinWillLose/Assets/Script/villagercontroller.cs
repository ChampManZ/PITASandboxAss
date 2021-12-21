using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villagercontroller : MonoBehaviour
{

    public GameObject myplayer;
    private float talk_timer;
    private int vil_state = 0;
    private int audioact = 0;
    [SerializeField] private Animator vilAnim;
    [SerializeField] private int me;
    public GameObject scepter;
    public GameObject staff;
    public GameObject platform;
    public GameObject ignite;
    public GameObject fake;
    public GameObject wrong1;
    public GameObject wrong2;
    public GameObject correct;
    [SerializeField] private float speed = 7;
    [SerializeField] float timer1 = 0;
    [SerializeField] float timer2 = 0;
    [SerializeField] float timer3 = 0;
    [SerializeField] float timer4 = 0;
    [SerializeField] TMPro.TextMeshProUGUI villager_dialouge;
    [SerializeField] bool first_meet_check;
    [SerializeField] bool second_meet_check;
    [SerializeField] bool third_meet_check;
    [SerializeField] bool last_meet_check;

    // Start is called before the first frame update
    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        me = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (me == 0){
            me = 1;
            // 

        }
        float Dist = Vector3.Distance(myplayer.transform.position, transform.position);
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        Debug.Log("vil_state: " + vil_state.ToString());
        Debug.Log("talk_timer " + talk_timer.ToString());

        // First meet
        if (Dist < 3 && vil_state == 0){
            talk_timer = 18;
            vil_state = 1;
        }

        if (talk_timer > 0 ){
            vilAnim.SetInteger("istalk", 1);

            if (vil_state == 1)
            {
                talk_timer -= Time.deltaTime;
                timer1 += Time.deltaTime;

                if (timer1 > 0)
                {
                    villager_dialouge.text = "Hey! Are you Pun The Fighter who king yalf send to help us?";
                }

                if (timer1 > 4)
                {
                    villager_dialouge.text = "I am Champ. The villagers are too scared to get outside of their houses.";
                }

                if (timer1 > 7)
                {
                    villager_dialouge.text = "Bring this scepter of Icarus to the abandoned horse statue and eliminate the minions then come back to me.";
                }

                if (timer1 > 12)
                {
                    villager_dialouge.text = "Oh! and be careful when they fight they like to trap their prey with dark forces. Good luck!";
                }

                if (timer1 > 16)
                {
                    villager_dialouge.text = "";
                    timer1 = 17;
                }
            }

            if (vil_state == 5)
            {
                timer2 += Time.deltaTime;

                if (timer2 > 1)
                {
                    villager_dialouge.text = "Great you survived!";
                }

                if (timer2 > 4)
                {
                    villager_dialouge.text = "Here take this staff to the greek statue and do the same thing as before.";
                }

                if (timer2 > 7)
                {
                    villager_dialouge.text = "See you soon my friend!";
                }

                if (timer2 > 10)
                {
                    villager_dialouge.text = "";
                    timer2 = 11;
                }
            }

            if (vil_state == 8)
            {
                timer3 += Time.deltaTime;

                if (timer3 > 1)
                {
                    villager_dialouge.text = "Well done, Pun!";
                }

                if (timer3 > 4)
                {
                    villager_dialouge.text = "Lastly, find the removal stone in the forest then cleanse at the altar there and then bring it back to me.";
                }

                if (timer3 > 7)
                {
                    villager_dialouge.text = "I will craft the removal gem to destroy dark forces and send you home.";
                }

                if (timer3 > 10)
                {
                    villager_dialouge.text = "Oh, I forgot to tell you that be aware of the fire guardian you can’t defeat him with your sword and he is super fast.";
                }

                if (timer3 > 15)
                {
                    villager_dialouge.text = "He will die after he tired.";
                }

                if (timer3 > 18)
                {
                    villager_dialouge.text = "";
                    timer3 = 19;
                }
            }

            if (vil_state == 12)
            {
                timer4 += Time.deltaTime;

                if (timer4 > 1)
                {
                    villager_dialouge.text = "Finally!!! We are free!";
                }

                if (timer4 > 4)
                {
                    villager_dialouge.text = "Thank you so much! Villagers will love this.";
                }

                if (timer4 > 7)
                {
                    villager_dialouge.text = "Take this gem to ignite the rock of freedom there then you can go home now.";
                }

                if (timer4 > 10)
                {
                    timer4 = 11;
                    villager_dialouge.text = "";
                }
            }
        }
        else if (talk_timer <= 0){
            vilAnim.SetInteger("istalk", 0);
            talk_timer = 0;
        }
        if (talk_timer <= 0 && vil_state == 1){
            talk_timer = 0;
            vil_state = 2;
            audioact = 0;

        }
        if(vil_state == 2){
            if(pScript.diffme == 0){
                pScript.health = 30;
            }
            // spawn scepter*
            Instantiate(staff,new Vector3(287f,26.2f,365.5f), this.transform.rotation);
            Instantiate(platform,new Vector3(308.7039f,23.5f,86f), this.transform.rotation);
            vil_state =3;
            pScript.phase += 1;

        }
        if (pScript.phase == 4 && vil_state == 3){
            vil_state =4;
        }

        // Second meet
        if (Dist < 3 && vil_state == 4){
            talk_timer = 11;
            vil_state = 5;
        }

        if (vil_state == 5 && audioact == 0){
            audioact = 1;
        }
        if (vil_state == 1 && audioact == 0){
            audioact = 1;
        }
        if (vil_state == 8 && audioact == 0){
            audioact = 1;
        }
        if (vil_state == 12 && audioact == 0){
            audioact = 1;
        }


        if (talk_timer <= 0 && vil_state == 5){
            talk_timer = 0;
            vil_state = 6;
            audioact = 0;

        }
        if(vil_state == 6){
            // spawn staff *
            if(pScript.diffme == 0){
                pScript.health = 30;
            }
            
            Instantiate(scepter,new Vector3(286.9505f,26.2f,365.7851f), this.transform.rotation);
            Instantiate(platform,new Vector3(123.6641f,23f,354.7492f), this.transform.rotation);
            vil_state = 7;
            pScript.phase += 1;

        }

        // Third meet
        if (Dist < 3 && pScript.phase == 8 && vil_state == 7 ){
            talk_timer = 20;
            vil_state = 8;
        }

        if (talk_timer <= 0 && vil_state == 8){
            talk_timer = 0;
            vil_state = 9;
            audioact = 0;

        }

        if(vil_state == 9){
            // spawn fake removal stone and three plat
            Debug.Log("puzzle spawned");
            Instantiate(wrong1,new Vector3(451.5409f,21.5f,242f),Quaternion.identity);
            Instantiate(wrong2,new Vector3(449.0959f,21.5f,242f), Quaternion.identity);
            Instantiate(correct,new Vector3(446.5f,21.5f,242f), Quaternion.identity);
            Instantiate(fake,new Vector3(456.3251f,21f,250.0303f), Quaternion.identity);

            vil_state = 10;
            pScript.phase += 1;
        }

        if(vil_state == 11){
            talk_timer = 12;
            vil_state = 12;
        }
        if (talk_timer <= 0 && vil_state == 12){
            talk_timer = 0;
            vil_state = 13;
            audioact = 0;

        }

        if(vil_state == 13){
            if(pScript.diffme == 0){
                pScript.health = 30;
            }
            
            // spawn ignite gem
            Instantiate(ignite,new Vector3(286.8602f,26.2f,365.7915f), this.transform.rotation);
            vil_state = 14;
            pScript.phase += 1;
        }
        if (vil_state == 14){
            // walk to rock of freedom and stand still
            // set act to run to still
            if(System.Math.Round(transform.position.x) != 293 && System.Math.Round(transform.position.y) != 22 && System.Math.Round(transform.position.z) != 354){
                // act walk
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(293f,22f,354f), Time.deltaTime * speed);
                vilAnim.SetInteger("istalk", 2);
            }else{
                vil_state = 15;
                vilAnim.SetInteger("istalk", 3);
                vilAnim.SetInteger("istalk", 0);

                //act idle

            }

        }
        if(vil_state == 15){
            //end
        }


        




        
    }

    //collide function and if vil_state == 10 to vil_state 11 and destroy removal tag*
    private void OnCollisionEnter(Collision collision){
        // Last meet
        if(collision.gameObject.tag == "removal" && vil_state == 10){
            DestroyWithTag("removal");
            vil_state = 11;
        }
        
        
    }
    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }


}
