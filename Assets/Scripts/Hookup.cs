using UnityEngine;

public class Hookup : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Keggy" && Input.GetKeyDown(KeyCode.C))
        {
            GameObject keggy = collision.gameObject;
            keggy.GetComponent<DistanceJoint2D>().connectedBody = gameObject.GetComponent<DistanceJoint2D>().connectedBody;
            Destroy(gameObject);
        }
    }
}
