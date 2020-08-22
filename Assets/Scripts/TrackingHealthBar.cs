using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TrackingHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    // Update is called once per frame
    void Start()
    {
        var wantedPos = Camera.main.WorldToScreenPoint(target.position);
        transform.position = wantedPos;
    }
    void Update()
    {
        var wantedPos = Camera.main.WorldToScreenPoint(target.position);
        transform.position = wantedPos;
    }
}
