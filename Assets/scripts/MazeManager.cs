using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private float _CooldownTime = 3.0f;

    [SerializeField] private GameObject _mazePlayer1;
    [SerializeField] private GameObject _mazePlayer2;

    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;

    private Vector3 _player1SpawnPoint;
    private Vector3 _player2SpawnPoint;

    private Vector3 _player1End;
    private Vector3 _player2End;

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

        _player1SpawnPoint = _mazePlayer1.gameObject.transform.GetChild(1).gameObject.transform.position;
        _player2SpawnPoint = _mazePlayer2.gameObject.transform.GetChild(1).gameObject.transform.position;
        
        StartCoolDown("Player1");
        StartCoolDown("Player2");
    }


    public IEnumerator SpawnCount(string playerTag)
    {
        ToggleWallVisibility(playerTag);
        TogglePlayerMovement(playerTag);

        yield return new WaitForSeconds(_CooldownTime); 
        
        ToggleWallVisibility(playerTag);
        TogglePlayerMovement(playerTag);
    }

    public void StartCoolDown(string playerTag)
    {
        if(playerTag == "Player1")
        {
            RespawnPlayer(playerTag);
            StartCoroutine(SpawnCount(playerTag));

        } else if(playerTag == "Player2")
        {
            RespawnPlayer(playerTag);
            StartCoroutine(SpawnCount(playerTag));
        }
    }


    public void RespawnPlayer(string playerTag)
    {
        if(playerTag == "Player1")
        {
            _player1.transform.position = _player1SpawnPoint;

        } 
        else if(playerTag == "Player2")
        {
            _player2.transform.position = _player2SpawnPoint;
        }
    }

    private void TogglePlayerMovement(string playerTag)
    {
        PlayerMovementTEMPORARIO playerMovement;

        if(playerTag == "Player1")
        {
            playerMovement = _player1.GetComponent<PlayerMovementTEMPORARIO>();
        } 
        else if(playerTag == "Player2")
        {
            playerMovement = _player2.GetComponent<PlayerMovementTEMPORARIO>();
        }
        else
        {
            return;
        }

        if(playerMovement.enabled)
        {
            playerMovement.enabled = false;
        } 
        else {
            playerMovement.enabled = true;
        }
    }

    private void ToggleWallVisibility(string playerTag)
    {
        List<SpriteRenderer> wallsOfMaze;

        if(playerTag == "Player1")
        {
            wallsOfMaze = _wallsMazePlayer1;
        } else if(playerTag == "Player2")
        {
            wallsOfMaze = _wallsMazePlayer2;
        } else {
            return;
        }


        foreach(SpriteRenderer wall in wallsOfMaze)
        {
            if(wall.enabled == true)
            {
                wall.enabled = false;
            }
            else 
            {
                wall.enabled = true;
            }
        }
    }
}
