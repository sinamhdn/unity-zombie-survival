using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        // to make cursor visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
