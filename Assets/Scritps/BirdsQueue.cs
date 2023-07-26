using System.Collections.Generic;
using UnityEngine;

public class BirdsQueue : MonoBehaviour
{
    [SerializeField] List<Rigidbody> birds;

    public Rigidbody GetBird()
    {
        if (birds.Count == 0) return null;
        Rigidbody bird = birds[0];
        birds.RemoveAt(0);
        return bird;
    }
}
