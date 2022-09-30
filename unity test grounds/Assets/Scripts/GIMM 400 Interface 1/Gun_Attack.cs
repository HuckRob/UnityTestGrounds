using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Networking.Types;

public class Gun_Attack : MonoBehaviour , IProjectile
{
    public GameObject projectile;
    public GameObject Enemy_Projectile;
    public GameObject AI;
    private Enemy_AI enemyAI;           //linking to the enemy AI script
    public Gun_Attack gun_Attack;
    public float _projDamage => throw new System.NotImplementedException();

    public float _projSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("on trigger working");
        if (collision.CompareTag("ai"))
        {
            enemyAI = collision.gameObject.GetComponent<Enemy_AI>();
            enemyAI.TakeDamage(enemyAI._damage);
            GameObject.Find("AI").GetComponent<Enemy_AI>().TakeDamage(10);
            Debug.Log("Damage Taken: " + enemyAI._damage);
        }
        
    }
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
        GameObject Proj = Instantiate(projectile, AI.transform.position, AI.transform.rotation);
        Proj.GetComponent<Rigidbody>().AddForce(projDirection * Time.deltaTime);
        Proj.AddComponent <Gun_Attack> ();
        

    }

    // Start is called before the first frame update
    void Start()
    {
        gun_Attack = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
