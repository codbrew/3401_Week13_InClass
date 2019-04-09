using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public Transform target;
    public float moveSpeed = 2;
    public float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }

    public void OnEnemyShot(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Enemy Dead");
        }
    }
}
