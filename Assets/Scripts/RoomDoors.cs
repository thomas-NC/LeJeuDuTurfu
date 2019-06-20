using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script attaché au parent du prefab, on stocke toutes les variables que l'on va récupérer dans le MapManager
public class RoomDoors : MonoBehaviour
{
    //variables pour détruire les portes
    public bool LeftDoor;
    public bool RightDoor;
    public bool TopDoor;
    public bool BottomDoor;

    //variables qui correspondent aux réultats des triggers
    public bool CreateLeft;
    public bool CreateRight;
    public bool CreateTop;
    public bool CreateBottom;
    public bool CheckSpawn;

    private void Awake()
    {
        CreateLeft = false;
        CreateRight = false;
        CreateTop = false;
        CreateBottom = false;
    }
    //destruction des portes(appelée dans le GameManager)
    private void Update()
    {
        if(LeftDoor == false)
        {
            Destroy(GameObject.Find("LeftWall"));
            LeftDoor = true;
        }
        if (RightDoor == false)
        {
            Destroy(GameObject.Find("RightWall"));
            RightDoor = true;
        }
        if (TopDoor == false)
        {
            Destroy(GameObject.Find("TopWall"));
            TopDoor = true;
        }
        if (BottomDoor == false)
        {
            Destroy(GameObject.Find("BottomWall"));
            BottomDoor = true;
        }
    }
}
