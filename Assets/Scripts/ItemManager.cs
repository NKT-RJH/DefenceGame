using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public int[] items = new int[4];
	
	public void GetItem(int number)
	{
		items[number]++;
	}

	public void Heal()
	{
		if (items[0] <= 0) return;

		// ��ȣ �ü� ȸ��
	}

	public void WholeAttack()
	{
		if (items[1] <= 0) return;

		// ��ü ������
	}

	public void GoldIncrease()
	{
		if (items[2] <= 0) return;

		// ��� ȹ�淮 ����
	}

	public void StopEnemy()
	{
		if (items[3] <= 0) return;

		// ���� �̵��ӵ� 0
	}
}
