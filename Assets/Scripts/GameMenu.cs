using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    // Update is called once per frame
    void Update()
    {
        if(Player1.GetComponent<PlayerBehavior>().Life <= 0 || Player2.GetComponent<PlayerBehavior>().Life <= 0)
        {
            SceneManager.LoadScene("FinalGame");
        }
    }
}
