using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	public int Life;
	public int Speed;
	public int Touche;
    public bool IsDead;
	public Sprite DeathFrame;

    public List<GameObject> Hearts = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
		if (Life <= 0)
		{
            IsDead = true;
            GetComponent<SpriteRenderer>().sprite = DeathFrame;
            GetComponent<PlayerMovement>().enabled = false;
            transform.Find("Pivot").transform.Find("TargetShoot").GetComponent<PlayerShoot>().enabled = false;
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = true;
            transform.Find("Pivot").transform.Find("TargetShoot").GetComponent<PlayerShoot>().enabled = true;
        }
        Touche = 3 - Life;
        if (Touche == 1)
        {
            Hearts[2].GetComponent<Animator>().SetBool("Heart_Death", true);
        }
        if (Touche == 2)
        {
            Hearts[1].GetComponent<Animator>().SetBool("Heart_Death", true);
        }
        if (Touche == 3)
        {
            Hearts[0].GetComponent<Animator>().SetBool("Heart_Death", true);
        }
    }
}
