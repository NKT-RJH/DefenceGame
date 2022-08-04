using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatKey : MonoBehaviour
{
	private Dictionary<KeyCode, Action> actionsByKey = new Dictionary<KeyCode, Action>();

	private void Start()
	{
		// ġƮŰ�� F1 �������� F7 ����! �ϴ��� �׽�Ʈ �Լ���..,
		actionsByKey.Add(KeyCode.F1, StopEnemy);
		actionsByKey.Add(KeyCode.F2, GoldIncrease);
		actionsByKey.Add(KeyCode.F3, KillAll);
		actionsByKey.Add(KeyCode.F4, KillAll_Gold);
		actionsByKey.Add(KeyCode.F5, GotoTitle);
		actionsByKey.Add(KeyCode.F6, GotoFirstStage);
		actionsByKey.Add(KeyCode.F7, GotoSecondStage);

		StartCoroutine(Repeat());
	}

	private IEnumerator Repeat()
	{
		while (true)
		{
			if (Input.anyKeyDown)
			{
				foreach (KeyValuePair<KeyCode, Action> keyValue in actionsByKey)
				{
					if (Input.GetKeyDown(keyValue.Key))
					{
						keyValue.Value.Invoke();
					}
				}
			}
			yield return null;
		}
	}

	private void StopEnemy()
	{
		// ��� �� ���߱�
		print("��� �� ���߱�");
	}

	private void GoldIncrease()
	{
		// ��� ���� 100
		print("��� ���� 100");
	}

	private void KillAll()
	{
		// ��� �� ��� (��� ȹ�� X)
		print("��� �� ��� (��� ȹ�� X)");
	}

	private void KillAll_Gold()
	{
		// ��� �� ��� (��� ȹ��)
		print("��� �� ��� (��� ȹ��)");
	}

	private void GotoTitle()
	{
		// ����ȭ������
		print("����ȭ������");
	}

	private void GotoFirstStage()
	{
		// 1���������� ��ȯ
		print("1���������� ��ȯ");
	}

	private void GotoSecondStage()
	{
		// 2���������� ��ȯ
		print("2���������� ��ȯ");
	}
}
