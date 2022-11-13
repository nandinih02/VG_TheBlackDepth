using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed;
    [Header("Movement")]
    public float rotspeed = 8f; //Rotation Speed
    public float playerCraftSpeed;

    [Header("Combat")]
    public float attackDelay=0.1f;
    float timeSinceLastAttack = 0;

    [Header("Prefabs")]
    public Transform frontShotPrefab;

    [Header("Bullet spawn transform")] public Transform bulletTransform;

    AudioSource audioData;
    private float timer;
    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        //Border Control
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.3f, 7.3f),
        //Mathf.Clamp(transform.position.y, -3.5f, 3.5f), transform.position.z);
        //Rotation
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotspeed * Time.deltaTime);

        speed = (Input.GetKey("left shift") || Input.GetKey("right shift")) ? 1 : playerCraftSpeed;
        //Input
        float horispeed = Input.GetAxisRaw("Horizontal");
        float vertispeed = Input.GetAxisRaw("Vertical");

        //Movement
        GetComponent<Rigidbody2D>().velocity = (Vector2.right * horispeed * speed) + (Vector2.up * vertispeed * speed);
    }

    void Attack()
    {
        // Check if player is asking to attack and time between attacks is great enough. if not adds time to timeSinceLastAttack
        if (timeSinceLastAttack >= attackDelay && Input.GetMouseButton(0))
        {
            Transform bullet;
            bullet = Instantiate(frontShotPrefab, bulletTransform.position, transform.rotation) as Transform;
            bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + (transform.up / 32)) * 18;
            bullet = Instantiate(frontShotPrefab, bulletTransform.position, transform.rotation) as Transform;
            bullet.GetComponent<Rigidbody2D>().velocity = (transform.right + (transform.up / -32)) * 18;
            timeSinceLastAttack = 0;
        }
        else timeSinceLastAttack += Time.deltaTime;
    }




}