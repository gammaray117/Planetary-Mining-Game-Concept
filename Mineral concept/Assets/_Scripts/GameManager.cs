using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float gameSpeed = 1f;
	public float changeSpeed = 1f;
	private float lerpFactor = 0;
	public float origLerp = 0.01f;


//	Environment Element Variables
	public GameObject monolithLight;
	public Color monolthFlareColor1 = Color.white;
	public Color monolithFlareColor2 = Color.white;
	public float monolithBrightness1;
	public float monolithBrightness2;
	public float monolithFadeSpeed1;
	public float monolithFadeSpeed2;
	private LensFlare monoflare;

	public Camera mainCamera;

	private SunShafts sunShaft;
	public Color shaftsColor1;
	public Color shaftsColor2;
	public float shaftsBlurSize1;
	public float shaftsBlurSize2;
	public int shaftsBlurIterations1;
	public int shaftsBlurIterations2;
	public float shaftsIntensity1;
	public float shaftsIntensity2;

//	Day/Night Cycle Variables

 	public Color ambientLightColor1 = Color.white;
	public Color ambientLightColor2 = Color.white;
 	public float ambientLightIntensity1 = 1f;
	public float ambientLightIntensity2 = 1f;

	public Color globalFogColor1 = Color.white;
	public Color globalFogColor2 = Color.white;
//	public float globalFogHeightDensisty1 = 0.3f;
//	public float globalFogHeightDensisty2 = 0.3f;
	public float globalFogStartDistance1 = 20f;
	public float globalFogStartDistance2 = 20f;
	public float globalFogEndDistance1 = 200f;
	public float globalFogEndDistance2 = 200f;
//	public float globalFogIntensity1 = 0.1f;
//	public float globalFogIntensity2 = 0.1f;

	public Color skyBoxColorFirst1 = Color.white;
	public Color skyBoxColorFirst2 = Color.white;
	public Color skyBoxColorSecond1 = Color.white;
	public Color skyBoxColorSecond2 = Color.white;
	public float skyBoxColorHeight1 = 600f;
	public float skyBoxColorHeight2 = 600f;

	public Material skyBox;


	// Use this for initialization
	void Start () {
		monoflare = monolithLight.GetComponent<LensFlare>();
		sunShaft = mainCamera.GetComponent<SunShafts>();
	}
	
	// Update is called once per frame
	void Update () {

		//change SkyBox color
		skyBox.SetColor("_Color1",Color.Lerp(skyBoxColorFirst1,skyBoxColorFirst2,lerpFactor));
		skyBox.SetColor("_Color2", Color.Lerp(skyBoxColorSecond1,skyBoxColorSecond2,lerpFactor));
		skyBox.SetFloat("_Height",Mathf.Lerp(skyBoxColorHeight1,skyBoxColorHeight2,lerpFactor));

		//change Ambient Light
		RenderSettings.ambientLight = Color.Lerp(ambientLightColor1,ambientLightColor2,lerpFactor);
		RenderSettings.ambientIntensity = Mathf.Lerp(ambientLightIntensity1,ambientLightIntensity2,lerpFactor);

		//change Global Fog
		RenderSettings.fogColor = Color.Lerp(globalFogColor1,globalFogColor2,lerpFactor);
		RenderSettings.fogStartDistance = Mathf.Lerp(globalFogStartDistance1,globalFogStartDistance2,lerpFactor);
		RenderSettings.fogEndDistance = Mathf.Lerp(globalFogEndDistance1, globalFogEndDistance2, lerpFactor);

		//Monolith Light Control
		monoflare.brightness = Mathf.PingPong(Time.time*4,monolithBrightness2);

		//Sun Shafts Control
		sunShaft.sunColor = Color.Lerp(shaftsColor1,shaftsColor2,lerpFactor);
		sunShaft.sunShaftIntensity = Mathf.Lerp(shaftsIntensity1,shaftsIntensity2,lerpFactor);
		sunShaft.sunShaftBlurRadius = Mathf.Lerp(shaftsBlurSize1,shaftsBlurSize2,lerpFactor);
		sunShaft.radialBlurIterations = Mathf.RoundToInt(Mathf.Lerp(shaftsBlurIterations1,shaftsBlurIterations2,lerpFactor));

		//add lerpfactor
		if(lerpFactor < 1.0f){
			lerpFactor += origLerp*gameSpeed*Time.deltaTime;
		}

	}
}
