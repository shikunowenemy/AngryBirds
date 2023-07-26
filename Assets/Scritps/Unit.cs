using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected LevelProgress levelProgress;
    [SerializeField] int secondsToDestroy;

    private protected bool isFirstCollision = true;
    protected IEnumerator Die()
    {
        isFirstCollision = false;
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(this.gameObject);
    }
}
