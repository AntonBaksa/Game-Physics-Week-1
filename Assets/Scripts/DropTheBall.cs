using UnityEngine;

public class DropTheBall : MonoBehaviour
{
    [SerializeField] private GameObject BallToDrop;
    [SerializeField] private Transform DropPoint;
    private GameObject DropBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            DropBall = Instantiate(BallToDrop, DropPoint);
            Debug.Log("Space key pressed");
        }
    }
}
