using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            FindAnyObjectByType<WordManager>().AllWordCollected(); 
            Destroy(gameObject, 0.5f);
        }
    }
}
