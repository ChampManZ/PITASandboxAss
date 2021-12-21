using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magmacontroller : MonoBehaviour
{
    private GameObject myplayer;
    private int my_state = 0;
    public AudioSource audioSource;
    public AudioClip going;
    public int playgoing1 = 0;
    public int playgoing2 = 0;
    public int onet = 0;
    public int onett = 0;
    

    // Start is called before the first frame update
    void Start()
    {
         myplayer = GameObject.Find("Main Camera");
         transform.position = new Vector3(transform.position.x,-60f, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        float Dist = Vector3.Distance(myplayer.transform.position, transform.position);
        playercontrol pScript = myplayer.GetComponent<playercontrol>();

        if (playgoing1 == 1 && onet == 0){
            //playgoing = 0;
            onet = 1;
            audioSource.Stop();
            audioSource.PlayOneShot(going);

        }
        if (playgoing2 == 1 && onett == 0){
            //playgoing = 0;
            onett = 1;
            audioSource.Stop();
            audioSource.PlayOneShot(going);

        }

        //Debug.Log(transform.position.y);
        if(my_state == 2){
            my_state = -2;
            playgoing1 = 1;
            
        }
        if(my_state == 4){
            my_state = -4;
            playgoing2 = 1;
            
        }

        //Debug.Log(transform.position.y);

        if (Dist <= 0.5){
            pScript.health -= 10;
        }

        if (pScript.fence_one == 1){
            my_state = 1;
        }else if (pScript.fence_one == 2){
            my_state = 3;
        }

        if(my_state == 1 && transform.position.y < -30f){

            transform.position = new Vector3(transform.position.x, transform.position.y +10, transform.position.z);

        }else if (my_state == 1 && transform.position.y >= -30f){
            my_state = 2;
            transform.position = new Vector3(transform.position.x, -30f, transform.position.z);


        }

        if(my_state == 3 && transform.position.y > -60f){

            transform.position = new Vector3(transform.position.x, transform.position.y -10, transform.position.z);

        }else if (my_state == 1 && transform.position.y <= -60f){
            my_state = 4;
            transform.position = new Vector3(transform.position.x, -60f, transform.position.z);


        }
    
        
    }
}
