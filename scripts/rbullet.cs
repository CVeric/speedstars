using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbullet : MonoBehaviour
{
    public float alivetime;
    public float damage;
    public float bulletSpeed;
    GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.Find("shootypart");
        gameObject.transform.rotation = bulletSpawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        checkhit();
    }


    void checkhit()
    {

    }
}
