using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private int dash = 0;
    private float cooldown = 5f;
    private int dashing = 0;
    private float sx;
    private float sy;
    private float sz;
    private GameObject myplayer;
    [SerializeField] private float die_timer = 2;
    private int die = 0;
    [SerializeField] private float speed = 20;
    [SerializeField] private Animator fireAnim;


    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        //fireAnim.SetInteger("fireact", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //always check dist player to -health*
        float Dist = Vector3.Distance(myplayer.transform.position, transform.position);
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        if(Dist < 1 && die == 0){
            pScript.health -= 8;
        }
        if(die == 1 && die_timer > 0 ){
            die_timer -= Time.deltaTime;

        }else if (die == 1 && die_timer <= 0){
            die_timer = 0;
            Destroy(gameObject);
        }


        if(dashing == 0){
            fireAnim.SetInteger("fireact", 0);
        if (dash < 5){
            

            if(cooldown > 0){
                cooldown -= Time.deltaTime;
                if(3 == System.Math.Round(cooldown)){
                    //look and save point*
                    transform.LookAt(myplayer.transform.position);
                    sx = myplayer.transform.position.x;
                    sy = myplayer.transform.position.y;
                    sz = myplayer.transform.position.z;

                }
            }else if(cooldown <= 0){
                    // set dash state* 
                    dashing = 1;
                    cooldown = 0;

                }
        }else{
            //die* and set act
            die = 1;
            dashing = 2;
            fireAnim.SetInteger("fireact", 3);
        }
        
    }else{
        // go to save point then dash += 1 and set new cooldown
        if(transform.position.x  != sx && transform.position.y != sy && transform.position.z != sz){
            dashing = 1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(sx,sy,sz), Time.deltaTime * speed);
            fireAnim.SetInteger("fireact", 1);

        }else{
            dash += 1;
            dashing = 0;
            fireAnim.SetInteger("fireact", 2);
            cooldown = 5;
        }
        

        
    }
    // set new dialog
    
}
}