using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public int HP = 10;
	public int gold = 100;

	private float flagTime;
	public Text time;
	public Text goldText;
	public List<GameObject> hpUI = new List<GameObject>();

	private void Start()
	{
		flagTime = Time.time;
	}
	private void Update()
	{
		float temporary = Time.time - flagTime;
		int minuite = Mathf.FloorToInt(temporary / 60);
		int second = Mathf.FloorToInt(temporary % 60);
		time.text = string.Format("{0:D2}:{1:D2}", minuite, second);
		goldText.text = gold.ToString();
	}
}
