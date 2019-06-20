using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavio : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("touché");
            collider.GetComponentInParent<PlayerBehavior>().Life -= 1;
            Destroy(gameObject);
        }
        else if (!collider.CompareTag("Player"))
        {
            Debug.Log("touché un mur");
            Destroy(gameObject);
        }
    }
}
