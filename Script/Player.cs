using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject mainpage, gameoverpage, gamecompleted;
    public GameObject tapToStart;
    float speed = 10f;
    public float maxX;
    public float minX;
    private Rigidbody rb;
    private bool moveleft;
    private bool moveright;
    private float horizontalmove;

    // Start is called before the first frame update
    void Start()
    {
        moveleft = false;
        moveright = false;
        rb = GetComponent<Rigidbody>();
        tapToStart.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartGame();
        }

        //Moveplayer();

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //Inputfunction();
        TouchScreen();
    }

    /*private void Moveplayer()
    {
        if(moveleft)
        {
            horizontalmove = -speed;
        }
        else if(moveright)
        {
            horizontalmove = speed;
        }
        else
        {
            horizontalmove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalmove, 0, 0);
    }

    public void PointDownLeft()
    {
        moveleft = true;
    }
    public void PointUpLeft()
    {
        moveleft = false;
    }
    public void PointDownRight()
    {
        moveright = true;
    }
    public void PointUpRight()
    {
        moveright = false;
    }*/
    public void StartGame()
    {
        tapToStart.SetActive(false);
        Time.timeScale = 1f;
    }
    private void TouchScreen()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousepos = transform.position;
            mousepos.x += Input.GetAxis("Mouse X");
            mousepos.x = Mathf.Clamp(mousepos.x, minX, maxX);
            transform.position = mousepos;
        }
    }
    private void Inputfunction()
    {
        var pos = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            pos.x -= Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }

        transform.position = pos;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wall")
        {
            mainpage.SetActive(false);
            gameoverpage.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            mainpage.SetActive(false);
            gamecompleted.SetActive(true);
        }
    }
    
}

