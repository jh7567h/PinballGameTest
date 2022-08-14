using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthersCheck : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blue")|| other.gameObject.CompareTag("Red")|| other.gameObject.CompareTag("Green")|| other.gameObject.CompareTag("Yellow"))
        {
            Destroy(other.gameObject);
        }

    }
}
