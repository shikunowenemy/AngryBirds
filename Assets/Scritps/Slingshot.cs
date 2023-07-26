using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] BirdsQueue birdsQueue;
    [SerializeField] private Transform jointPoint;
    [SerializeField] float spring;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform building;
    [SerializeField] int secondsToSpawnUnit;

    private Vector3 _mousePosition;

    private SpringJoint _springJoint;

    private Rigidbody _currentBirdRb;

    private bool _isPressed;

    private void Start()
    {
        StartCoroutine(SetBird());
    }

    private void OnMouseDown()
    {
        if (_currentBirdRb == null) return;
        _isPressed = true;
    }

    private void OnMouseUp()
    {
        if (_currentBirdRb == null) return;

        _isPressed = false;
        _currentBirdRb.isKinematic = false;
        if (Vector3.Distance(_currentBirdRb.position, jointPoint.position) < 1f) return;
        Destroy(_springJoint, 0.125f);
        StartCoroutine(SetBird(secondsToSpawnUnit));
    }

    private void FixedUpdate()
    {
        if (!_isPressed) return;

        _mousePosition = Input.mousePosition;
        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(_mousePosition + Vector3.forward * Mathf.Abs(mainCamera.transform.position.z));
        _currentBirdRb.position = worldPoint;
    }

    private IEnumerator SetBird()
    {
        _currentBirdRb = birdsQueue.GetBird();
        _springJoint = jointPoint.AddComponent<SpringJoint>();
        _springJoint.spring = spring;
        _currentBirdRb.transform.position = jointPoint.transform.position;
        _currentBirdRb.transform.LookAt(building);
        _springJoint.connectedBody = _currentBirdRb;
        yield return null;
    }

    private IEnumerator SetBird(int secondsToSpawn)
    {
        yield return new WaitForSeconds(secondsToSpawn);
        _currentBirdRb = birdsQueue.GetBird();
        _springJoint = jointPoint.AddComponent<SpringJoint>();
        _springJoint.spring = spring;
        _currentBirdRb.transform.position = jointPoint.transform.position;
        _currentBirdRb.transform.LookAt(building);
        _springJoint.connectedBody = _currentBirdRb;
    }
}
