using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport5 : MonoBehaviour
{
    public GameObject player1;
    public GameObject teleport;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1 = collision.gameObject;
            //player1.transform.position = new Vector3(-6.49f, -2.49f, 0.00f);
            player1.transform.position = teleport.transform.position;
        }
    }
}
