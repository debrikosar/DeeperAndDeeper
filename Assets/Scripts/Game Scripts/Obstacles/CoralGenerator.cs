using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralGenerator : MonoBehaviour
{
    public Sprite[] coralSprites;

    private void Start()
    {
        Transform[] allChildren = this.gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.tag == "Coral")
                child.gameObject.GetComponent<SpriteRenderer>().sprite = coralSprites[Random.Range(0, coralSprites.Length - 1)];
        }
    }
}
