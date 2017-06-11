using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * skrypt napisany wspólnie przez  Macieja Dolnego i Zachariasza Staniszewskiego
 * Maciej - systemem walki
 * Zachariasz - manipulował poruszaniem się przeciwnika za hero, dodał dźwięki, funkcje randomowych dźwięków
 */
public class EnemyController : MonoBehaviour {

    public bool move;
    public bool fighting;
    public float speed;
    public GameObject Hero;

    public int health = 60;
    private float current_time;
    public int hit_time = 60;
    public int force = 20;
    public bool is_alive = true;
    public bool playerInside = false;
    public float licznik = 0;
    public float czas;

    private Vector3 playerPosition;
    private PlayerController player;
    public bool is_colision;
    public bool is_hit_from_behind;
    public GameObject dead;
    public GameObject dead_2;
    public GameObject dead_3;
    public GameObject fall_1;
    public GameObject fall_2;
    public GameObject pick_1;
    public GameObject pick_2;

    void Start()
    {
        player = Hero.GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update () {
        if (fighting)
        {
            if (!is_alive)
                fighting = false;
            playerPosition = Hero.transform.position;
            FallowPlayer();
        }
        

        if (playerInside == true && is_alive)
        {
            fighting = true;
            licznik += Time.deltaTime;
            if (licznik > czas)
            {
                {
                    if (player.health > 0 && health > 0)
                    {
                        current_time += Time.deltaTime;
                        if (current_time >= player.hit_time)
                        {
                            RandomPick();
                            health = health - player.force;
                            current_time = 0;
                            if (player.health <= 0)
                            {
                                RandomDead();
                                RandomFall();
                                player.is_alive = false;
                                fighting = false;
                                LevelMenager level = this.GetComponent<LevelMenager>();
                                level.LoadLevel("fail");
                            }
                        }
                    }
                }
            }
        }
    }
    void FallowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController p = other.GetComponent<PlayerController>();
            var playerHealth = p.health;
            var playerTime = p.hit_time;

            if (p.is_alive)
                playerInside = true;
        }
    }
    void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
        is_colision = true;
    }
    void OnCollisionExit2D(Collision2D myCollisionInfo)
    {
        is_colision = false;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            player.enemy = this.GetComponent<EnemyController>();
            is_hit_from_behind = true;
        }
    }

    public void RandomDead()
    {
        var rnd = new System.Random();
        int random = rnd.Next(1, 3);
        if(random == 1) {
            AudioSource play = dead.GetComponent<AudioSource>();
            play.Play();
        }else if(random == 2){
            AudioSource play = dead_2.GetComponent<AudioSource>();
            play.Play();
        }else{
            AudioSource play = dead_3.GetComponent<AudioSource>();
            play.Play();
        }
    }
    public void RandomFall()
    {
        var rnd = new System.Random();
        int random = rnd.Next(1, 2);
        if (random == 2)
        {
            AudioSource play = fall_1.GetComponent<AudioSource>();
            play.Play();
        }
        else if (random == 1)
        {
            AudioSource play = fall_2.GetComponent<AudioSource>();
            play.Play();
        }
    }
    public void RandomPick()
    {
        var rnd = new System.Random();
        int random = rnd.Next(1, 2);
        if (random == 2)
        {
            AudioSource play = pick_1.GetComponent<AudioSource>();
            play.Play();
        }
        else if (random == 1)
        {
            AudioSource play = pick_2.GetComponent<AudioSource>();
            play.Play();
        }
    }


}
