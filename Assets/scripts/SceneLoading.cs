using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            //Debug.Log("111");


            SceneManager.LoadScene(1);
            GameObject newPlayer = Instantiate(player, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        
    }
}
