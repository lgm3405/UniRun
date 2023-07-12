using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilledTypeTest : MonoBehaviour
{
    public Image filledTypeImg;


    private void Awake()
    {
        filledTypeImg.fillAmount = 1.0f;
    }
    void Start()
    {
        StartCoroutine(PassedcoolTime(1f));
    }

    void Update()
    {
        
    }

    private IEnumerator PassedcoolTime(float cooltimeDelay)
    {
        float cooltimePercent = 1f / 300f;

        while (0 < filledTypeImg.fillAmount)
        {
            // 이만큼 시간이 걸린다.
            yield return new WaitForSeconds(cooltimeDelay);

            // 시간이 지나간 다음에 처리한다.
            filledTypeImg.fillAmount -= cooltimePercent;
        }
    }
}
