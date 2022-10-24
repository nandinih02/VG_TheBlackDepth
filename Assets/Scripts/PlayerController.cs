using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera cam;
    public GameObject bullet, BulletSpawn;
    public float fireRate = 0.25f;
    public float bulletSpeed = 10f;
    private float horiz, vert;

    private float timer;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Player movement.
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horiz * speed, vert * speed, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);

        //Check mouse position on the screen
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        // Check if Fire1 button is pressed

        if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            // What is I instantiate? Where? What is its rotation?
            GameObject bulletObj;
            bulletObj = GameObject.Instantiate(bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);

            Rigidbody2D bulletRB = bulletObj.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(BulletSpawn.transform.right * bulletSpeed, ForceMode2D.Impulse);

            // reset timer
            timer = 0;
        }

        timer += Time.deltaTime;


        // Player rotation following mouse

        Vector2 lookDirection = mousePos - GetComponent<Rigidbody2D>().position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = angle;
        lookDirection.Normalize();

    }


}