using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public int healthChange = -10;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        player.ChangeHealth(healthChange);
    }
}
