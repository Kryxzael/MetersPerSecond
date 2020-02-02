using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image LogoImage;

    public float Attack;
    public float Sustain;
    public float Release;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        LogoImage.color = new Color(1f, 1f, 1f, 0f);

        while (LogoImage.color.a < 1f)
        {
            LogoImage.color = new Color(1f, 1f, 1f, LogoImage.color.a + Attack);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(Sustain);

        while (LogoImage.color.a > 0f)
        {
            LogoImage.color = new Color(1f, 1f, 1f, LogoImage.color.a - Release);
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene(1);
    }
}
