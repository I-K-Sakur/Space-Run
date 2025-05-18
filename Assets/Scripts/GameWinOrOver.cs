using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinOrOver : MonoBehaviour
{
    public bool gameWin = false;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            gameWin = true;
        }
    }
}
