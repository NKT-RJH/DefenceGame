using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Range(1, 4)] public int number;

	public int HP;
	public int gold;

	public bool deathByPoint = false;

	public float movementspeed;
	public Vector3 direction;

	public int wayPointIndex;

	private List<Transform> pointList;

	private void Start()
	{
		WayPoints wayPoints = FindObjectOfType<WayPoints>();
		pointList = Random.Range(0, 2) == 0 ? wayPoints.turnOne : wayPoints.turnTwo;
		//pointList = wayPoints.turnOne;
		wayPointIndex = 0;

		switch (number)
		{
			case 1:
				HP = 5;
				gold = 3;
				break;
			case 2:
				HP = 15;
				gold = 10;
				break;
			case 3:
				HP = 10;
				gold = 15;
				break;
			case 4:
				HP = 15;
				gold = 20;
				break;
		}
		StartCoroutine(DeathCheck());
	}

	private void Update()
	{
		//���� ���� (�ֿ켱����)
		direction = pointList[wayPointIndex].position - transform.position;

		//�̵�
		transform.position = Vector3.MoveTowards(transform.position, pointList[wayPointIndex].position, movementspeed * Time.deltaTime);


		//ȸ��
		/// ���� ������� ��ġ��!!!!
		transform.rotation = Quaternion.LookRotation(direction, new Vector3(0, 0, 0));

		//waypoint ���� �� ���� waypoint Ž��
		if (Vector3.Distance(pointList[wayPointIndex].position, transform.position) <= 0.01f)
		{
			transform.position = pointList[wayPointIndex].position;
			if (pointList.Count - 1 > wayPointIndex)
			{
				wayPointIndex++;
			}
		}
	}

	private IEnumerator DeathCheck()
	{
		while (HP > 0)
		{
			yield return null;
		}

		if (!deathByPoint)
		{
			FindObjectOfType<GameManager>().gold += gold;
			switch (number)
			{
				case 3:
					FindObjectOfType<ItemManager>().GetItemByEnemy();
					break;
				case 4:
					transform.GetChild(0).gameObject.SetActive(true);
					yield return new WaitForSeconds(0.1f);
					break;
			}
		}
		DestroyImmediate(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			HP -= 3;
		}
	}
}