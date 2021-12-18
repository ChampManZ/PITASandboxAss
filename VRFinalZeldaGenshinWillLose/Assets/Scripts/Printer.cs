using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public GameObject myplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HelloThere()
    {
        Debug.Log("hovering There!");
    }
    public void Selectingkrub(){
        myplayer = GameObject.Find("Main Camera");
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        pScript.phase += 1;
        pScript.health = 30;
        DestroyWithTag("artdia");
        DestroyWithTag("artlong");
        DestroyWithTag("plat");
        Debug.Log("select placed");
    }

    public void Selectingwrong1(){
        myplayer = GameObject.Find("Main Camera");
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        //Destroy(gameObject);
        DestroyWithTag("wrong");
        pScript.health -= 15;
        Debug.Log("select wrong placed");
    }
    public void Selectingwrong2(){
        myplayer = GameObject.Find("Main Camera");
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        //Destroy(gameObject);
        DestroyWithTag("wrong2");
        pScript.health -= 15;
        Debug.Log("select wrong placed");
    }

    public void Selectingcorrect(){
        myplayer = GameObject.Find("Main Camera");
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        pScript.health = 30;
        //destroy self, wrong plat tag, spawn real removal stone and fire monster timer
        DestroyWithTag("correct");
        DestroyWithTag("fake");



        //pScript.phase += 1;
        //DestroyWithTag("plat");
        Debug.Log("select right placed");
    }
    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }
}
