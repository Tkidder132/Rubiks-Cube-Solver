using System;
using UnityEngine;
using NUnit.Framework;

public class RubiksCubeSolverTest
{
	public CubeModel[] _cubeArrayTop = new CubeModel[9];
	public CubeModel[] _cubeArrayMiddleHorizontal = new CubeModel[9];
	public CubeModel[] _cubeArrayBottom = new CubeModel[9];
	
	[Test]
	public void TestSolveTop()
	{
		//Arrange
		//create data
		RubiksCubeController fullCubeController = new RubiksCubeController ();
		RubiksCubeModel fullCubeModel = new RubiksCubeModel ();
		RubiksCubeSolver fullCubeSolver = new RubiksCubeSolver ();

		fullCubeController.GiveCubes (this._cubeArrayTop, this._cubeArrayMiddleHorizontal, this._cubeArrayBottom);
		fullCubeModel.InitializeRubiksCube ();
		fullCubeModel.InitializeCubeColors ();
		//fullCubeController.ShuffleCube (50);

		//Act
		//call methods
		//fullCubeSolver.Invoke ("SolveTopCrossMiddle", .05f);
		//Assert
		Assert.That (fullCubeModel.GetRubiksCubeBlock(1,1,0).GetTopColor().Equals(Color.white));
	}

}
