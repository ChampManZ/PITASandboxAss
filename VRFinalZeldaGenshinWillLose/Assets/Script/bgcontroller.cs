using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip before_talk;
    public AudioClip after_talk;
    public AudioClip battle1;
    public AudioClip battle2;
    public AudioClip win;
    public AudioClip lost;
    public GameObject myplayer;

    [SerializeField] public int nowplay = -1;

    // public string playing = "first";
    // public string newplay = "before_talk";

    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        playercontrol pScript = myplayer.GetComponent<playercontrol>();

        if (nowplay != pScript.phase){

            if(pScript.phase == 0 || pScript.phase == 4 || pScript.phase == 8){
                nowplay = pScript.phase;
                audioSource.Stop();

                audioSource.PlayOneShot(before_talk);

            }else if (pScript.phase == 1 || pScript.phase == 5 || pScript.phase == 9){
                nowplay = pScript.phase;
                audioSource.Stop();

                audioSource.PlayOneShot(after_talk);

            }
            else if (pScript.phase == 2 ){
                nowplay = pScript.phase;
                audioSource.Stop();

                audioSource.PlayOneShot(battle1);
                
            }
            else if (pScript.phase == 6){
                nowplay = pScript.phase;
                audioSource.Stop();

                audioSource.PlayOneShot(battle2);
                
            }
            else if (pScript.phase == 10){
                nowplay = pScript.phase;
                audioSource.Stop();

                audioSource.PlayOneShot(win);
                
            }
            else if (pScript.phase == -2){
                nowplay = pScript.phase;
                audioSource.Stop();

                audioSource.PlayOneShot(lost);
                
            }




        }
        
    }
}
