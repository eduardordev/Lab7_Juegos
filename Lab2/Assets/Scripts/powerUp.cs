using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    // Start is called before the first frame update

    public float velAngular = 0;
    private Vector3 initPos;
    void Start()
    {
        initPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, velAngular) * Time.deltaTime);

        transform.position = initPos + new Vector3(0, Mathf.Sin(Time.time), 0)*0.5f; //Metodo para la rotacion y oscilacion de mis monedas.
    }

}
