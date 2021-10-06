using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rshotty : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject bullet;
    Transform _bullet;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }
    void fire()
    {
        _bullet = Instantiate(bullet.transform, bulletSpawn.transform.position, Quaternion.identity);
    }
}
