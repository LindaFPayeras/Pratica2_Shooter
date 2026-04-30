using UnityEngine;
class WinZone : MonoBehaviour
{
    SceneLoader sceneLoader;

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Has ganado!");
            sceneLoader.GameOverWin();
        }
    }
}