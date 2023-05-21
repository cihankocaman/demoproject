using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class SoldierAI : MonoBehaviour
{
    private Vector3 target;
    private GameObject targetEnemy;
    private Path path;
    private int currentWaypoint = 0;
    private Camera cam;
    private Seeker seeker;
    private Rigidbody2D rb;
    private IAttack soldierAttack;

    public float speed;
    public float nextWaypointDistance;
    public bool reachedEndOfPath = false;
    public LayerMask enemyLayer;

    
    void Start()
    {
        cam = Camera.main;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        soldierAttack = GetComponent<IAttack>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (targetEnemy == null)
            {
                targetEnemy = CheckIfTargetEnemy();
            }
            
            DrawPath();
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;

            currentWaypoint = 0;
            path = null;

            if (targetEnemy != null)
            {
                soldierAttack.Attack(targetEnemy);
            }

            this.enabled = false;

            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        AddForceToSoldier();
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void DrawPath()
    {
        if (this.path == null)
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);
            seeker.StartPath(transform.position, new Vector3(target.x, target.y, transform.position.z), OnPathComplete);
        }
    }
    void AddForceToSoldier()
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
    private GameObject CheckIfTargetEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyLayer);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
