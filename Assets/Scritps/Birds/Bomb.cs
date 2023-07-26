using UnityEngine;

public class Bomb : Bird
{
    [SerializeField] float sizeIncrease;

    private bool _isBombed;
    private void OnMouseDown()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic || _isBombed) return;
        gameObject.transform.localScale += new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
        _isBombed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBird(collision);
    }
}
