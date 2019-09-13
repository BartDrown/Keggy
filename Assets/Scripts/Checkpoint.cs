using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Sprite checkSprite, uncheckedSprite;
    public bool IsChecked { get; private set; }

    //private void OnCollisionStay2D(Collision2D collision)
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsChecked = true;
        GetComponent<SpriteRenderer>().sprite = checkSprite;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsChecked = false;
        GetComponent<SpriteRenderer>().sprite = uncheckedSprite;
    }
}
