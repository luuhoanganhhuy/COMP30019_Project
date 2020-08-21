using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public Player player;
    public int healthChange = 100;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        player.ChangeHealth(healthChange);
    }
}
