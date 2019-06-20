using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script attaché au MapManager, il s'occupe de créer la map, faire spawn les joueurs et faire bouger la camera
public class SpawnRooms : MonoBehaviour
{
    //spawn les joueurs à chaque changement de room
    public GameObject Player1;
    public GameObject Player2;
    //faire bouger la MainCamera à chaque changement de room
    public Camera Cam;
    public float CamSpeed;

    public List<GameObject> Rooms = new List<GameObject>();
    public GameObject ActualRoom;
    public GameObject NextRoom;
    private float ExitPosX;
    private float ExitPosY;
    private float EntryPosX;
    private float EntryPosY;

    private void Update()
    {
        //ici on récupère l'information des triggers pour savoir si on doit créer une map(et dans quelle direction)
        RoomDoors RD = ActualRoom.GetComponent<RoomDoors>();
        bool TriggerLeft = RD.CreateLeft;
        bool TriggerRight = RD.CreateRight;
        bool TriggerTop = RD.CreateTop;
        bool TriggerBottom = RD.CreateBottom;
        bool TriggerCheck = RD.CheckSpawn;

        if (TriggerLeft == true && TriggerCheck)
        {
            //Debug.Log("zou c'est le gauche");
            SpawnRoomLeft();
            ResetPlayers();
            SpawnPlayers();
            GameManager.MinimapPosX -= 1;
        }
        if(TriggerRight == true && TriggerCheck)
        {
            //Debug.Log("oho c'est le droite");
            SpawnRoomRight();
            ResetPlayers();
            SpawnPlayers();
            GameManager.MinimapPosX += 1;
        }
        if (TriggerTop == true && TriggerCheck)
        {
            //Debug.Log("oho c'est le haut");
            SpawnRoomTop();
            ResetPlayers();
            SpawnPlayers();
            GameManager.MinimapPosY += 1;
        }
        if (TriggerBottom == true && TriggerCheck)
        {
            //Debug.Log("oho c'est le droite");
            SpawnRoomBottom();
            ResetPlayers();
            SpawnPlayers();
            GameManager.MinimapPosY -= 1;
        }
        MoveCamera();

    }

    public void ResetPlayers()
    {
        PlayerBehavior P1 = Player1.GetComponent<PlayerBehavior>();
        PlayerBehavior P2 = Player2.GetComponent<PlayerBehavior>();
        P1.IsDead = false;
        P2.IsDead = false;
        foreach  (GameObject heart in P1.Hearts)
        {
            heart.GetComponent<Animator>().SetBool("Heart_Death", false);
        }
        foreach (GameObject heart in P2.Hearts)
        {
            heart.GetComponent<Animator>().SetBool("Heart_Death", false);
        }
        P1.Life = 3;
        P2.Life = 3;
    }

    public void SpawnRoomRight()
    {
        NextRoom = Rooms[Random.Range(0, Rooms.Count)];
        NextRoom = Instantiate(NextRoom);

        ExitPosX = ActualRoom.transform.Find("RightExit").transform.position.x;
        ExitPosY = ActualRoom.transform.Find("RightExit").transform.position.y;
        EntryPosX = NextRoom.transform.position.x + NextRoom.transform.Find("LeftExit").transform.position.x;
        EntryPosY = NextRoom.transform.position.y + NextRoom.transform.Find("LeftExit").transform.position.y;

        NextRoom.transform.position = new Vector3(ExitPosX - EntryPosX, ExitPosY - EntryPosY);
        Destroy(ActualRoom);
        ActualRoom = NextRoom;
    }
    public void SpawnRoomLeft()
    {
        NextRoom = Rooms[Random.Range(0, Rooms.Count)];
        NextRoom = Instantiate(NextRoom);

        ExitPosX = ActualRoom.transform.Find("LeftExit").transform.position.x;
        ExitPosY = ActualRoom.transform.Find("LeftExit").transform.position.y;
        EntryPosX = NextRoom.transform.position.x + NextRoom.transform.Find("RightExit").transform.position.x;
        EntryPosY = NextRoom.transform.position.y + NextRoom.transform.Find("RightExit").transform.position.y;

        NextRoom.transform.position = new Vector3(ExitPosX - EntryPosX, ExitPosY - EntryPosY);
        Destroy(ActualRoom);
        ActualRoom = NextRoom;
    }
    public void SpawnRoomTop()
    {
        NextRoom = Rooms[Random.Range(0, Rooms.Count)];
        NextRoom = Instantiate(NextRoom);

        ExitPosX = ActualRoom.transform.Find("TopExit").transform.position.x;
        ExitPosY = ActualRoom.transform.Find("TopExit").transform.position.y;
        EntryPosX = NextRoom.transform.position.x + NextRoom.transform.Find("BottomExit").transform.position.x;
        EntryPosY = NextRoom.transform.position.y + NextRoom.transform.Find("BottomExit").transform.position.y;

        NextRoom.transform.position = new Vector3(ExitPosX - EntryPosX, ExitPosY - EntryPosY);
        Destroy(ActualRoom);
        ActualRoom = NextRoom;
    }
    public void SpawnRoomBottom()
    {
        NextRoom = Rooms[Random.Range(0, Rooms.Count)];
        NextRoom = Instantiate(NextRoom);

        ExitPosX = ActualRoom.transform.Find("BottomExit").transform.position.x;
        ExitPosY = ActualRoom.transform.Find("BottomExit").transform.position.y;
        EntryPosX = NextRoom.transform.position.x + NextRoom.transform.Find("TopExit").transform.position.x;
        EntryPosY = NextRoom.transform.position.y + NextRoom.transform.Find("TopExit").transform.position.y;

        NextRoom.transform.position = new Vector3(ExitPosX - EntryPosX, ExitPosY - EntryPosY);
        Destroy(ActualRoom);
        ActualRoom = NextRoom;
    }

    public void SpawnPlayers()
    {
        Vector2 SpawnPos1 = ActualRoom.transform.Find("SpawnPlayer1").position;
        Vector2 SpawnPos2 = ActualRoom.transform.Find("SpawnPlayer2").position;
        Player1.transform.position = SpawnPos1;
        Player2.transform.position = SpawnPos2;
    }

    public void MoveCamera()
    {
        Vector3 target = ActualRoom.transform.Find("CamPos").position;
        target.z = -15f;
        Cam.transform.position = Vector3.Lerp(Cam.transform.position, target, CamSpeed * Time.deltaTime);
        //Cam.transform.position = target;
    }
}
