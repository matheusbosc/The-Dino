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
        
        public string uName = "";
        public TMP_InputField nameField;

	    private string publicKey = "b431c8ef989533d958ece1e4b2b5b4f1e127ccfcd3276b496909dc355b548f6b";
        
	    // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	    private void Start()
	    {
	    	
	    }

        public void GetLeaderboard()
        {
            LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
            {
                for (int i = 0; i < names.Count; i++)
                {
                    names[i].text = msg[i].Username;
                    times[i].text = TimeString(msg[i].Score);
                }
            }));
            
        }

	    public void SetLeaderboardEntry(int t, int d)
        {
	        LeaderboardCreator.UploadNewEntry(publicKey, PlayerPrefs.GetString("Name"), t, ((msg) =>
            {
                
            }));
        }
        
        public void SetUname()
        {
            PlayerPrefs.SetString("Name", "");
            SceneManager.LoadScene("MainMenu");
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