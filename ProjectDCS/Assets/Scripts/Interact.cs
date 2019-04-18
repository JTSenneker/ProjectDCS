using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityStandardAssets.Characters.FirstPerson;

public class Interact : MonoBehaviour
{
    public float range = 5.0f;
    Player playerinput;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement player = gameObject.GetComponent<PlayerMovement>();
        playerinput = ReInput.players.GetPlayer(player.controllerId);
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
