using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class ScoreDetector : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawnTransform;
    public float startingForceMultiply = 3;
    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public TextMeshProUGUI leftTextScore;
    public TextMeshProUGUI rightTextScore;
    public float paddleScaleMod = 0.9f;
    public float ogX = 1;
    public float ogY = 1;
    public float ogZ = 8f;
    public GameObject winText;
    public GameObject leftWin;
    public GameObject rightWin;
    public int winScore = 11;

    private void Start()
    {
        leftTextScore.text = "0";
        rightTextScore.text = "0";
        leftWin.SetActive(false);
        rightWin.SetActive(false);
        winText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Score!");
        other.gameObject.SetActive(false);
        if (this.gameObject.name == "LeftScoreZone")
        {
            if (SetRightPlayerScore())
            {
                Transform transform = rightPaddle.transform;
                float newZScale = transform.localScale.z * paddleScaleMod;
                rightPaddle.transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y, newZScale);
                Object newBall = spawnBall();
                Vector3 startingVelocity = new Vector3(0, 0, 1 * startingForceMultiply);
                newBall.GetComponent<Rigidbody>().velocity = startingVelocity;
                return;
            }
            else
            {
                StartCoroutine(newGame("right"));
            }
            
        }
        else
        {
            if (SetLeftPlayerScore())
            {
                Transform transform = leftPaddle.transform;
                float newZScale = transform.localScale.z * paddleScaleMod;
                leftPaddle.transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y, newZScale);
                Object newBall = spawnBall();
                Vector3 startingVelocity = new Vector3(0, 0, -1 * startingForceMultiply);
                newBall.GetComponent<Rigidbody>().velocity = startingVelocity; 
                return;
            }
            else
            {
                StartCoroutine(newGame("left"));
            }
        }
    }

    private IEnumerator newGame(String winner)
    {
        yield return waitForKeyPress();
        resetGame();
        Object newBall = spawnBall();
        if (winner == "left")
        {
            Vector3 startingVelocity = new Vector3(0, 0, -1 * startingForceMultiply); 
            newBall.GetComponent<Rigidbody>().velocity = startingVelocity;
        }
        else if (winner == "right")
        {
            Vector3 startingVelocity = new Vector3(0, 0, 1 * startingForceMultiply); 
            newBall.GetComponent<Rigidbody>().velocity = startingVelocity;
        }    
    }

  
    
    private IEnumerator waitForKeyPress()
    {
        bool done = false;
        while (!done)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                done = true;
            }
            yield return null;
        }
    }

    private void resetGame()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        winText.SetActive(false);
        leftWin.SetActive(false);
        rightWin.SetActive(false);
        leftTextScore.SetText("0");
        rightTextScore.SetText("0");
        leftPaddle.transform.localScale = new Vector3(ogX, ogY, ogZ);
        rightPaddle.transform.localScale = new Vector3(ogX, ogY, ogZ);
    }
    private Object spawnBall()
    {
        float randomPos = Random.Range(0, 15);
        Vector3 position = new Vector3(ballSpawnTransform.position.x - randomPos, ballSpawnTransform.position.y, ballSpawnTransform.position.z);
        Object newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        return newBall;
    }
    private bool SetLeftPlayerScore()
    {
        leftPlayerScore++;
        leftTextScore.text = leftPlayerScore.ToString();
        if (leftPlayerScore == winScore)
        {
            Debug.Log("WINCON MET");
            leftWin.SetActive(true);
            winText.SetActive(true);
            return false;
        }
        return true;
    }

    private bool SetRightPlayerScore()
    {
        rightPlayerScore++;
        rightTextScore.text = rightPlayerScore.ToString();
        if (rightPlayerScore == winScore)
        {
            rightWin.SetActive(true);
            winText.SetActive(true);
            return false;
        }
        return true;
    }
}
