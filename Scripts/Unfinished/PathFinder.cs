using System;
using UnityEngine;
using System.Collections.Generic;
public static class PathFinder{
	

	public static List<FollowOrb> determinePath(FollowOrb StartingOrb,FollowOrb DestinationOrb ){
		Queue<FollowOrb> frontier = new Queue<FollowOrb>();
		frontier.Enqueue(StartingOrb);

        

		FollowOrb[] camefrom = new FollowOrb[50];

		camefrom[DestinationOrb.value] = null;
		FollowOrb current=new FollowOrb();

		while (frontier.Count > 0)
		{
			current = frontier.Dequeue();

			if(current==DestinationOrb){
				break;
			}

			foreach(FollowOrb FO in current.neighbours) {
				if(CheckForOrb(camefrom,current)==false){
					frontier.Enqueue(FO);
					camefrom[FO.value] = current;
				}
			}   
				
		}
        
		List<FollowOrb> path = new List<FollowOrb>();

        while(current != StartingOrb){
			path.Add(current);
			current = camefrom[current.value];
		}

		path.Reverse();
		return path;
    }


	private static bool CheckForOrb(List<FollowOrb> path, FollowOrb orbLookingFor)
    {
        foreach (FollowOrb FO in path)
        {
            if (FO == orbLookingFor)
            {
                return true;
            }
        }
		return false;

    }

	private static bool CheckForOrb(FollowOrb[] path, FollowOrb orbLookingFor)
    {
		for (int i = 0; i < path.Length;i++)
        {
			if (path[i] == orbLookingFor)
            {
                return true;
            }
        }
        return false;

    }
}







/*
List<FollowOrb> path = new List<FollowOrb>();
List<FollowOrb> bestPath = new List<FollowOrb>();
path.Add(StartingOrb);
        int i = 0;
int j = 0;


        while(CheckForOrb(path, DestinationOrb)==false){
            
            path.Add(path[i].neighbours[j]);
            i++;


        }

        path.Add(DestinationOrb);

        return path;
    }

    

    return false;
 */