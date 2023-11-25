using System.Collections;
using UnityEngine;

public class UISplatter : MonoBehaviour
{
    [SerializeField] float impactTime = 0.3f;
    Canvas slashCanvas;

    private void Start()
    {
        slashCanvas = GameObject.FindGameObjectWithTag("SlashCanvas").GetComponent<Canvas>();
        slashCanvas.enabled = false;
    }

    public void showSlashCanvas()
    {
        StartCoroutine(showSlash());
    }

    private IEnumerator showSlash()
    {
        slashCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        slashCanvas.enabled = false;
    }
}
