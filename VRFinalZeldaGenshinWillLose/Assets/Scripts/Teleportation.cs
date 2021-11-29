using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    [SerializeField] GameObject xr_rig_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void teleport_to_spawn()
    {
        xr_rig_player.transform.position = new Vector3(138, 25, 223);
    }
}
