using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Interact : MonoBehaviour
{
    public float range = 5.0f;
    Player playerinput;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerinput = ReInput.players.GetPlayer(ReInput.players.GetPlayerId(name));
    }

    // Update is called once per frame
    void Update()
    {
        if (playerinput.GetButtonDown("Interact"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,transform.forward, out hit,range,layerMask))
            {
                hit.collider.GetComponent<opendoor>().Open();
            }
        }
    }
}
