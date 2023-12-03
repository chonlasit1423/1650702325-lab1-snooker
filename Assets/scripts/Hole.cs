using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       ball b = other.gameObject.GetComponent<ball>();

       if (b != null)
       {
           GameManager.instance.PlayerScore += b.Point;
           GameManager.instance.UpdateScoreText();
           Destroy(b.gameObject);
       }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
