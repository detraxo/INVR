using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
public class ChangeLanguage : MonoBehaviour
{
    public void changeLanguage(int i)
    {
        StartCoroutine(setLanguage(i));
    }
    public IEnumerator setLanguage(int i) {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }

}

