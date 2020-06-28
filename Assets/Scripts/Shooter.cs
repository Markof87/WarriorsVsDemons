using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile, source;

    private AttackerSpawner myLineSpawner;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        SetLineSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLine())
            animator.SetBool("IsAttacking", true);
        else
            animator.SetBool("IsAttacking", false);
    }

    public void Fire()
    {
        Instantiate(projectile, source.transform.position, source.transform.rotation);
    }

    private void SetLineSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
                myLineSpawner = spawner;
        }
    }

    private bool IsAttackerInLine()
    {
        if (myLineSpawner.transform.childCount <= 0)
            return false;

        else
            return true;
    }
}
