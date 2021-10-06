using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float walkingSpeed = 10.0f;
    [SerializeField] float firerate = 1.0f;
    [SerializeField] decimal health = 100;
    [SerializeField] decimal damage = 20;
    [SerializeField] float accuracy = 100;


    bool meleeRange = false;
    decimal meleeDamage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
