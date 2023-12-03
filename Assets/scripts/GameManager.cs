using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPositions;

    [SerializeField] private GameObject cueBall;

    [SerializeField] private GameObject ballline;
    [SerializeField] private float xInput;

    [SerializeField] private float force;

    [SerializeField] private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        camera = Camera.main.gameObject;
        CameraBehindBall();
        
        SetBalls(BallColors.White, 0);
        SetBalls(BallColors.Red, 1);
        SetBalls(BallColors.Yellow, 2);
        SetBalls(BallColors.Green, 3);
        SetBalls(BallColors.Brown, 4);
        SetBalls(BallColors.Blue, 5);
        SetBalls(BallColors.Pink, 6);
        SetBalls(BallColors.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootball();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StopBall();
        }
        
    }

    void SetBalls(BallColors color, int pos)
    {
       GameObject ball = Instantiate(ballPrefab, ballPositions[pos].transform.position,Quaternion.identity);
       ball b = ball.GetComponent<ball>();
       b.SetColorAndPoint(color);
    }

    void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput/5,0f));
    }

    void shootball()
    {
        camera.transform.parent = null;
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * force,ForceMode.Impulse);
        ballline.SetActive(false);
    }

    void CameraBehindBall()
    {
        
        camera.transform.parent = cueBall.transform;
        camera.transform.position = cueBall.transform.position + new Vector3(0f, 40, - 20f);
    }

    void StopBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.velocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;
        CameraBehindBall();
        camera.transform.eulerAngles = new Vector3(40f, 0f, 0f);
        ballline.SetActive(true);
    }
}
