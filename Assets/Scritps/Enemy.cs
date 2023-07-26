using UnityEngine;

public class Enemy : Unit
{

    protected void DestroyEnemy(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && isFirstCollision)
        {
            StartCoroutine(Die());
            levelProgress.EnemiesCount--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyEnemy(collision);
    }
}
