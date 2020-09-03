using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoScript : MonoBehaviour
{

    int page = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Background1").gameObject.SetActive(false);
        transform.Find("Background2").gameObject.SetActive(false);
        transform.Find("Background3").gameObject.SetActive(false);
        transform.Find("next").gameObject.SetActive(true);

        transform.Find("pre").gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (page == 0)
        {
            transform.Find("Background1").gameObject.SetActive(true);
            transform.Find("Background2").gameObject.SetActive(false);
            transform.Find("Background3").gameObject.SetActive(false);
            transform.Find("pre").gameObject.SetActive(false);
            transform.Find("next").gameObject.SetActive(true);
        }
        else if (page == 1)
        {
            transform.Find("Background1").gameObject.SetActive(false);
            transform.Find("Background2").gameObject.SetActive(true);
            transform.Find("Background3").gameObject.SetActive(false);
            transform.Find("pre").gameObject.SetActive(true);
            transform.Find("next").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("Background1").gameObject.SetActive(false);
            transform.Find("Background2").gameObject.SetActive(false);
            transform.Find("Background3").gameObject.SetActive(true);
            transform.Find("pre").gameObject.SetActive(true);
            transform.Find("next").gameObject.SetActive(false);
        }
    }


    public void next()
    {
        page++;
        
    }
    public void pre()
    {
        page--;
        
    }
}
