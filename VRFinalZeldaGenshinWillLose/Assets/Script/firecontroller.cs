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
    private float die_timer = 4;
    private int die = 0;
    [SerializeField] private float speed = 7;


    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        
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


        if(dashing == 0){
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
        }
        
    }else{
        // go to save point then dash += 1 and set new cooldown
        if(transform.position.x  != sx && transform.position.y != sy && transform.position.z != sz){
            dashing = 1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(sx,sy,sz), Time.deltaTime * speed);

        }else{
            dashing = 0;
            cooldown = 5;
        }
        

        
    }
    // set new dialog
    
}
}