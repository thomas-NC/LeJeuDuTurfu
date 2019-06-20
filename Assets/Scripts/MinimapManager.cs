using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script qui s'occupe d'afficher le bon sprite dans la case où se trouvent les joueurs
public class MinimapManager : MonoBehaviour
{
    public Sprite PlayersAreHere;
    public List<GameObject> MinimapRooms = new List<GameObject>();
    
    public void MinimapMove()
    {
        foreach  (GameObject MinimapRoom in MinimapRooms)
        {
            if (MinimapRoom.GetComponent<MinimapRoom>().posX == GameManager.MinimapPosX && MinimapRoom.GetComponent<MinimapRoom>().posY == GameManager.MinimapPosY)
            {
                MinimapRoom.GetComponent<Image>().sprite = PlayersAreHere;
            }
            else
            {
                MinimapRoom.GetComponent<Image>().sprite = null;
            }
        }
    }
}
