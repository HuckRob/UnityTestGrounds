using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Networking.Types;

public class Gun_Attack : MonoBehaviour , IProjectile
{
    public GameObject projectile;  
    public GameObject AI;
    private Enemy_AI enemyAI;           //linking to the enemy AI script
    public float _projDamage => throw new System.NotImplementedException();

    public float _projSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void calculateSpeed()
    {
        throw new System.NotImplementedException();
    }

    public void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public void inheritDamage()
    {
        throw new System.NotImplementedException();
    }
    public void shoot(Vector3 projDirection)
    {
        Instantiate(projectile, AI.transform.position, AI.transform.rotation).GetComponent<Rigidbody>().AddForce(projectile.transform.forward * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
