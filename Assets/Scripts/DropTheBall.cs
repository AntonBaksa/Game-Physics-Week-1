using System.Collections;
using UnityEngine;

public class DropTheBall : MonoBehaviour
{
    public class WaitForSleep : CustomYieldInstruction
    {
        Rigidbody2D rb;

        public WaitForSleep(Rigidbody2D DropBall)
        {
            rb = DropBall;
        }

        public override bool keepWaiting
        {
            get
            {
                return rb.IsAwake() &&
                       rb.transform.position.y > -20.0f;
            }
        }
    }

    [SerializeField] private GameObject BallToDrop;
    [SerializeField] private Transform DropPoint;

    private bool bCanDrop = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bCanDrop)
        {
            GameObject DropBall = Instantiate(BallToDrop, DropPoint.position, Quaternion.identity);

            Rigidbody2D rb = DropBall.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = 0;
            }

            bCanDrop = false;

            Debug.Log("Space key pressed");
            StartCoroutine(DestroyDropBall(rb));
            StartCoroutine(DropCoolDown());
        }
    }

    IEnumerator DropCoolDown()
    {
        yield return new WaitForSeconds(2f);

        bCanDrop = true;
    }

    IEnumerator DestroyDropBall(Rigidbody2D DropBall)
    {
        yield return new WaitForSleep(DropBall);

        Destroy(DropBall.gameObject);
    }

    private void OnGUI()
    {
        Rect r = new Rect(10, 10, 600, 64);
        GUI.color = Color.white;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 30; 
        style.fontStyle = FontStyle.Bold; 

        GUI.Label(r, "Press Space to Drop Ball", style);
    }
}
