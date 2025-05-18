using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FallingScript : MonoBehaviour
{
    [SerializeField] private bool isFalling=false;
    [SerializeField] private TimeCounter timeCounter;
    [SerializeField] private TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        timeCounter = GameObject.Find("TimeCounter").GetComponent<TimeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            textMesh.text = "Press Enter to Restart";
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            isFalling = true;
            
        }
    }
}
