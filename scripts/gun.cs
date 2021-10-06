using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    //gun stats
    public int fullmag = 2, bulletsPerTap;
    public int currentmag = 2;
    public int bulltesShot;
    public float firerate, spread, range, reloadtime;
    public decimal damage;
    public float bulletSpeed = .1f;
    public bool allowButtonHold;

    //bools
    bool shooting, readyToshoot, Reloading;

    //references
    public Camera fpscam;
    public Transform attackpoint;
    public RaycastHit rayHit;
    public LayerMask whitIsEnemy;

    [SerializeField] KeyCode reload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
        
        
}

