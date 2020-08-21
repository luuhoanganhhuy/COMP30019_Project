using UnityEngine;

public class Collected : MonoBehaviour
{
    public Player player;
    public int awardPoints = 100;
    public int healthChange = 100;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Player")){
            Vector3 newPos = generatePos();
            while (!isEmpty(newPos)) {
                newPos = generatePos();
            }
            //Debug.Log(newPos);
            Instantiate(this, this.transform.position + newPos, this.transform.rotation);
            Destroy(gameObject);
            player.ChangeHealth(healthChange);
            player.score += awardPoints;
        }
    }

    public Vector3 generatePos() {
        int xVal = Random.Range(0,3);
        int zVal = Random.Range(0,3);  
        return new Vector3(xVal,0,zVal);
    }

    public bool isEmpty(Vector3 targetPos)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject current in walls)
        {
            if(current.transform.position == targetPos)
                return false;
        }
        return true;
    }
}
