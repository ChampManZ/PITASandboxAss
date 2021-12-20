using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitdemon : MonoBehaviour
{
    [SerializeField] public GameObject mainself;
    public AudioSource audioSource;
    public AudioClip gethit;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        testdemoncontrol mScript = mainself.GetComponent<testdemoncontrol>();

        
    }
    private void OnCollisionEnter(Collision collision){
        testdemoncontrol mScript = mainself.GetComponent<testdemoncontrol>();
        if(collision.gameObject.tag == "swordtag"){
           // mon_hp -= 1;
           audioSource.Stop();
           audioSource.PlayOneShot(gethit);

            mScript.ishit = "hit";
        }
        
        
    }
}
