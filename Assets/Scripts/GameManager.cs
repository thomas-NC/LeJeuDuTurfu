using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script qui gère les aspects les plus globaux de la scène
public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject MapManager;
    public GameObject UI;
    public bool OpenDoors;

    //les variables sont en statique pour pouvoir être mises à jour dans le MapManager et traitées dans le MinimapManager
    public static int MinimapPosX;
    public static int MinimapPosY;

    // Start is called before the first frame update
    void Start()
    {
        MinimapPosX = 0;
        MinimapPosY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.GetComponent<PlayerBehavior>().IsDead == true && MinimapPosX == -1 && MinimapPosY == -1)
        {
            UI.transform.Find("WinBackgroundP2").gameObject.SetActive(true);
            Debug.Log("P2 Win");
        }
        else if (Player2.GetComponent<PlayerBehavior>().IsDead == true && MinimapPosX == 1 && MinimapPosY == 1)
        {
            UI.transform.Find("WinBackgroundP1").gameObject.SetActive(true);
            Debug.Log("P1 Win");
        }
        else if (Player1.GetComponent<PlayerBehavior>().IsDead == true || Player2.GetComponent<PlayerBehavior>().IsDead == true)
        {
            OpenDoors = true;
        }
        UI.transform.Find("Minimap").GetComponent<MinimapManager>().MinimapMove();
        if (OpenDoors)
        {
            OpenDoorsFnc();
            OpenDoors = false;
        }
    }

    void OpenDoorsFnc()
    {
        RoomDoors RD = MapManager.GetComponent<SpawnRooms>().ActualRoom.GetComponent<RoomDoors>();
        if (MinimapPosX != -1)
        {
            RD.LeftDoor = false;
        }
        if (MinimapPosX != 1)
        {
            RD.RightDoor = false;
        }
        if (MinimapPosY != 1)
        {
            RD.TopDoor = false;
        }
        if (MinimapPosY != -1)
        {
            RD.BottomDoor = false;
        }
        RD.CheckSpawn = true;
    }
}
