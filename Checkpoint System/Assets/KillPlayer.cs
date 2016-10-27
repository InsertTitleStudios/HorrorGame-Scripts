using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    public int playerHealth = 30;
    private int smallEnemyDamage = 10;
    private int largeEnemyDamage = 30;

	// Use this for initialization
	void Start ()
    {
        print(playerHealth);
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            playerHealth = 30;
        }
        

	
	}
    void OnCollisionEnter(Collision other) //Fix Collision - Doesn't work however health function works when done manually
    {
        if (other.gameObject.tag =="Small Enemy")
        {
            print("enemy just touched" + playerHealth);
            playerHealth -= smallEnemyDamage;
        }
        if (other.gameObject.tag == "Large Enemy")
        {
            print("enemy just touched" + playerHealth);
            playerHealth -= largeEnemyDamage;
        }
    }
  /*  void OnTriggerEnter(Collider other) //Change this to enemy kills player & deducts player's health etc...
    {
        if (other.name == "Player")
        {
            //Player loses health change this to small enemies as 3 hits & large enemy as 1 hit

            //Player loses 1 Health

            levelManager.RespawnPlayer();
        }
    }*/
}
