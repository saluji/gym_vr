using UnityEngine;

/// <summary>
/// Erm�glicht das Durschalten einer Liste von GameObjects (z.B. Dialogen)
/// </summary>
public class PageFlip : MonoBehaviour
{
    // Liste mit der Seiten
    public GameObject[] pages;

    // Soll das Men� beim Start ge�ffnet werden
    public bool isOpenOnStart;

    // Welche Seite ist aktiv
    public int PageIndex { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Sicherstellen das immer mit der ersten Seite gestartet wird
        ShowPage(0);

        // Zum Start ge�ffnet?
        if (!isOpenOnStart) 
        {
            Close();
        }
    }

    /// <summary>
    /// Zeige eine bestimmte "Seite" an 
    /// </summary>
    /// <param name="pageIndex">Index beginnend bei 0 der zu�ffnenden Seite.</param>
    public void ShowPage(int pageIndex) 
    {
        Close();
        pages[pageIndex]?.SetActive(true);
        PageIndex = pageIndex;
    }

    /// <summary>
    /// Zeige die n�chste "Seite" an und beginne von vorne oder schlie�e alle "Seiten".
    /// </summary>
    public void Next()
    {
        // Bereits am Ende angekommen?
        if (PageIndex >= pages.Length - 1)
        {
            return;
        }

        // Index erh�hen
        PageIndex++;

        // Ge�ffnete Seite(n) schlie�en
        Close();

        // Neue Seite �ffnen
        pages[PageIndex].SetActive(true);
    }

    /// <summary>
    /// Schlie�t alle "Seiten".
    /// </summary>
    public void Close() 
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
    }

}
