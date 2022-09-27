using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_DVD_Logo : MonoBehaviour, IAttackAI, IProjectile
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


    public float _projDamage { get => _projDamage; set => _projDamage = projectileDamage; }
    public string _name { get => _name; set => _name = "DVD Logo"; }
    public float _health { get => _health; set => _health = _Vision / _Speed; }
    public float _Vision { get => _Vision; set => _Vision = vision; }
    public float _damage { get => _damage; set => _damage = _AttackRange / _fireRate; }
    public float _fireRate { get => _fireRate; set => _fireRate = fireRate; }
    public float _AttackRange { get => _AttackRange; set => _AttackRange = attackRange; }
    public float _Speed { get => _Speed; set => _Speed = speed; }
    public float _arenaRadius { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    //public float _shotTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float _projSpeed { get => _projSpeed; set => _projSpeed = projectileSpeed; }

    public void Attack(GameObject proj)
    {
        throw new System.NotImplementedException();
    }

    public void calculateSpeed()
    {
        throw new System.NotImplementedException();
    }

    public bool CanShoot()
    {
        throw new System.NotImplementedException();
    }

    public bool CheckValue()
    {
        if (_health >= .1 || _health <= 1)
        {
            Debug.LogException(new System.Exception("Health needs to be in between 10 and 90"));
            return false;
        }
        else if (_health != _Vision / _Speed)
        {
            Debug.LogException(new System.Exception("Review your health ratio(Health = Vision / Speed)"));
            return false;
        }
        if (_damage >= .1 || _damage <= 1)
        {
            Debug.LogException(new System.Exception("Health needs to be in between 2 and 10"));
            return false;
        }
        else if (_damage != _AttackRange / _fireRate)
        {
            Debug.LogException(new System.Exception("Review your damage ratio (Damage = Attack Range/ Fire Rate)"));
            return false;
        }
        if (_fireRate <= .1 || _fireRate >= 1)
        {
            Debug.LogException(new System.Exception("Fire Rate needs to be between .1 and 1"));
            return false;
        }
        if (_Speed <= .1 || _Speed >= 1)
        {
            Debug.LogException(new System.Exception("Speed needs to be between .1 and 1"));
            return false;
        }
        _health *= HEALTHMULTIPLIER;
        _damage *= STANDARDMULTIPLIER;
        _Speed *= STANDARDMULTIPLIER;
        _fireRate = 1 / (STANDARDMULTIPLIER * _fireRate);
        _Vision = _arenaRadius / (1 / _Vision);
        _AttackRange *= STANDARDMULTIPLIER;
        return true;

    }

    public void DealDamage()
    {
        throw new System.NotImplementedException();
    }

    public bool DeathCheck()
    {
        if (_health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void inheritDamage()
    {
        throw new System.NotImplementedException();
    }

    public void Move()

    {
        StartCoroutine("MoveRoutine");
    }

    public void shoot(Vector3 projDirection)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float amt)
    {
        throw new System.NotImplementedException();
    }


    //---------- Move Functions Start ---------
    private void ChangeDirection()
    {
        Vector3 newDirection = new Vector3(Random.Range(-bounceDegree, bounceDegree), 0, Random.Range(-bounceDegree, bounceDegree));
        direction = newDirection;
    }
    private bool ObjectInFront()
    {
        var ray = new Ray(this.transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayCastDistance))
        {
            Debug.Log("Hit " + hit.collider.name);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetRandomLocation()
    {
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
    }
    private IEnumerator MoveRoutine()
    {

        //Debug.Log("wander Routine");
        if (ObjectInFront())
        {
            ChangeDirection();
        }
        else
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        yield return new WaitForSeconds(updateTime);
    }
    //---------- Move Functions End ----------
    public void Start()
    {
        SetRandomLocation();
    }
    public void FixedUpdate()
    {
        //Move();

    }
}
