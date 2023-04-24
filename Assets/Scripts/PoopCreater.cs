using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopCreater : MonoBehaviour
{

    [SerializeField] private GameObject[] poops;
    [SerializeField] private float poopInterval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCreating();
    }

    private void StartCreating()
    {
        StartCoroutine("CreatePoopRoutine");
    }

    public void StopCreating()
    {
        StopCoroutine("CreatePoopRoutine");
    }


    IEnumerator CreatePoopRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            CreatePoop();
            yield return new WaitForSeconds(poopInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreatePoop()
    {
        Vector3 position = new Vector3(Random.Range(-3f, 3f), 6, 0);
        int index = Random.Range(0, poops.Length);
        Instantiate(poops[index], position, Quaternion.identity);
    }

    public void DecreasePoopInterval()
    {
        poopInterval -= 0.1f;
        if (poopInterval < 0.2f)
        {
            poopInterval = 0.1f;
        }
    }
}
