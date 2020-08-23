using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject body;
	public int maxHealth = 100;
	public int currentHealth;
	public int damage = -20;
    public HealthBar healthBar;
    public GameObject wallLeft;
    public GameObject wallRight;
    public GameObject wallUp;
    public GameObject wallDown;
    public float spawn_time = 10f;
    private float timer = 0.0f;
    public float threshold_time_spawn = 70.0f;

    public void Initialize(GameObject character)
    {
        m_animator = character.GetComponent<Animator>();
        m_rigidBody = character.GetComponent<Rigidbody>();
    }

    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    //This will be the zombie's speed. Adjust as necessary.
    [SerializeField] private float m_moveSpeedPassive = 2.0f;
    [SerializeField] private float m_moveSpeedAggro = 4.0f;

    private GameObject wayPoint; 
    private Vector3 wayPointPos;
    private float stun_time = -1.0f; 

    private bool stunned = false;

    void Awake() {
        if(!m_animator) { gameObject.GetComponent<Animator>(); }
        if(!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }
    
    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
        wayPoint = GameObject.Find("wayPoint");
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        spawn_enemy();
        if (stunned) {
           
            stun_time += Time.deltaTime;
            print(stun_time);
            if (stun_time > 10) {
                stunned = false;
                currentHealth = maxHealth;
                healthBar.SetMaxHealth(maxHealth);
                m_animator.SetTrigger("Reset");
            }
        }
        else {          
            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.transform.position.y, wayPoint.transform.position.z);
            //Here, the zombie's will follow the waypoint.
            Vector3 oldPos = transform.position;

            transform.rotation = Quaternion.LookRotation(wayPointPos);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, m_moveSpeedAggro * Time.deltaTime);
        

            Vector3 direction = transform.position - Vector3.MoveTowards(transform.position, wayPointPos, m_moveSpeedAggro * Time.deltaTime);
            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }
        

        
        
    }

    void spawn_enemy()
    {
        if (Time.time < threshold_time_spawn)
        {
            timer += Time.deltaTime;
            if (timer > spawn_time)
            {
                Vector3 newPos = generatePos(wallLeft.transform.position.x, wallDown.transform.position.z, wallRight.transform.position.x, wallUp.transform.position.z);
                while (!isValid(newPos))
                {
                    //newPos = generatePos(-3,-3,3,3);
                    newPos = generatePos(wallLeft.transform.position.x, wallDown.transform.position.z, wallRight.transform.position.x, wallUp.transform.position.z);
                }
                Instantiate(this, newPos, this.transform.rotation);
                timer = 0;
            }
        }
    }

    

	public void ChangeHealth(int delta)
	{
		currentHealth += delta;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth <= 0)
        {
            stunned = true;
            stun_time = 0;
            m_animator.SetTrigger("Dead");
        }
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            ChangeHealth(damage);
        }
    }

    public Vector3 generatePos(float minX, float minZ, float maxX, float maxZ)
    {
        float xVal = Random.Range(minX, maxX);
        float zVal = Random.Range(minZ, maxZ);
        return new Vector3(xVal, 0, zVal);
    }

    public bool isValid(Vector3 targetPos)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject current in walls)
        {
            if (current.transform.position == targetPos)
                return false;
        }
        return true;
    }
}