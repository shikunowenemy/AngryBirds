using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    private int _enemiesCount;
    private int _birdsCount;
    private int points;

    public int EnemiesCount
    {
        get { return _enemiesCount; }
        set
        {
            _enemiesCount = value;
            if (_enemiesCount == 0) Win();
        }
    }

    public int BirdsCount
    {
        get { return _birdsCount; }
        set
        {
            _birdsCount = value;
            if (_birdsCount == 0 && _enemiesCount > 0) Lose();
        }
    }
    private void Start()
    {
        _enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        _birdsCount = GameObject.FindGameObjectsWithTag("Bird").Length;
    }

    private void Win()
    {
        Debug.Log("Win");
    }

    private void Lose()
    {
        Debug.Log("Lose");
    }
}
