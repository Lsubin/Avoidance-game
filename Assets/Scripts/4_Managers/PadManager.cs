using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadManager : MonoBehaviour
{
   // public GameObject padRed;
    public GameObject blockRed;
    public GameObject blockBlue;

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
            //blockRed.transform.localScale = new Vector3(0, 0, -90);
            blockRed.SetActive(false);
        }
        if (collision.CompareTag("Player2"))
        {
            //blockRed.transform.localScale = new Vector3(0, 0, -90);
            blockBlue.SetActive(false);
        }
    }

    
    /*
    IEnumerator Animation()
    {
        blockRed.transform.localEulerAngles = new Vector3(0, 0, -90);
        yield return null;
    }
    */
}
