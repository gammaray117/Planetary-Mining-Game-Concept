using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	// Reference Scripts
	private GameManager gM;
	private Sun sun;

	// Time Management Variables
	[Header("Time Management Variables")]
	public bool DayClockOn = true;
	public float dayLengthInSeconds = 60f;
	public float timeOfDay = 0f;
	public float lerpTValue = 0f;
	public float daySpeedMultiplier = 1f;

	public float timeOfDaySection = 0f;
	public float lerpTSectionValue = 0f;


	[Header("Environment, Color, and Light Variables")]
	public int numOfDayPalettes = 10;
	public int currentPaletteIndex = 0;
	public int nextPaletteIndex = 0;



	//use lerp value to dertermine percentage of progress through the day cycle.. divide this by number of palettes to determine how far into arry time is..


	/* DAY/NIGHT CYCLE SCRIPT SUMMARY:
	I want to have 10 total divisions in the day/night cycle.
	For now, I'll have just one cycle... potentially in the future, I'll have 2/3 full cycles that can be randomly selected.. Specifically, I at least want to have one for a rainy day.

	*/


	void Start(){
		gM = GameObject.FindObjectOfType<GameManager>();
		sun = GameObject.FindObjectOfType<Sun>();

		// Clamp Time of Day to Max Day Length
		if(timeOfDay > dayLengthInSeconds){
			timeOfDay = 0f;
		}

	}

	void Update(){

		CalculateLerpT();

		if(DayClockOn){
			CountTimeOfDay();
		}

		CalculateCurrentPaletteIndex();

//		sun.RotateSun(lerpT);


	}

	void CountTimeOfDay(){
		// Counting Time of day
		if(timeOfDay < dayLengthInSeconds){
			timeOfDay += 1f*Time.deltaTime *daySpeedMultiplier;
		}else{
			timeOfDay = 0f;
		}

		float numOfDays = (float) numOfDayPalettes;
		if(timeOfDaySection < dayLengthInSeconds){
			timeOfDaySection+= 1f*Time.deltaTime*daySpeedMultiplier*numOfDays;
		}else{
			timeOfDaySection = 0f;
		}
	}

	void CalculateLerpT(){
		lerpTValue = (1/dayLengthInSeconds) * timeOfDay;

		lerpTSectionValue = (1/dayLengthInSeconds) * timeOfDaySection;
	}

	void CalculateCurrentPaletteIndex(){
		float numOfDays = (float) numOfDayPalettes;

		currentPaletteIndex = Mathf.FloorToInt(lerpTValue * numOfDays);
		if((currentPaletteIndex +1) < numOfDayPalettes){
			nextPaletteIndex = currentPaletteIndex +1;
		}else{
			nextPaletteIndex = 0;
		}
	}

}