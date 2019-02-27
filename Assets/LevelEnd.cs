using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {


    public string SceneToLoad;

    private PlayerController player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            StartCoroutine(LevelEndCo());
        }
    }


    IEnumerator LevelEndCo() {
        player.canMove = false;
        player.rigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneToLoad);
        player.canMove = true;
    }
}
