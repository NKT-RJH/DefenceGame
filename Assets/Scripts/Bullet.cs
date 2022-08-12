using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Transform target = null;

	private void Update()
	{ // ���� �̰� ����� �ٸ� ��ž ȿ�� �ְ� ���� ��Ʈ�ζ� Ÿ��Ʋ�̶� ��ȭ ����̶� �ε� �׷��� ���� ��ŷ�� ������
		if (target == null) return;
		print("������");
		transform.position = Vector3.MoveTowards(transform.position, target.position, 1);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			Destroy(gameObject);
		}
	}
}
