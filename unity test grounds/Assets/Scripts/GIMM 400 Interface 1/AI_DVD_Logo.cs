using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_DVD_LOGO : Contenders
{
    //Move Variables
    public float rayCastDistance = 1.0f;
    public GameObject Character;
    private Vector3 direction = new Vector3();
    [SerializeField] private float bounceDegree = 15.0f;
    [SerializeField] private float updateTime = 0.5f;

    [SerializeField] private float vision = 10.0f;
    [SerializeField] private float projectileDamage = 10.0f;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private float attackRange = 5.0f;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float arenaRadius = 10.0f;
    [SerializeField] private float projectileSpeed = 10.0f;

    public override float _projDamage { get => projectileDamage; }

    public override string _name { get => _name; set => _name = "DVD Logo"; }
    public override float _health { get => _health; set => _health = _Vision / _Speed; }
    private static float HEALTHMULTIPLIER = 100;
    public override float _Vision { get => _Vision; set => _Vision = vision; }
    public override float _damage { get => _damage; set => _damage = _AttackRange / _fireRate; }
    private static float STANDARDMULTIPLIER = 10;
    public override float _fireRate { get => _fireRate; set => _fireRate = fireRate; }
    public override float _AttackRange { get => _AttackRange; set => _AttackRange = attackRange; }
    public override float _Speed { get => _Speed; set => _Speed = speed; }
    public override float _arenaRadius { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public override void Attack(GameObject proj)
    {
        throw new System.NotImplementedException();
    }

    public override void calculateSpeed()
    {
        throw new System.NotImplementedException();
    }

    public override bool CanShoot()
    {
        throw new System.NotImplementedException();
    }

    public override void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void inheritDamage()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void shoot(Vector3 projDirection)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
