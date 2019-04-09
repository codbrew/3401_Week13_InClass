using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public float fireRate = 2;
    public float turretDamage = 5;
    private float _currentReloadTimer = 0;
    private Transform _currentTarget;
    private List<Transform> _enemiesInRange;
    public Transform rotator;
    // Start is called before the first frame update
    void Start()
    {
        _enemiesInRange = new List<Transform>();
        _currentReloadTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {

        //if(_currentTarget != null)
        //{
        //    rotator.LookAt(_currentTarget);
        //}
        Transform closestEnemy = null;
        float closestDistance = 9999999;
        for (int i = 0; i < _enemiesInRange.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, _enemiesInRange[i].position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = _enemiesInRange [i];
            }
        }
        if (closestEnemy != null)
        {
            rotator.LookAt(closestEnemy);

            if(_currentReloadTimer > fireRate)
            {
                FireTurret(closestEnemy);
                _currentReloadTimer = 0;
            }

            _currentReloadTimer += Time.deltaTime;
        }

    }
    //
    void FireTurret(Transform enemyShot)
    {
        Debug.Log("BANG BANG");

        enemyShot.GetComponent<EnemyBehavior> ().OnEnemyShot(turretDamage);
    }


    //When Collision is detected 
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        //_currentTarget = other.transform;
        //add the enemy to list of enemies
        if (!_enemiesInRange.Contains(other.transform))
        {
            _enemiesInRange.Add(other.transform);
        }
       

    }
    private void OnTriggerExit(Collider other)
    {
        if (_enemiesInRange.Contains(other.transform))
        {
            _enemiesInRange.Remove(other.transform);
        }


    }
}
