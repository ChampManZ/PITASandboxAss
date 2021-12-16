using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moncontroller : MonoBehaviour
{
    private int mon_hp = 15;
    private int attacking = 0;
    [SerializeField] private Animator monAnim;
    private GameObject myplayer;
    private float die_timer = 3;
    private float atk_timer = 2;

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

        Debug.Log( "Dist: " + Dist.ToString());
        //Debug.Log(mon_hp);
        

        if (Dist <= 3){
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
        }else{
            monAnim.SetInteger("monact", 0);
            attacking = 0;
            atk_timer = 2;
            //Debug.Log("hunt here");
            

        }

        if(mon_hp <= 0){
            attacking =0;
            atk_timer = 2;
            die_timer -= Time.deltaTime;
            monAnim.SetInteger("monact", 2);
        }
        if (die_timer <= 0){
            pScript.mon_count += 1;
            Destroy(gameObject);

        }
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "swordtag"){
            mon_hp -= 1;
        }
        
        
    }



}
