#pragma strict

var activeTerrain: Terrain;
var activeTerrains: Terrain[];

function Start () {
	var terrainData = new TerrainData();
	AssetDatabase.CreateAsset(terrainData, 'Assets/_Scenes/Levels/Map1/Terrain Flat.asset');
	var newTerrain = Terrain.CreateTerrainGameObject(terrainData);
	newTerrain.transform.position.x = 0;
	newTerrain.transform.position.y = 0;
	newTerrain.transform.position.z = 0;
}

function Update () {

	activeTerrain = Terrain.activeTerrain;
	activeTerrains = Terrain.activeTerrains;
	
	if(Time.realtimeSinceStartup > 5){
	}
}