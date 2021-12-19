using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    //public int diffit = 0;
    public GameObject myplayer;
    [SerializeField] TMPro.TextMeshProUGUI diff_desc;
    void Start()
    {
        myplayer = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        if(pScript.diffme == 0){
            diff_desc.text = "Diffculty: Easy (checkpoint HP restore)";
        }else{
            diff_desc.text = "Diffculty: Hard (no HP restore)";
        }
        
    }
    public void hardme()
    {
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        pScript.diffme = 1;
        
    }
    public void easyme()
    {
        playercontrol pScript = myplayer.GetComponent<playercontrol>();
        pScript.diffme = 0;
        
    }
}
