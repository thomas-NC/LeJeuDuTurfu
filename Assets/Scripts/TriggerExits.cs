using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script qui va récupérer les triggers de chaque porte lorsque les joueurs changent de salle
public class TriggerExits : MonoBehaviour
{
    private string exitTag;
    private RoomDoors RD;
    
    void Start()
    {
        exitTag = gameObject.tag;
        RD = gameObject.GetComponentInParent<RoomDoors>();
    }

    //on change la valeur des variables dans RoomDoors qui est l'objet parent du prefab(de chaque tilemap)
    //pour les récupérer et faire spawn une room du bon côté
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && exitTag == "LeftTrigger" && RD.CheckSpawn)
        {
            //Debug.Log("gauche");
            RD.CreateLeft = true;
        }
        if (collision.CompareTag("Player") && exitTag == "RightTrigger" && RD.CheckSpawn)
        {
            //Debug.Log("droite");
            RD.CreateRight = true;
        }
        if (collision.CompareTag("Player") && exitTag == "TopTrigger" && RD.CheckSpawn)
        {
            //Debug.Log("haut");
            RD.CreateTop = true;
        }
        if (collision.CompareTag("Player") && exitTag == "BottomTrigger" && RD.CheckSpawn)
        {
            //Debug.Log("bas");
            RD.CreateBottom = true;
        }
    }
}
