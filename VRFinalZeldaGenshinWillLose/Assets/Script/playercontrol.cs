using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public int health = 30;
    public int endphase = 0;
    public int mon_count =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (health <= 0){
            Debug.Log("lost");
        }

        if(mon_count == 10){
            endphase = 1;
            mon_count = 0;
        }



        if (endphase == 1){
            health = 30;
            endphase = 0;
        }
        
    }
}
