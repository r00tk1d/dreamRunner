using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Obstacle{
    private static float speed = DefValues.startSpeed;

    public static float getSpeed(){
        return speed;
    }

    public static void setSpeed(float newSpeed){
        speed = newSpeed;
    }



}