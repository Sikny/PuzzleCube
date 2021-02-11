using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    private bool endLvl;
    public bool EndLvl { get => endLvl; set => endLvl = value; }
    public bool EndStage { get => endStage; set => endStage = value; }

    private bool endStage;

    public Transform levelStartCollider;

    public bool LvlChecked()
    {
        return endLvl;
    }

    public bool PuzzleCleared()
    {
        return endStage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            endLvl = true;
            Hole hole = other.GetComponentInParent<Hole>();
            foreach (var floorRenderer in hole.floor.renderers)
            {
                floorRenderer.enabled = false;
            }

            hole.holeLight.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Fin")
        {
            endStage = true;
            Debug.LogError("FIN");
        }
    }
}
