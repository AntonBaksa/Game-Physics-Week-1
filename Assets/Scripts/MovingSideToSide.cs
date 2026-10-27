using UnityEngine;

public class MovingSideToSide : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float maxRight = 10.0f;
    [SerializeField] private float maxLeft = -10.0f;
    [SerializeField] private int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= maxRight)
        {
            direction = -1;
        }

        if(transform.position.x <= maxLeft)
        {
            direction = 1;
        }

        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
    }
}
