﻿using System;
using System.Collections;
using TMPro;
using UnityEngine;
using System.Diagnostics;
using Dan.Main;

public class ScoreSetter : MonoBehaviour
    {
        private int damageTaken = 0;
        int timeInSeconds = 0;
        private bool canCount = false, hasSetScore = false;

        public string uName = "";

        public int score = 0;
        
	    public TMP_InputField uNameField;

	    private TextMeshProUGUI timeText;

	    private Leaderboard lb;
	    
	    private string publicKey = "b431c8ef989533d958ece1e4b2b5b4f1e127ccfcd3276b496909dc355b548f6b";


        private void Start()
        {
	        DontDestroyOnLoad(this.gameObject);
        }

        public void StartCounter()
        {
            canCount = true;

            score = 0;

            StartCoroutine("count");
        }

        IEnumerator count()
        {
	        yield return new WaitForSeconds(0.3f);
	        if (canCount)
	        {
		        score += 1;
		        StartCoroutine("count");
	        }
        }

        private void Update()
        {
	        if (canCount)
	        {
		        if (!timeText)
		        {
			        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<TextMeshProUGUI>();
		        }
		        timeText.text = score.ToString();
	        }
	        
        }

        public void Win()
        {
	        canCount = false;

	        while (!hasSetScore)
	        {
		        try
		        {
			        LeaderboardCreator.UploadNewEntry(publicKey, PlayerPrefs.GetString("Name"), score, ((msg) => { }));
					hasSetScore = true;
		        }
		        catch (Exception e)
		        {
			        Console.WriteLine(e);
			        throw;
		        }
	        }
        }
    }
