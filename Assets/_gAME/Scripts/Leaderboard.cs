﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.SceneManagement;

    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> names;
        [SerializeField] private List<TextMeshProUGUI> times;
        
        [SerializeField] private List<TextMeshProUGUI> damageNames;
        [SerializeField] private List<TextMeshProUGUI> damageAmount;

        public GameObject scoreSetter;
        
        public string uName = "";
        public TMP_InputField nameField;
        
        public GameObject mainCanvas, nameSetCanvas;

	    private string publicKey = "b431c8ef989533d958ece1e4b2b5b4f1e127ccfcd3276b496909dc355b548f6b";
        
	    // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	    private void Start()
	    {
            if (GameObject.FindGameObjectWithTag("ScoreSetter") == null)
            {
                var a = Instantiate(scoreSetter);
                a.tag = "ScoreSetter";
            }
            else
            {
                scoreSetter = GameObject.FindGameObjectWithTag("ScoreSetter");
            }
            
            GetLeaderboard();

            if (PlayerPrefs.GetString("Name") == null || PlayerPrefs.GetString("Name") == "")
            {
                mainCanvas.SetActive(false);
                nameSetCanvas.SetActive(true);
            }
            else
            {
                mainCanvas.SetActive(true);
                nameSetCanvas.SetActive(false);
            }
            
	    }

        public void GetLeaderboard()
        {
            LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
            {
                for (int i = 0; i < names.Count; i++)
                {
                    names[i].text = msg[i].Username;
                    times[i].text = msg[i].Score.ToString();
                }
            }));
            
        }

	    public void SetLeaderboardEntry(int t)
        {
	        LeaderboardCreator.UploadNewEntry(publicKey, PlayerPrefs.GetString("Name"), t, ((msg) =>
            {
                
            }));
        }
        
        public void SetUname()
        {
            PlayerPrefs.SetString("Name", nameField.text);
            SceneManager.LoadScene("Main Menu");
        }
        
        public void ResetUname()
        {
            PlayerPrefs.SetString("Name", "");
            SceneManager.LoadScene("Main Menu");
        }

        private string TimeString(int t)
        {
            bool isSettingTime = true;
            int seconds = 0;
            int minutes = 0;
            
            while (isSettingTime)
            {
                if (t >= 60)
                {
                    minutes++;
                    t -= 60;
                }
                else
                {
                    seconds = t;
                    isSettingTime = false;
                }
            }
            
            return minutes.ToString("00") + "m " + seconds.ToString("00") + "s";
        }
    
}