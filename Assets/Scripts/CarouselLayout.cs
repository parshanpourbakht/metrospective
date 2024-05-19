using UnityEngine;

public class CarouselLayout : MonoBehaviour
{
    public GameObject[] thumbnails;
    public float radius = 2.0f;
    private int currentIndex = 0;

    void Start()
    {
        ArrangeInCircle();
    }

    void ArrangeInCircle()
    {
        float angleStep = 360f / thumbnails.Length;
        for (int i = 0; i < thumbnails.Length; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            thumbnails[i].transform.localPosition = position;
            thumbnails[i].transform.LookAt(transform.position);
        }
    }

    public void SwipeLeft()
    {
        currentIndex = (currentIndex + 1) % thumbnails.Length;
        ArrangeInCircle();
    }

    public void SwipeRight()
    {
        currentIndex = (currentIndex - 1 + thumbnails.Length) % thumbnails.Length;
        ArrangeInCircle();
    }
}

