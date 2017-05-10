#pragma strict


var line : LineRenderer; //to hold the line Renderer
var target : Transform; //to hold the transform of the target
var agent : UnityEngine.AI.NavMeshAgent; //to hold the agent of this gameObject

function Start(){
    line = GetComponent(LineRenderer); //get the line renderer
    agent = GetComponent(UnityEngine.AI.NavMeshAgent); //get the agent
    getPath();
}

function getPath(){
    line.SetPosition(0, transform.position); //set the line's origin



    agent.SetDestination(GameObject.FindWithTag("Vortex").transform.position); //create the path
    yield WaitForEndOfFrame(); //wait for the path to generate

    DrawPath(agent.path);

    agent.Stop();//add this if you don't want to move the agent
}

function DrawPath(path : UnityEngine.AI.NavMeshPath){
    if(path.corners.Length < 2) //if the path has 1 or no corners, there is no need
        return;

    line.SetVertexCount(path.corners.Length); //set the array of positions to the amount of corners

    for(var i = 1; i < path.corners.Length; i++){
        line.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
    }
}






function Update () {
	
}
