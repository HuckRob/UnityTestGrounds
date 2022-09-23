using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class AI_Move : MonoBehaviour
{
    
    public float speed = 2.0f;
    public float rayCastDistance = 1.0f;
    public GameObject Character;
    private Vector3 direction = new Vector3();
    private int count = 0;
    [SerializeField] private float bounceDegree = 15.0f;
    [SerializeField] private float updateTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ChangeRandomDirection();
        StartCoroutine("WanderRoutine");
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }

    private void ChangeDirection()
    {
        Vector3 newDirection = new Vector3(Random.Range(-bounceDegree, bounceDegree), 0, Random.Range(-bounceDegree, bounceDegree));
        Debug.Log("Old Direction: " + direction);
        Debug.Log("New Direction: " + newDirection);

        direction = newDirection;
        //direction = -direction + newDirection;
        Debug.Log("Final Direction: " + direction);
    }


    private void ChangeRandomDirection()
    {
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
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

    private IEnumerator WanderRoutine()
    {

        //Debug.Log("wander Routine");
        if (ObjectInFront())
        {
            ChangeDirection();
            //ChangeRandomDirection();
        }
        else
        {
            count++;
            if (count > 20)
            {
                //ChangeRandomDirection();
                //Debug.Log(count);
                count = 0;
            }
        }
        yield return new WaitForSeconds(updateTime);
        StartCoroutine("WanderRoutine");
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);
    }
}
