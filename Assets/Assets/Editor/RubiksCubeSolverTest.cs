using System;
using UnityEngine;
using NUnit.Framework;

public class RubiksCubeSolverTest
{
	//CubeModel[] _cubeArrayTop = new CubeModel[9];
	//CubeModel[] _cubeArrayMiddleHorizontal = new CubeModel[9];
	//CubeModel[] _cubeArrayBottom = new CubeModel[9];

	GameObject RubiksMain = new GameObject();

	private void InitializeTestCommon()
	{
		RubiksMain.AddComponent<RubiksCubeController>();

		//fullCubeController.GiveCubes(this._cubeArrayTop, this._cubeArrayMiddleHorizontal, this._cubeArrayBottom);
		//fullCubeController.InitializeRubiksCube ();
		//fullCubeController.InitializeCubeColors ();
		//fullCubeController.ShuffleCube(50);
	}

	private void FinishTests()
	{
		GameObject.Destroy (RubiksMain);
	}

	[Test]
	public void TestSolveTop()
	{
		//Arrange
		//create data
		InitializeTestCommon ();

		//Act
		//call methods
		//fullCubeSolver.SolveTopCrossMiddle (fullCubeModel.GetRubiksCubeArray());

		//Assert
		//Assert.That (fullCubeModel.GetRubiksCubeBlock(1,1,0).GetTopColor().Equals(Color.white));

		FinishTests ();
	}

}
