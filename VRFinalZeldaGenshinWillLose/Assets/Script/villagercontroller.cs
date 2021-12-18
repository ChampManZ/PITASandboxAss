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

    // Start is called before the first frame update
    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        float Dist = Vector3.Distance(myplayer.transform.position, transform.position);
        playercontrol pScript = myplayer.GetComponent<playercontrol>();

        if (Dist < 3 && vil_state == 0){
            talk_timer = 10;
            vil_state = 1;

        }
        if (talk_timer > 0 ){
            vilAnim.SetInteger("istalk", 1);
            talk_timer -= Time.deltaTime;
        }else if (talk_timer <= 0){
            vilAnim.SetInteger("istalk", 0);
            talk_timer = 0;
        }
        if (talk_timer <= 0 && vil_state == 1){
            talk_timer = 0;
            vil_state = 2;
            audioact = 0;

        }
        if(vil_state == 2){
            pScript.health = 30;
            // spawn scepter*
            Instantiate(staff,new Vector3(287f,26.2f,365.5f), this.transform.rotation);
            Instantiate(platform,new Vector3(308.7039f,23.5f,86f), this.transform.rotation);
            vil_state =3;
            pScript.phase += 1;

        }
        if (pScript.phase == 4 && vil_state == 3){
            vil_state =4;
        }
        if (Dist < 3 && vil_state == 4){
            talk_timer = 10;
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
            pScript.health = 30;
            
            Instantiate(scepter,new Vector3(286.9505f,26.2f,365.7851f), this.transform.rotation);
            Instantiate(platform,new Vector3(123.6641f,23f,354.7492f), this.transform.rotation);
            vil_state = 7;
            pScript.phase += 1;

        }

        if (Dist < 3 && pScript.phase == 8){
            talk_timer = 10;
            vil_state = 8;

        }

        if (talk_timer <= 0 && vil_state == 8){
            talk_timer = 0;
            vil_state = 9;
            audioact = 0;

        }

        if(vil_state == 9){
            // spawn fake removal stone and three plat
            Instantiate(wrong1,new Vector3(451.5409f,21.5f,242f), this.transform.rotation);
            Instantiate(wrong2,new Vector3(449.0959f,21.5f,242f), this.transform.rotation);
            Instantiate(correct,new Vector3(446.5f,21.5f,365.242f), this.transform.rotation);
            Instantiate(fake,new Vector3(456.3251f,21f,250.0303f), this.transform.rotation);

            vil_state = 10;
            pScript.phase += 1;
        }

        if(vil_state == 11){
            talk_timer = 10;
            vil_state = 12;

        }
        if (talk_timer <= 0 && vil_state == 12){
            talk_timer = 0;
            vil_state = 13;
            audioact = 0;

        }

        if(vil_state == 13){
            pScript.health = 30;
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
