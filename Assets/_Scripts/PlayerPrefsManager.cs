﻿using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    static string LANGUAGE_KEY, MUTE_KEY, FIRST_TIME_KEY,ONE_FIRST,EQUAL_FIRST,ESCAPE_FIRST,LAPSE_FIRST;

    void Start()
    {
        LANGUAGE_KEY = "LANGUAGE";
        MUTE_KEY = "MUTE";
        FIRST_TIME_KEY = "FIRST_TIME";
        ONE_FIRST = "onefirst";
        EQUAL_FIRST = "equfirst";
        ESCAPE_FIRST = "escfirst";
        LAPSE_FIRST = "lapfirst";
    }

    public static void setLanguage(string selectedLanguage)
    {
        PlayerPrefs.SetString(LANGUAGE_KEY, selectedLanguage);
    }

    public static string getLanguage()
    {
        return (PlayerPrefs.GetString(LANGUAGE_KEY));
    }   

    public static void setMute(int volume)
    {
        PlayerPrefs.SetInt(MUTE_KEY, volume);
    }

    public static bool isMuted()
    {
        if(PlayerPrefs.GetInt(MUTE_KEY)==0)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public static void setFirstTime()
    {
        PlayerPrefs.SetInt(FIRST_TIME_KEY, 1);
        PlayerPrefs.Save();
    }

    public static bool isFirstTime()
    {
        if(PlayerPrefs.GetInt(FIRST_TIME_KEY)!=1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool hasFirstTimeKey()
    {
        if(PlayerPrefs.HasKey(FIRST_TIME_KEY))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static void setOneDirectionFirstTime()
    {
        PlayerPrefs.SetInt(ONE_FIRST, 1);
        PlayerPrefs.Save();
    }

    public static bool isOneDirectionFirstTime()
    {
        if (PlayerPrefs.GetInt(ONE_FIRST) != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool hasOneDirectionFirstTimeKey()
    {
        if (PlayerPrefs.HasKey(ONE_FIRST))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void setEqualsFirstTime()
    {
        PlayerPrefs.SetInt(EQUAL_FIRST, 1);
        PlayerPrefs.Save();
    }

    public static bool isEqualsFirstTime()
    {
        if (PlayerPrefs.GetInt(EQUAL_FIRST) != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool hasEqualsFirstTimeKey()
    {
        if (PlayerPrefs.HasKey(EQUAL_FIRST))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void setEscapeFirstTime()
    {
        PlayerPrefs.SetInt(ESCAPE_FIRST, 1);
        PlayerPrefs.Save();
    }

    public static bool isEscapeFirstTime()
    {
        if (PlayerPrefs.GetInt(ESCAPE_FIRST) != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool hasEscapeFirstTimeKey()
    {
        if (PlayerPrefs.HasKey(ESCAPE_FIRST))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void setLapseFirstTime()
    {
        PlayerPrefs.SetInt(LAPSE_FIRST, 1);
        PlayerPrefs.Save();
    }

    public static bool isLapseFirstTime()
    {
        if (PlayerPrefs.GetInt(LAPSE_FIRST) != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool hasLapseFirstTimeKey()
    {
        if (PlayerPrefs.HasKey(LAPSE_FIRST))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
