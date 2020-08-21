﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int maxHealth = 1000;
	public int currentHealth;
	public int score = 0;
	public int damage = -1;
	public double distanceMinimum = 1.5;
	public HealthBar healthBar;

	public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		targets = GameObject.FindGameObjectsWithTag("Enemy");
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ChangeHealth(+200);
		}
		Distance();
    }

	void Distance()
    {
		for (int i = 0; i < targets.Length; i++){
			float distance = Vector3.Distance(targets[i].transform.position, transform.position);
			if (distance < distanceMinimum)
			{
				ChangeHealth(damage);
			}
		}
		
	}

	public void ChangeHealth(int delta)
	{
		currentHealth += delta;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		if (currentHealth < 0)
        {
			//currentHealth = 0;
			Global.overallScore = score;
			if (Global.overallScore > Global.maxScore) {
				Global.maxScore = Global.overallScore;
			}
			SceneManager.LoadScene(2);
        }

		healthBar.SetHealth(currentHealth);
	}
}

public static class Global {
	public static int overallScore;
	public static int maxScore = 0;
}
