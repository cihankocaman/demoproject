using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public abstract class ObjectCreator : MonoBehaviour
{
    public static bool isObjCreated = false;
    public abstract string Name { get; }

    public void Process(GameObject obj)
    {
        if (!isObjCreated)
        {
            GameObject building = Instantiate(obj);
            isObjCreated = true;
        }
    }
}
public class Obj1x2 : ObjectCreator
{
    public override string Name => "1x2";
}
public class Obj2x1 : ObjectCreator
{
    public override string Name => "2x1";
}
public class Obj2x2 : ObjectCreator
{
    public override string Name => "2x2";
}
public class Obj2x3 : ObjectCreator
{
    public override string Name => "2x3";
}
public class Obj3x2 : ObjectCreator
{
    public override string Name => "3x2";
}
public class Obj3x3 : ObjectCreator
{
    public override string Name => "3x3";
}
public class Obj4x4Soldier1 : ObjectCreator
{
    public override string Name => "4x4Sol1";
}
public class Obj4x4Soldier2 : ObjectCreator
{
    public override string Name => "4x4Sol2";
}
public class Obj4x4Soldier3 : ObjectCreator
{
    public override string Name => "4x4Sol3";
}

public static class ObjectFactory
{
    private static Dictionary<string, Type> abilitiesByName;
    private static bool IsInitialized => abilitiesByName != null;

    private static void InitializeFactory()
    {
        if (IsInitialized)
            return;

        var abilityTypes = Assembly.GetAssembly(typeof(ObjectCreator)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(ObjectCreator)));

        // Dictionary for finding these by name later
        abilitiesByName = new Dictionary<string, Type>();

        // Get the names and put them into the dictionary
        foreach (var type in abilityTypes)
        {
            var tempEffect = Activator.CreateInstance(type) as ObjectCreator;
            abilitiesByName.Add(tempEffect.Name, type);
        }
    }

    public static ObjectCreator GetAbility(string abilityType)
    {
        InitializeFactory();

        if (abilitiesByName.ContainsKey(abilityType))
        {
            Type type = abilitiesByName[abilityType];
            var ability = Activator.CreateInstance(type) as ObjectCreator;
            return ability;
        }

        return null;
    }
}
