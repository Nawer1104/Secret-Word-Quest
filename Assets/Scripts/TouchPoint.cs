using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    public int index;

    private SpriteRenderer rd;

    Sprite sprite;

    public GameObject vfxCompleted;

    private bool isComplted;

    private void Start()
    {
        rd = GetComponent<SpriteRenderer>();

        sprite = rd.sprite;

        rd.sprite = null;

        isComplted = false;
    }

    public int GetIndex()
    {
        return index;
    }

    public void SetCompleted()
    {
        if (isComplted) return;

        isComplted = true;

        GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);

        rd.sprite = sprite;

        GetComponent<CircleCollider2D>().enabled = false;

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
        GameManager.Instance.CheckLevelUp();
    }
}
