using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    float distance;
    Vector3 playerPrevPos, playerMoveDir;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;

        distance = offset.magnitude;
        playerPrevPos = player.transform.position;
    }

    void LateUpdate()
    {

        playerMoveDir = player.transform.position - playerPrevPos;
        if (playerMoveDir != Vector3.zero)
        {
            transform.position = player.transform.position - playerMoveDir.normalized * distance;

            Vector3 position = transform.position;
            position.y = 5f;
            transform.position = position; // required height

            transform.LookAt(player.transform.position);

            playerPrevPos = player.transform.position;
        }
    }
}
