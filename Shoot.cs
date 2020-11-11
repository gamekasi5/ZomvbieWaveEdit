using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Animator anim;

    public Transform firePoint;
    public Transform firePoint2;

    public GameObject bulletPrefab;
    public GameObject grenadesPrefab;

    public GameObject GameReloadtxt;

    public Text txtBoxMaxBullet;
    public Text txtBoxcurrentBullet;

    public float bulletForce = 20f;
    public float grenadesForce = 20f;


    private int MaxBullet_Pistol = 6;
    private int MaxBullet_Rifel = 30;
    private int MaxBullet_Shotgun = 18;
    private int N_MaxBullet;

    private int currentBullet_Pistol = -1;    
    private int currentBullet_Rifel = -1;
    private int currentBullet_Shotgun = -1;
    private int N_currentBullet;

    

    public float reloadTime = 1f;

    bool IsReLoading = false;
    public static bool IsThrowinggrenades = false;

    public static int ChangWeapon;
    private int BasicWeapon = 0;

    private float timeBtShots;
    public float Pistol_starttimeBtShots;
    public float Rifel_starttimeBtShots;
    public float Shotgun_starttimeBtShots;



    void Start()
    {
        anim = GetComponent<Animator>();
        ChangWeapon = BasicWeapon;
        Debug.Log("Changweapon =" + ChangWeapon );

        if (currentBullet_Pistol == -1)
            currentBullet_Pistol = MaxBullet_Pistol;

        if (currentBullet_Rifel == -1)
            currentBullet_Rifel = MaxBullet_Rifel;

        if (currentBullet_Shotgun == -1)
            currentBullet_Shotgun = MaxBullet_Shotgun;

        GameReloadtxt.gameObject.SetActive(false);
    }


    void Update()
    {
        if (ChangWeapon >= 3)
            ChangWeapon = 0;


        switch (ChangWeapon)
        {
            case 0:
                Pistol();
                break;
            case 1:
                Rifel();
                break;
            case 2:
                Shotgun();
                break;
        }

        if(IsThrowinggrenades == true)
        {
            Throwinggrenades();
            IsThrowinggrenades = false;
        }

        TextBox();

    }


    void Pistol()
    {       

        N_currentBullet = currentBullet_Pistol;
        N_MaxBullet = MaxBullet_Pistol;

        Debug.Log(" N_currentBullet == " + N_currentBullet);
        Debug.Log("N_MaxBullet ==" + N_MaxBullet);

        if (IsReLoading)
            return;

        if (N_currentBullet <= 0)
        {
            GameReloadtxt.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReloadBullet());
                anim.SetInteger("state", 2);
                GameReloadtxt.gameObject.SetActive(false);
                return;
            }

        }

        if (timeBtShots <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (N_currentBullet > 0)
                {                  
                    Shootfire();
                    anim.SetInteger("state", 3);
                    currentBullet_Pistol--;
                    timeBtShots = Pistol_starttimeBtShots;
                }
            }
        }

        else
        {
            timeBtShots -= Time.deltaTime;
        }
    }

    void Rifel()
    {

        N_currentBullet = currentBullet_Rifel;
        N_MaxBullet = MaxBullet_Rifel;

        if (IsReLoading)
            return;

        if (N_currentBullet <= 0)
        {
            GameReloadtxt.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReloadBullet());
                anim.SetInteger("stateii", 2);
                GameReloadtxt.gameObject.SetActive(false);
                return;
            }

        }

        if (timeBtShots <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (N_currentBullet > 0)
                {
                    Shootfire();
                    anim.SetInteger("stateii", 3);
                    currentBullet_Rifel--;
                    timeBtShots = Rifel_starttimeBtShots;
                }
            }
        }

        else
        {
            timeBtShots -= Time.deltaTime;
        }
    }

    void Shotgun()
    {
        N_currentBullet = currentBullet_Shotgun;
        N_MaxBullet = MaxBullet_Shotgun;

        if (IsReLoading)
            return;

        if (N_currentBullet <= 0)
        {
            GameReloadtxt.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReloadBullet());
                anim.SetInteger("stateiii", 2);
                GameReloadtxt.gameObject.SetActive(false);
                return;
            }

        }

        if (timeBtShots <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (N_currentBullet > 0)
                {
                    Shootfire();
                    Shootfire2();
                    anim.SetInteger("stateiii", 3);
                    currentBullet_Shotgun -= 2;
                    timeBtShots = Shotgun_starttimeBtShots;
                }
            }
        }

        else
        {
            timeBtShots -= Time.deltaTime;
        }
    }

    void Shootfire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }
    void Shootfire2()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }

    void Throwinggrenades()
    {
        GameObject grenades = Instantiate(grenadesPrefab, firePoint.position, firePoint.rotation); 
        Destroy(grenades, 5f);
    }
    IEnumerator ReloadBullet()
    {
        IsReLoading = true;
        Debug.Log("Reload...");
        yield return new WaitForSeconds(reloadTime);

        switch (ChangWeapon)
        {
            case 0:
                currentBullet_Pistol = MaxBullet_Pistol;
                break;
            case 1:
                currentBullet_Rifel = MaxBullet_Rifel;
                break;
            case 2:
                currentBullet_Shotgun = MaxBullet_Shotgun;
                break;
        }

        IsReLoading = false;
    }

    void TextBox()
    {
        
        txtBoxMaxBullet.text = N_MaxBullet.ToString();
        txtBoxcurrentBullet.text = N_currentBullet.ToString();
        
    }
}
