using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public bool move;
    public bool fighting;
    public float speed;
    public GameObject Hero;

    public int health = 60;
    private int current_time = 0;
    public int hit_time = 6;
    public int force = 20;

    private Vector3 playerPosition;
    
	// Update is called once per frame
	void Update () {
        if (fighting)
        {
            playerPosition = Hero.transform.position;
            FallowPlayer();
        }

		
	}
    void FallowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
    void OnColiisionEnter2D(Collision2D coll)
    {
        PlayerController player = coll.collider.GetComponent<PlayerController>() as PlayerController;
        var player_time = player.hit_time;
        var player_force = player.force;


    }
}
