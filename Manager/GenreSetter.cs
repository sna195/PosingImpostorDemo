using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenreSetter : MonoBehaviour
{
    [SerializeField] GenreTheme _genreTheme;

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = _genreTheme.Genre;
    }
}
