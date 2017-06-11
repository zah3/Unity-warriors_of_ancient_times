using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * skrypt napisany wspólnie przez Marcina Wieczorka, Macieja Dolnego i Zachariasza Staniszewskiego
 * Marcin - zamował się tutaj pod menu
 * Maciej - systemem walki
 * Zachariasz - manipulował poruszaniem się, dodał dźwięki,funkcje randomowych dźwięków
 */
public class PlayerController : MonoBehaviour
{
    public bool move = false;
    private Vector3 targetPosition;

    public int killed_enemies = 0;
    public int health = 100;
    public int hit_time;
    public int force = 25;
    public bool is_alive = true;
    public bool fighting = false;
    private float current_time = 0;
    public bool enemyInside = false;
    public GameObject Enemy;
    public GameObject dead_q;
    public GameObject dead_q_2;
    public float licznik = 0;
    public float czas;
    

    public bool is_colision = false;
    public EnemyController enemy;
    // Use this for initialization
    private AudioSource audio;
    private AIPath pathFinding;


    [SerializeField]
    private Stat hp; //health Bar, aby dodac np. energy, shield nalezy dodac: private Stat energy

    private void Awake()
    {
        hp.Initialize(); //inicjalizacja paska health, mozliwe dodanie np. mana, energy, shield: energy.Initialize();
    }

    void Start()
    {
        enemy = Enemy.GetComponent<EnemyController>();
        pathFinding = this.GetComponent<AIPath>();
        audio = this.GetComponent<AudioSource>();
        targetPosition = this.transform.position;
        targetPosition.z = -1;
        pathFinding.target.transform.position = targetPosition;
        this.move = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(killed_enemies == 3)
        {
            LevelMenager level =  this.GetComponent<LevelMenager>();
            level.LoadLevel("finish");
        }
        if (enemy.is_hit_from_behind && enemy.is_alive)
        {
            killed_enemies++;
            RandomDeadQuiet();
            enemy.RandomFall();
            enemy.health = 0;
            enemy.is_alive = false;

        }
        // poruszanie się bohatera, nadpisuję funkcje z assetów.
        if (Input.GetMouseButtonDown(0)){
            // pobieram 
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = -1;
            pathFinding.target.transform.position = targetPosition;
            
            move = true;
        }
        if(move == true && pathFinding.speed == 1 && !audio.isPlaying)
            audio.Play();

        if (Input.GetKeyDown("r")){
            if (pathFinding.speed == 1){
                pathFinding.speed = 0.5f;
                audio.volume = 0.6f;
                if (!audio.isPlaying)
                    audio.Play();
            }else{
                pathFinding.speed = 1;
                audio.volume = 1;
                if (!audio.isPlaying)
                    audio.Play();
            }  
        }

        if (this.transform.position == targetPosition){
            if(move == true)
                move = false;
            if (audio.isPlaying) 
                audio.Stop();
        }
        if (enemy.is_colision == true && !enemyInside)
        {
            killed_enemies++;
            RandomDeadQuiet();
            enemy.RandomFall();
            enemy.health = 0;
            enemy.is_alive = false;
            fighting = false;
            licznik = 0;

        }
        if (enemyInside == true && enemy.is_alive)
        {
            if (enemy.health <= 0)
            {
                killed_enemies++;
                enemy.RandomDead();
                enemy.is_alive = false;
                fighting = false;
                licznik = 0;
                enemy.RandomFall();
            }

            licznik += Time.deltaTime;
            if (licznik > czas)
            {
                if (enemy.health > 0 && health > 0)
                {
                    current_time += Time.deltaTime;
                    if (current_time >= enemy.hit_time)
                    {
                        enemy.RandomPick();
                        hp.CurrentVal -= enemy.force;
                        health = health - enemy.force;
                        current_time = 0;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemy = other.GetComponent<EnemyController>();

            var enemyHealth = enemy.health;
            var enemyTime = enemy.hit_time;
            if (enemy.is_alive){
                enemyInside = true;
            }
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
    public void RandomDeadQuiet()
    {
        var rnd = new System.Random();
        int random = rnd.Next(1, 2);

        if (random == 2)
        {
            AudioSource play = dead_q.GetComponent<AudioSource>();
            play.Play();
        }
        else if (random == 1)
        {
            AudioSource play = dead_q_2.GetComponent<AudioSource>();
            play.Play();
        }
    }
}
