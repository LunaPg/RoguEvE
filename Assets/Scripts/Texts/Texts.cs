﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public class Texts : MonoBehaviour {
    string fileUrl;
	public Dictionary<string, string> table = new Dictionary<string, string>();

	// Use this for initialization
	void Start () {
		fileUrl = "Assets/rogueve.rogueAI.dialogs.txt";
		loadTexts ();
	}

	public string get (string key) {
		return table[key];
	}

	void loadTexts () {  //ry hack because I can't read the file...
		table.Add ("AI_FIGHT_START_1", 	"The hostile Capsuleer has fallen in \nrange of our Stasis Lock Cannon !");
		table.Add ("AI_FIGHT_START_2", 	"Deploy your Drones and protect \nthe Hive !");
		table.Add ("AI_HOSTILE_DETECTED","Our D-scan shows a hostile entity is approaching the Hive.");
		table.Add ("AI_HOSTILE_IS_AMARR_FRIGATE",		"Further scanning reveals the hostile is piloting a Frigate from the Amarr Empire.");
		table.Add ("AI_HOSTILE_IS_CALDARI_FRIGATE",		"Further scanning reveals the hostile is piloting a Frigate from the Caldari State.");
		table.Add ("AI_HOSTILE_IS_GALLENTE_FRIGATE",	"Further scanning reveals the hostile is piloting a Frigate from the Gallente Federation.");
		table.Add ("AI_HOSTILE_IS_MINMATAR_FRIGATE",	"Further scanning reveals the hostile is piloting a Frigate from the Minmatar Republic.");
		table.Add ("AI_HOSTILE_TIP_FRIGATE",	"Frigates tend to have low EM shield and EXP armor resists.");
		table.Add ("AI_FIGHT_WIN_1",	"You have successfuly protected \nthe Hive !");
		table.Add ("AI_FIGHT_WIN_2",	"Good work. Now let's scavenge \nthese wrecks.");
		table.Add ("AI_FIGHT_WIN_3",	"You have eradicated the Capsuleer \nmenace !");
		table.Add ("AI_FIGHT_LOOSE",	"The Hive has fallen. You have failed to protect it.");
		table.Add ("APP_TITLE",			"RoguEvE");
		table.Add ("APP_CREDITS",		"rDyne & Eelai Nova");
		table.Add ("HIVE_INSTRUCTIONS_1",		"You must assemble a team \nof Drones to defend the \nHive against hostile \nentities.");
		table.Add ("HIVE_INSTRUCTIONS_2",		"Click a Drone slot from the \nleft, then click the drone \nyou want to assign in the \nright list.");
		table.Add ("HIVE_MEDIUM_DRONES_AVAILABLE",		"We have gathered enough materials from the wrecks to start researching into better defense systems.");
		table.Add ("HIVE_HEAVY_DRONES_AVAILABLE",		"We have analyzed enough battles to improve our defenses even further.");
		table.Add ("HIVE_SALVAGE_DRONES_AVAILABLE",		"We have gathered an intact Salvager module from this wreck.");
		table.Add ("HIVE_SHIELDREP_DRONES_AVAILABLE",	"We have gathered an intact Remote Shield Repairer module from this wreck.");
		table.Add ("HIVE_ARMORREP_DRONES_AVAILABLE",	"We have gathered an intact Remote Armor Repairer module from this wreck.");
		table.Add ("HIVE_RESISTSCAN_AVAILABLE",			"We have computed enough wreck defense systems to better analyze hostile resistances pattern.");
	}
//	void loadTexts () {
//		StreamReader reader = new StreamReader (fileUrl, Encoding.Default);
//		string line, key = null;
//
//		using (reader) {
//			do {	
//				line = reader.ReadLine ();
//				if (line != null ) {
//					if( Regex.IsMatch(line, "^[.*]$") ) {
//						//Debug.Log("Reading texts for lang: " + line);
//					}
//					if ( Regex.IsMatch(line, ".*:$") ) {
//						Debug.Log("reading key: " + line);
//						key = line.Remove(line.Length-1); 
//					}
//					else if ( !string.IsNullOrEmpty(key) ) {
//						
//						string value = line;
//						table.Add(key, value);
//						Debug.Log(key + "---" + value);
//						key = null;
//
//					}
//				}
//			} while (line != null);
//
//			reader.Close();
//		}
//	}
}
