using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private Animator sceneTransitionAnimator;

    private void Start()
    {
        // Dapatkan referensi ke Animator pada SceneTransition
        GameObject sceneTransitionObject = GameObject.Find("SceneTransition");
        if (sceneTransitionObject != null)
        {
            sceneTransitionAnimator = sceneTransitionObject.GetComponent<Animator>();
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        if (sceneTransitionAnimator != null)
        {
            sceneTransitionAnimator.SetTrigger("StartTransition"); // Memulai animasi transisi
            yield return new WaitForSeconds(2); // Sesuaikan dengan durasi animasi transisi
        }

        SceneManager.LoadScene(sceneName);
        
        // Setelah scene dimuat, reset posisi Player
        yield return new WaitForSeconds(0.2f); // Tambahkan sedikit jeda
        ResetPlayerPosition();
    }

    private void ResetPlayerPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(0, 0, 0); // Set posisi awal
        }
    }
}





