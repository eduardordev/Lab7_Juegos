using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMoves : MonoBehaviour
{
    // Start is called before the first frame update
    //Variables para inicializar valores y posicion
    public float force = 0;
    public float jumpForce = 0;
    private Vector3 initPos;
    private int count = 0;
    Rigidbody rb;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;


    void Start()
    {
        rb = GetComponent<Rigidbody>();//Inicializo la posicion de mi rigid body
        initPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();//llamo al metodo para saltar cuando se presiona el boton space
        }

        if (Input.GetKeyUp(KeyCode.Return))
            player.transform.position = respawnPoint.transform.position;

           
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector3(horizontal, 0, vertical) * force);//metodo para el movimiento con fuerzas fisicas.
    
    }

    private void Jump()
    {
        if(rb)
            if(Mathf.Abs(rb.velocity.y) < 0.05f)
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);//Metodo saltar
            }
    }

    private void OnTriggerEnter(Collider collision)
    {
 
        if (collision.gameObject.CompareTag("PowerUp"))//Metodo para el manejo de mis distintas colisiones
            collision.gameObject.SetActive(false);
            count++;
        
        if (count == 4 && collision.gameObject.CompareTag("Lava"))
            collision.gameObject.SetActive(false);
        else if(count < 4  && collision.gameObject.CompareTag("Lava"))
            Destroy(this.gameObject);

    }


    
    
}
