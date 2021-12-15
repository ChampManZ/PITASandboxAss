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
        DestroyWithTag("artdia");
        DestroyWithTag("artlong");
        DestroyWithTag("plat");
        Debug.Log("select placed");
    }
    void DestroyWithTag (string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy (oneObject);
    }
}
