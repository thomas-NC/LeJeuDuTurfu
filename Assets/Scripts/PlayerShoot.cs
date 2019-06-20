using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform Pivot;
    public float ProjectileSpeed;
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    private bool canShoot = true;
    public float ReloadTime;

    public List<GameObject> Projectiles = new List<GameObject>();

    public Animator anim;
    public string PlayerInputTag;

    // Update is called once per frame
    void Update()
    {
        PivotPosition();
        Shoot();
        
        //Debug.Log(Input.GetKey("joystick button " + test));
    }

    IEnumerator ShootReload()
    {
        yield return new WaitForSeconds(ReloadTime);
        canShoot = true;
    }
    public void Shoot()
    {
        if (Input.GetButton(PlayerInputTag + " Shoot") && canShoot)
        {
            canShoot = false;
            GameObject projectile = Projectiles[Random.Range(0, Projectiles.Count)];
            projectile = Instantiate(projectile);
            projectile.transform.position = GameObject.Find("BulletSpawn" + PlayerInputTag).transform.position;
            projectile.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - transform.parent.parent.position )* ProjectileSpeed);
            StartCoroutine(ShootReload());
        }
    }
    public void PivotPosition()
    {
        up = Input.GetButton(PlayerInputTag + " Right Joystick Up");
        down = Input.GetButton(PlayerInputTag + " Right Joystick Down");
        left = Input.GetButton(PlayerInputTag + " Right Joystick Left");
        right = Input.GetButton(PlayerInputTag + " Right Joystick Right");
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("left", false);
        anim.SetBool("right", false);

        if (up && !right && !left)
        {
            Pivot.eulerAngles = new Vector3(0, 0, 180);
            anim.SetBool("up", true);
        }
        else if (up && right && !left)
        {
            Pivot.eulerAngles = new Vector3(0, 0, 135);
            anim.SetBool("up", true);
            anim.SetBool("right", true);
        }
        else if (up && !right && left)
        {
            Pivot.eulerAngles = new Vector3(0, 0, 225);
            anim.SetBool("up", true);
            anim.SetBool("left", true);
        }
        else if (down && !right && !left)
        {
            Pivot.eulerAngles = new Vector3(0, 0, 0);
            anim.SetBool("down", true);
        }
        else if (down && right && !left)
        {
            Pivot.eulerAngles = new Vector3(0, 0, 45);
            anim.SetBool("down", true);
			anim.SetBool("right", true);
        }
        else if (down && !right && left)
        {
            Pivot.eulerAngles = new Vector3(0, 0, -45);
            anim.SetBool("down", true);
            anim.SetBool("left", true);
        }
        else if (left && !down && !up)
        {
            Pivot.eulerAngles = new Vector3(0, 0, -90);
            anim.SetBool("left", true);
        }
        else if (right && !down && !up)
        {
            Pivot.eulerAngles = new Vector3(0, 0, 90);
            anim.SetBool("right", true);
        }
    }
}
