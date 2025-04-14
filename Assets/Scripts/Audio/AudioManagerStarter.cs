using UnityEngine;

public class AudioManagerStarter : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerPrefab;

    private void Awake()
    {
        if (AudioManager.Instance == null)
        {
            Instantiate(audioManagerPrefab);
        }
    }
}