using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spells
{
    float getFirstSpellLength();

    float getSecondSpellLength();


    bool castFirstSpell();

    bool castSecondSpell();
}
