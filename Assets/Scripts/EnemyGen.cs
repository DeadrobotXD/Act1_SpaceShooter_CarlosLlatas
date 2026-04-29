using System.Collections;
using UnityEngine;

public class EnemyGen : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] float timeBetweenShips = 3f;
    [SerializeField] Transform top;
    [SerializeField] Transform bot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Generate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShips);
            Vector3 position = Vector3.Lerp(top.position, bot.position, Random.Range(0f,1f));
            Instantiate(prefabEnemy, position, Quaternion.identity);
        }
    }
}
