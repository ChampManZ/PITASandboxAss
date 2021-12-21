using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{

    [SerializeField] GameObject xr_rig_player;
    [SerializeField] TMPro.TextMeshProUGUI intro_desc;
    [SerializeField] bool btnTextChange = true;
    [SerializeField] float timer = 0;
    [SerializeField] Button introBtn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (btnTextChange)
        {
            timer += Time.deltaTime;
            GameObject.Find("Close/Open Button").GetComponentInChildren<Text>().text = "Close";

            if (timer >= 1)
            {
                intro_desc.text = "Dear Pun the Fighter";
            }

            if (timer >= 4)
            {
                intro_desc.text = "The village of wasteland is threatened and lockdown";
            }

            if (timer >= 7)
            {
                intro_desc.text = "by minions of the darkness.";
            }

            if (timer >= 10)
            {
                intro_desc.text = "The whole village is surrounded bt dark forces.";
            }

            if (timer >= 13)
            {
                intro_desc.text = "Use your enchanted pearl sword to defeat the minions";
            }

            if (timer >= 17)
            {
                intro_desc.text = "and save the village!";
            }

            if (timer >= 20)
            {
                intro_desc.text = "Be aware of the wolves there...";
            }

            if (timer >= 23)
            {
                intro_desc.text = "";
                GameObject.Find("Close/Open Button").GetComponentInChildren<Text>().text = "Replay";
                introBtn.onClick.AddListener(replay_intro);
            }
        }
        else
        {
            intro_desc.text = "";
            GameObject.Find("Close/Open Button").GetComponentInChildren<Text>().text = "Continue";
        }

        Debug.Log(btnTextChange);
    }

    void replay_intro()
    {
        timer = 0;
    }

    public void teleport_to_spawn()
    {
        xr_rig_player.transform.position = new Vector3(138, 25, 223);
    }

    public void introduction_script()
    {
        btnTextChange = !btnTextChange;
    }

    public void debugger()
    {
        xr_rig_player.transform.position = xr_rig_player.transform.position + new Vector3(145, 5, 130);
    }

    public void debugger2()
    {
        xr_rig_player.transform.position = xr_rig_player.transform.position + new Vector3(25, 10, -272);
    }
}
