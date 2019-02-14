using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph  {
	private const int max_verts = 7;
	int infinity = 1000000;
	public Vertex[] vertexList;
	int[,] adjMat;
	int nVerts;
	int nTree;
	DistOriginal[] sPath;
    
	int currentVert;
	int startToCurrent;


	public Graph(){
		vertexList = new Vertex[max_verts];
		adjMat = new int[max_verts, max_verts];
		nVerts = 0;
		nTree = 0;

		for (int j = 0; j <= max_verts - 1;j++){
			for (int k = 0; k <= max_verts - 1;k++){
				adjMat[j, k] = infinity;
			}
		}

		sPath = new DistOriginal[max_verts];
	}

	public void AddVertex(string lab){
		vertexList[nVerts] = new Vertex(lab);
		nVerts++;
	}

	public void AddEdge(int start,int end,int weight){
		adjMat[start, end] = weight;
	}

	public void Path(string start,string end){
		
		int startTree = FindVertexListPos(start);
		int endtree = FindVertexListPos(end);
		int minDist;
		Debug.Log(startTree);
		if (startTree!=infinity)
		{
			vertexList[startTree].isInTree = true;
			nTree = 1;
			for (int j = 0; j <= nVerts-1; j++)
			{
				int tempDist = adjMat[startTree, j];
				sPath[j] = new DistOriginal(startTree, tempDist);
			}
			while (nTree < nVerts)
			{
				int indexMin = GetMin();
				minDist = sPath[indexMin].distance;
				currentVert = indexMin;
				startToCurrent = sPath[indexMin].distance;
				vertexList[currentVert].isInTree = true;
				nTree++;
				AdjustShortPath();
			}
			DisplayPaths();
			nTree = 0;
			for (int j = 0; j <= nVerts - 1; j++)
			{
				vertexList[j].isInTree = false;
			}

			List<int> mylist = new List<int>();
			int current = startTree;
			mylist.Add(current);
			 minDist=0;
			int shortestdisVertexFromCurrent=current;

			while(current!=endtree){
				
				for (int i = 0; i < nVerts;i++){
					if(adjMat[current,nVerts] < minDist){
						shortestdisVertexFromCurrent = nVerts;
					}
				}
			}


		}else{
			Debug.Log("Could not find vertex in graph ");
		}
	}

	public int GetMin(){
		int MinDist = infinity;
		int indexMin = 0;
		for (int j = 1; j < nVerts - 1;j++){
			if(!(vertexList[j].isInTree)&&(sPath[j].distance<MinDist)){
				MinDist = sPath[j].distance;
				indexMin = j;
			}
		}
		return indexMin;
	}

	public void AdjustShortPath(){
		int column = 1;
		while(column<nVerts){
			if(vertexList[column].isInTree){
				column++;
			}else{
				int currentToFringe = adjMat[currentVert, column];
				int startToFringe = startToCurrent + currentToFringe;
				int sPathDist = sPath[column].distance;
				if(startToFringe<sPathDist){
					sPath[column].parentVert = currentVert;
					sPath[column].distance = startToFringe;
				}
				column++;
			}
		}
	}

	public void DisplayPaths(){
		for (int j = 0; j <= nVerts - 1; j++)
		{
			Debug.Log(vertexList[j].label + " = ");

			if (sPath[j].distance == infinity)
			{
				Debug.Log(" inf ");
			}else{
			    Debug.Log(sPath[j].distance);
			}

			string parent = vertexList[sPath[j].parentVert].label;

			Debug.Log(" ( "+parent+" ) ");

		}
	}

	private int FindVertexListPos( string start){
		int currentPos = 0;

		foreach(Vertex vertex in vertexList){
			
			if(vertex.label==start ){
				return currentPos;
			}
			currentPos++;
		}

		return infinity;
	}

}
