using System;
using UnityEngine;

public class GenerateBonus
{
    private static String[] bonus =
    {
         "SpeedBonus",
         "ObstacleBonus",
         "BulletBonus"
    };

    public static String Generate()
    {
        System.Random r = new System.Random(Guid.NewGuid().GetHashCode());
        return bonus[r.Next(0, bonus.Length)];

    }
}