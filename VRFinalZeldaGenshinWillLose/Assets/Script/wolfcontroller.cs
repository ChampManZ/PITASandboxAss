using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfcontroller : MonoBehaviour
{
    [SerializeField] private int mon_hp = 10;
    private int attacking = 0;
    [SerializeField] private Animator monAnim;
    [SerializeField] private float speed = 4;
    private GameObject myplayer;
    private GameObject mytarget;
    private float die_timer = 3;
    private float atk_timer = 2;
    private int die = 0;
    public string ishit = "nothit";

    // Start is called before the first frame update
    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        mytarget = GameObject.Find("target");
        Debug.Log("i spawned");
        //transform.position = new Vector3(transform.position.x,transform.position.y-5f,transform.position.z);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        float Dist = Vector3.Distance(myplayer.transform.position, transform.position);
        playercontrol pScript = myplayer.GetComponent<playercontrol>();

        Debug.Log( "Wolf Dist: " + Dist.ToString());
        Debug.Log( "Wolf hp: " + mon_hp.ToString());
        //Debug.Log(mon_hp);
        if(Dist < 10){
        

        if (Dist <= 3 && die ==0){
            monAnim.SetInteger("monact", 1);
            if (attacking == 0){
                attacking = 1;
            }else if(attacking == 1 && atk_timer >0){
                atk_timer -= Time.deltaTime;
            }else if (attacking == 1 && atk_timer <= 0){
                attacking = 2;
            }else if(attacking == 2){
                atk_timer = 2;
                attacking = 0;
                pScript.health -= 1;

            }
        }else if (die == 0){
            monAnim.SetInteger("monact", 0);
            attacking = 0;
            atk_timer = 2;
            //Debug.Log("hunt here");
            transform.position = Vector3.MoveTowards(transform.position, mytarget.transform.position, Time.deltaTime * speed);
            transform.LookAt(mytarget.transform.position);
            //transform.LookAt(myplayer.transform.position, -Vector3.up);
            //transform.Rotate(180,-90,0);
            

        }
        }else{
            monAnim.SetInteger("monact", 4);
        }

        if(mon_hp <= 0){
            attacking =0;
            atk_timer = 2;
            die_timer -= Time.deltaTime;
            die =1;
            monAnim.SetInteger("monact", 2);
        }
        if (die_timer <= 0){
            pScript.mon_count += 1;
            Destroy(gameObject);

        }

        if(ishit == "hit"){
            ishit = "nothit";
            mon_hp -= 1;
        }
        
    }

    private void OnCollisionEnter(Collision collision){
        // if(collision.gameObject.tag == "swordtag"){
        //     mon_hp -= 1;
            
        // }
        
        
    }
}
