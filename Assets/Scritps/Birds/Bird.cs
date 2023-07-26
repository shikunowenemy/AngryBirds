using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Unit
{
    protected void DestroyBird(Collision collision)
    {
        if (collision.gameObject.tag != "Slingshot" && isFirstCollision)
        {
            StartCoroutine(Die());
            levelProgress.BirdsCount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBird(collision);
    }
}
