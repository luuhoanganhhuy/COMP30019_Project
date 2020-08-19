using UnityEngine;
using System.Collections.Generic;

public class ZombieCharacterControl : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    //This will be the zombie's speed. Adjust as necessary.
    [SerializeField] private float m_moveSpeedPassive = 2.0f;
    [SerializeField] private float m_moveSpeedAggro = 4.0f;

    private GameObject wayPoint; 
    private Vector3 wayPointPos;

    void Awake() {
        if(!m_animator) { gameObject.GetComponent<Animator>(); }
        if(!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    void Start () {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
    }
 
    void Update () {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        Vector3 oldPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, m_moveSpeedAggro * Time.deltaTime);

        Vector3 moveVector = transform.position - Vector3.MoveTowards(transform.position, wayPointPos, m_moveSpeedAggro * Time.deltaTime);
        m_animator.SetFloat("MoveSpeed", moveVector.magnitude);
    }
}