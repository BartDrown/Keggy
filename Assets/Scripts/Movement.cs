using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        rb.velocity = new Vector2(horizontal, vertical);
        //transform.position += new Vector3(horizontal, vertical);
    }
}
