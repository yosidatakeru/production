using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class EnemyDetectorAndShooter : MonoBehaviour
{

    public GameObject missilePrefab; // ���˂���e�̃v���n�u
    public Transform launchPoint; // �e�𔭎˂���ʒu
    public float detectionRadius = 20f; // ���o�͈�
    public LayerMask enemyLayer; // �G�̃��C���[�}�X�N
    public int maxTargets = 10; // �ő匟�o����G�̐�
    public GameObject markerPrefab; // �G�̈ʒu������3D���f��


    private List<Transform> detectedEnemies = new List<Transform>(); // ���o�����G���X�g
    private List<GameObject> activeMarkers = new List<GameObject>(); // �z�u���ꂽ�}�[�J�[�̃��X�g
    private bool isDetecting = false; // ���o���t���O
    private Coroutine detectionCoroutine; // ���G�p�R���[�`��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[��������Ă���ԁA�G�����o
        if (Input.GetKeyDown(KeyCode.Space) && detectionCoroutine == null)
        {
            if (!isDetecting)
            {
                isDetecting = true;
                detectionCoroutine = StartCoroutine(DetectEnemiesPeriodically());
                Debug.Log("���o���J�n...");
            }


        }

        // �X�y�[�X�L�[�𗣂����u�Ԃɒe�𔭎�
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isDetecting)
            {
                if (detectionCoroutine != null)
                {
                    StopCoroutine(detectionCoroutine);
                    detectionCoroutine = null; // �R���[�`�����~��Anull�ɐݒ�
                    Debug.Log("���o���~���܂���...");
                }
                FireMissiles();
                Debug.Log("�e�𔭎˂��܂����I");
            }

            // ��Ԃ����Z�b�g
            isDetecting = false;

            // �}�[�J�[���폜
            ClearMarkers();
        }
        if (detectionCoroutine == null)
        {
            isDetecting = false;
        }
        FollowMarkers();
    }

    //�}�[�J�̏���
    private void FollowMarkers()
    {
        // �Ǐ]����}�[�J�[�̈ʒu���X�V
        for (int i = 0; i < activeMarkers.Count; i++)
        {
            if (activeMarkers[i] != null && detectedEnemies[i] != null)
            {
                // �}�[�J�[��G�̈ʒu�ɒǏ]������
                activeMarkers[i].transform.position = detectedEnemies[i].position;
            }
            else
            {
                // �G���|����Ă���ꍇ�A�}�[�J�[���폜
                if (activeMarkers[i] != null)
                {
                    Destroy(activeMarkers[i]);
                    activeMarkers.RemoveAt(i);
                    detectedEnemies.RemoveAt(i);
                    i--; // �C���f�b�N�X�𒲐�
                }
            }
        }
    }

    private void ClearMarkers()
    {
        // �z�u���ꂽ�S�Ẵ}�[�J�[���폜
        foreach (GameObject marker in activeMarkers)
        {
            Destroy(marker);
        }
        activeMarkers.Clear();
    }



    IEnumerator DetectEnemiesPeriodically()
    {
        yield return new WaitForSeconds(2f);
        while (isDetecting)
        {
            DetectAndAddEnemy();
            yield return new WaitForSeconds(1f); // 1�b�Ԋu�Ŏ��s
        }
    }



    void DetectAndAddEnemy()
    {
        // ���ł� maxTargets �̓G�����o���Ă���ꍇ�A�V�����G��ǉ����Ȃ�
        if (detectedEnemies.Count >= maxTargets)
        {
            return;
        }

        // ���o�͈͓��̓G���擾
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        // �G��������Ȃ������ꍇ�A�������I��
        if (hits.Length == 0)
        {
            Debug.Log("�G��������܂���ł����B");
            return;
        }

        // �G���������Ƀ\�[�g
        List<Transform> sortedEnemies = hits
            .OrderBy(hit => Vector3.Distance(transform.position, hit.transform.position))
            .Select(hit => hit.transform)
            .ToList();

        foreach (Transform enemy in sortedEnemies)
        {
            // ���Ƀ��X�g�ɂ���G�͒ǉ����Ȃ�
            if (!detectedEnemies.Contains(enemy))
            {
                detectedEnemies.Add(enemy);
                Debug.Log($"�G {enemy.name} �����o���܂����I");

                // �}�[�J�[���쐬�i���� maxTargets �ɒB���Ă�����쐬���Ȃ��j
                if (activeMarkers.Count < maxTargets)
                {
                    GameObject marker = Instantiate(markerPrefab, enemy.position, Quaternion.identity);
                    activeMarkers.Add(marker);
                }

                // ���X�g�����܂����烋�[�v�𔲂���
                if (detectedEnemies.Count >= maxTargets)
                {
                    break;
                }
            }
        }
    }

    private void RemoveOldestMarker()
    {
        // �ł��Â��}�[�J�[���폜
        if (activeMarkers.Count > 0)
        {
            GameObject oldestMarker = activeMarkers[0];
            activeMarkers.RemoveAt(0);
            Destroy(oldestMarker);
        }
    }

    List<Transform> DetectEnemies()
    {

        // ���o�͈͓��̓G���擾
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        // �������ɕ��בւ��A�ő吔�����I��
        return hits
            .OrderBy(hit => Vector3.Distance(transform.position, hit.transform.position))
            .Take(maxTargets)
            .Select(hit => hit.transform)
            .ToList();
    }


    void FireMissiles()
    {

        // ���o�����G���ꂼ��ɒe�𔭎�
        foreach (Transform enemy in detectedEnemies)
        {
            if (enemy != null)
            {
                // �e�𐶐�
                GameObject missile = Instantiate(missilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                // �^�[�Q�b�g��ݒ�i�e���ɐݒ胁�\�b�h��p�ӂ���K�v����j
                Missile missileScript = missile.GetComponent<Missile>();
                if (missileScript != null)
                {
                    missileScript.SetTarget(enemy);
                }
            }
        }

        // ���o���X�g���N���A
        detectedEnemies.Clear();





        void OnDrawGizmosSelected()
        {
            // ���o�͈͂����o��
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}