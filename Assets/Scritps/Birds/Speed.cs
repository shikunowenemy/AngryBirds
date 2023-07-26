using UnityEngine;

public class Speed : Bird
{
    [SerializeField] float speedIncrease;

    private bool _isSpeeded;

    private void OnMouseDown()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic || _isSpeeded) return;
        gameObject.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speedIncrease);
        _isSpeeded = true;
        print("ds");
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBird(collision);
    }
}
