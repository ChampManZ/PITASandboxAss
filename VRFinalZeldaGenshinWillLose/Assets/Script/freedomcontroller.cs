using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freedomcontroller : MonoBehaviour
{
    public int free_state = 0;
    private GameObject myplayer;
    // Start is called before the first frame update
    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        if(free_state == 1){
            //send home
            pScript.phase += 1;
            free_state = 2;
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "ignite" && free_state == 0){
            //destroy force and ignite
            DestroyWithTag("ignite");
            DestroyWithTag("allforce");
            free_state = 1;
            

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
