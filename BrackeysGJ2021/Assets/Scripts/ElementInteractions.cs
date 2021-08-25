using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elements{

    public enum Element
    {
        Electricity = 1,
        Air = 2,
        Fire = 3,
        Ice = 4,
        Gum = 5
    }

    
    public class ElementInteractions : MonoBehaviour
    {
        public string[,] Interactions = new string[6, 6]
    {
        {"","Electricity","Air","Fire","Ice","Gum"},
        {"Electricity","Clone","Crit","Combined","Combined","Normal"},
        {"Air","Normal","Clone","Crit","Combined","Combined"},
        {"Fire","Combined","Normal","Clone","Crit","Combined"},
        {"Ice","Combined","Combined","Normal","Clone","Crit"},
        {"Gum","Crit","Combined","Combined","Normal","Clone"}
    };

        public string CheckElementInteraction(Element bulletElement, Element enemyElement)
        {
            int bulletIndex = (int)bulletElement;
            int enemyIndex = (int)enemyElement;
            return Interactions[bulletIndex, enemyIndex];
        }
    }
}


