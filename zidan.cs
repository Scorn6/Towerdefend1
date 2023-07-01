using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zidan : MonoBehaviour
{

    public float damage = 50f;   //�ӵ����˺�
    public float speed = 50f;    //�ӵ����ٶ�
    public Transform target;    //�ӵ���Ŀ�꣨�����ˣ���λ��
    public GameObject explosionEffectPrefab;    //�ӵ�����Ǯ����Ч
    private float distanceArriveTarget = 1f;    //���ӵ�����˵ľ���С��distanceArriveTargetʱ����Ϊ�ӵ��򵽵���

    //���±�����Tower3jineng2�й�

    public float damage_ = 50f; //�ӵ�ԭʼ�˺������ڸ�ԭ

    private float rotationSpeed = 50f;



    //�����ӵ�damage
    public void setDamage(float damage)
    {
        this.damage = damage;
        // Debug.Log("damage=" + damage);
    }
    //�����ӵ�speed
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }


    //�����ӵ�����Ŀ�꣨���ˣ�
    public void SetTarget(Transform _target)
    {
        target = _target;
    }



    private void Update()
    {

        if (target == null)
        {
            die();
            return;
        }
        //ʹ�ӵ��������
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //ʹ�ӵ�ָ����˹���,����
        Vector3 dir_ = target.position - transform.position;
        float angle = Vector3.SignedAngle(Vector3.right, dir_, Vector3.forward);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, angle), rotationSpeed * Time.deltaTime);

        /* transform.LookAt(target.position);
         transform.Translate(Vector3.forward*speed*Time.deltaTime);*/

        Vector3 dir = target.position - transform.position;

        if (dir.magnitude < distanceArriveTarget)
        {
            enemy e = target.GetComponent<enemy>();//���˼�Ѫ,δ���
            if (e != null)
            {
                enemyHealth h = e.GetComponent<enemyHealth>();
                if (h != null && !h.isDead)
                {
                    h.DealDamage(damage);
                }
            }
            die();
        }
        void die()
        {
            Quaternion sb = new Quaternion();
            sb = Quaternion.Euler(-90f, 0f, 0f);
            GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, sb);//��ը��Ч
            Destroy(effect, 0.1f);//������Ч
            Destroy(this.gameObject);//׹���ӵ�
        }
    }

}

