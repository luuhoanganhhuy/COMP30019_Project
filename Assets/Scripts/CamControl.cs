using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
