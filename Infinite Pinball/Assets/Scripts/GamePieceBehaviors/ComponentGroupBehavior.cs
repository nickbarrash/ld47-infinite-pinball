using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentGroupBehavior : ScoreableComponent {
    public List<ScoreableComponent> myComponents;

    HashSet<ScoreableComponent> activeComponents = new HashSet<ScoreableComponent>();
    HashSet<ScoreableComponent> inactiveComponents = new HashSet<ScoreableComponent>();

    // Start is called before the first frame update
    public void Start()
    {
        foreach(ScoreableComponent component in myComponents) {
            component.registerGroup(this);
            inactiveComponents.Add(component);
        }
    }

    public virtual void allActivated() {
        score();
    }

    public void setActivation(ScoreableComponent component, bool active) {
        if (active) {
            inactiveComponents.Remove(component);
            activeComponents.Add(component);
        } else {
            activeComponents.Remove(component);
            inactiveComponents.Add(component);
        }

        if (inactiveComponents.Count == 0) {
            allActivated();
        }
    }

    public void deactivateAll() {
        foreach (ScoreableComponent component in myComponents) {
            component.resetState();
        }
    }
}
