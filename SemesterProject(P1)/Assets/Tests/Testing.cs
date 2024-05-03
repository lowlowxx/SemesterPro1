using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Testing
{
    [UnityTest]
    public IEnumerator PlayerMove_Left()
    {
        SceneManager.LoadScene("Level 1");

        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.Find("Player");

        float originalPosition = player.transform.position.x;
        player.GetComponent<PlayerMovement>().MoveLeft();
        Assert.IsTrue(player.transform.position.x < originalPosition);

    }

    [UnityTest]
    public IEnumerator PlayerMove_Right()
    {
        SceneManager.LoadScene("Level 1");

        yield return new WaitForSeconds(1f);
        GameObject player = GameObject.Find("Player");

        float originalPosition = player.transform.position.x;
        player.GetComponent<PlayerMovement>().MoveRight();
        Assert.IsTrue(player.transform.position.x > originalPosition);

    }

    [UnityTest]
    public IEnumerator Player_Jumping()
    {
        SceneManager.LoadScene("Level 1");

        yield return new WaitForSeconds(.3f);
        GameObject player = GameObject.Find("Player");

        float originalPosition = player.transform.position.y;
        player.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        player.GetComponent<PlayerMovement>().PlayerJumping();

        yield return new WaitForSeconds(2f);

        Assert.IsTrue(player.transform.position.y > originalPosition);
    }


    [UnityTest]
    public IEnumerator NextSceneLoaded_OnCompleteLevel()
    {
        SceneManager.LoadScene("Level 1");

        yield return new WaitForSeconds(1f);
        GameObject finish = GameObject.Find("Finish");

        finish.GetComponent<Finish>().CompleteLevel();

        yield return new WaitForSeconds(1f); // Adjust the delay as needed

        Assert.IsTrue(SceneManager.GetActiveScene().name == "Level 2");

    }

    [UnityTest]
    public IEnumerator PickUpItems_Test()
    {
        SceneManager.LoadScene("Level 2");
        yield return new WaitForSeconds(1f);

        GameObject GrapeKey = GameObject.Find("GrapeKey");
        GameObject player = GameObject.Find("Player");

        player.transform.position = GrapeKey.transform.position;
        yield return new WaitForSeconds(1f);

        Assert.IsTrue(GrapeKey.GetComponent<KeyBehavior>().isPickedUp);

    }

}
