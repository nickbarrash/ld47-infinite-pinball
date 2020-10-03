using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScoreableComponent : MonoBehaviour
{
    ScorePoints points;

    List<ComponentGroupBehavior> groups = new List<ComponentGroupBehavior>();

    void Awake() {
        points = GetComponent<ScorePoints>();
    }

    // Start is called before the first frame update
    public void score() {
        if (points != null) {
            points.score();
        }
    }

    public void activate() {
        foreach(ComponentGroupBehavior group in groups) {
            group.setActivation(this, true);
        }
    }

    public void deactivate() {
        foreach (ComponentGroupBehavior group in groups) {
            group.setActivation(this, false);
        }
    }

    public void registerGroup(ComponentGroupBehavior group) {
        groups.Add(group);
    }

    public virtual void resetState() {
        deactivate();
    }
}
