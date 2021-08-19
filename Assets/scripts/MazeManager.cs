using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private float _wallsShowTime = 2.0f;

    [SerializeField] private GameObject _mazePlayer1;
    [SerializeField] private GameObject _mazePlayer2;

    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;

    private List<SpriteRenderer> _wallsMazePlayer1;
    private List<SpriteRenderer> _wallsMazePlayer2;

    void Start()
    {
        _wallsMazePlayer1 = new List<SpriteRenderer>();
        _wallsMazePlayer2 = new List<SpriteRenderer>();
        
        foreach(Transform child in _mazePlayer1.gameObject.transform.GetChild(0).gameObject.transform)
        {
            _wallsMazePlayer1.Add(child.gameObject.GetComponent<SpriteRenderer>());
        }

        foreach (Transform child in _mazePlayer2.gameObject.transform.GetChild(0).gameObject.transform)
        {
            _wallsMazePlayer2.Add(child.gameObject.GetComponent<SpriteRenderer>());
        }

        _player1.transform.position = _mazePlayer1.gameObject.transform.GetChild(1).gameObject.transform.position;
        _player2.transform.position = _mazePlayer2.gameObject.transform.GetChild(1).gameObject.transform.position;
        
        StartCoroutine(SpawnCount());
    }


    public IEnumerator SpawnCount()
    {
        FrozePlayer1(true);
        FrozePlayer2(true);

        yield return new WaitForSeconds(_wallsShowTime); 
        
        WallsVisibilityPlayer1(false);
        WallsVisibilityPlayer2(false);

        FrozePlayer1(false);
        FrozePlayer2(false);
    }

    private void WallsVisibilityPlayer1(bool visible)
    {
        foreach(SpriteRenderer wall in _wallsMazePlayer1)
        {
            wall.enabled = visible;
        }
    }

    private void WallsVisibilityPlayer2(bool visible)
    {
        foreach (SpriteRenderer wall in _wallsMazePlayer2)
        {
            wall.enabled = visible;
        }
    }

    private void FrozePlayer1(bool frozen)
    {
        _player1.GetComponent<PlayerMovementTEMPORARIO>().enabled = !frozen;
    }

    private void FrozePlayer2(bool frozen)
    {
        _player2.GetComponent<PlayerMovementTEMPORARIO>().enabled = !frozen;
    }
    
}
