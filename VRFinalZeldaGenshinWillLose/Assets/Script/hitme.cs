using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitme : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject mainself;
    public AudioSource audioSource;
    public AudioClip gethit;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        wolfcontroller mScript = mainself.GetComponent<wolfcontroller>();

        
    }
    private void OnCollisionEnter(Collision collision){
        wolfcontroller mScript = mainself.GetComponent<wolfcontroller>();
        if(collision.gameObject.tag == "swordtag"){
           // mon_hp -= 1;
           audioSource.Stop();
           audioSource.PlayOneShot(gethit);

            mScript.ishit = "hit";
        }
        
        
    }
}
