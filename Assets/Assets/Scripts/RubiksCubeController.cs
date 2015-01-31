using UnityEngine;
using System.Collections;


//rubiks main calls the functions from here
//this calls functions from rubiks cube model and view
//it also gets data from them and sends to main
public class RubiksCubeController : MonoBehaviour
{
	private int _rotationDegree = 90;
	private static int STAGE_COUNT = 10;
	private int STAGE = 1;
	private bool _solving;

	public RubiksCubeModel fullCubeModel;
	public RubiksCubeView fullCubeView;
	public RubiksCubeSolver fullCubeSolver;

	CubeModel[] _cubeArrayTop;
	CubeModel[] _cubeArrayMiddleHorizontal;
	CubeModel[] _cubeArrayBottom;

	ArrayList ActionQue = new ArrayList ();
	ArrayList ReverseActionQue = new ArrayList();

	// Update is called once per frame
	private void Update ()
	{
		if (ActionQue.Count > 0)
		{
			if (!IsRotating ())
			{
				CallMethod ((int)ActionQue [0]);
				ActionQue.RemoveAt (0);
			}
		}
	}

	public void SetRotating(bool rotating)
	{
		fullCubeModel.SetRotating(rotating);
	}

	public bool IsRotating()
	{
		return fullCubeModel.IsRotating();
	}

	public void RotateCubeClockwise()
	{
		RotateFrontClockwise ();
		RotateMiddleFaceClockwise ();
		RotateBackCounterClockwise ();
	}

	public void RotateCubeCounterClockwise()
	{
		RotateFrontCounterClockwise ();
		RotateMiddleFaceCounterClockwise ();
		RotateBackClockwise ();
	}

	public void RotateCubeForward()
	{
		RotateLeftClockwise ();
		RotateMiddleVerticalForward ();
		RotateRightCounterClockwise ();
	}
	
	public void RotateCubeBackwards()
	{
		RotateLeftCounterClockwise ();
		RotateMiddleVerticalBackwards ();
		RotateRightClockwise ();
	}
	
	public void RotateCubeLeft()
	{
		RotateTopClockwise ();
		RotateMiddleHorizontalLeft ();
		RotateBottomCounterClockwise ();
	}

	public void RotateCubeRight()
	{
		RotateTopCounterClockwise ();
		RotateMiddleHorizontalRight ();
		RotateBottomClockwise ();
	}

	public void ReverseCube()
	{
		RotateCubeLeft ();
		RotateCubeLeft ();
	}
	
	/************************************************************************************************/

	public void RotateTopClockwise()
	{
		fullCubeView.RotateTopClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateTopClockwise ();
	}

	public void RotateTopCounterClockwise()
	{
		fullCubeView.RotateTopCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateTopCounterClockwise ();
	}

	public void RotateMiddleHorizontalLeft()
	{
		fullCubeView.RotateMiddleHorizontalLeft (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateMiddleHorizontalLeft();
	}
	
	public void RotateMiddleHorizontalRight()
	{
		fullCubeView.RotateMiddleHorizontalRight (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateMiddleHorizontalRight ();
	}

	public void RotateBottomClockwise()
	{
		fullCubeView.RotateBottomClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateBottomClockwise ();
	}

	public void RotateBottomCounterClockwise()
	{
		fullCubeView.RotateBottomCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateBottomCounterClockwise ();
	}
	
	/************************************************************************************************/
	
	public void RotateLeftClockwise()
	{
		fullCubeView.RotateLeftClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateLeftClockwise ();
	}
	
	public void RotateLeftCounterClockwise()
	{
		fullCubeView.RotateLeftCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateLeftCounterClockwise ();
	}
	
	public void RotateMiddleVerticalForward()
	{
		fullCubeView.RotateMiddleVerticalForward (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateMiddleVerticalForward ();
	}
	
	public void RotateMiddleVerticalBackwards()
	{
		fullCubeView.RotateMiddleVerticalBackwards (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateMiddleVerticalBackwards ();
	}
	
	public void RotateRightClockwise()
	{
		fullCubeView.RotateRightClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateRightClockwise ();
	}
	
	public void RotateRightCounterClockwise()
	{
		fullCubeView.RotateRightCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateRightCounterClockwise ();
	}
	
	/************************************************************************************************/
	
	public void RotateFrontClockwise()
	{
		fullCubeView.RotateFrontClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateFrontClockwise ();
	}
	
	public void RotateFrontCounterClockwise()
	{
		fullCubeView.RotateFrontCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateFrontCounterClockwise ();
	}
	
	public void RotateMiddleFaceClockwise()
	{
		fullCubeView.RotateMiddleFaceClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateMiddleFaceClockwise ();
	}
	
	public void RotateMiddleFaceCounterClockwise()
	{
		fullCubeView.RotateMiddleFaceCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateMiddleFaceCounterClockwise ();
	}
	
	public void RotateBackClockwise()
	{
		fullCubeView.RotateBackClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateBackClockwise ();
	}
	
	public void RotateBackCounterClockwise()
	{
		fullCubeView.RotateBackCounterClockwise (fullCubeModel.GetRubiksCube());
		fullCubeModel.RotateBackCounterClockwise ();
	}

	/*****************************************UTILITY FUNCTIONS*********************************************/

	public void ShuffleCube(int shuffleTimes)
	{
		int randMethod;
		for (var i = 0; i < shuffleTimes; i++) 
		{
			randMethod = Random.Range(0, 24);
			ActionQue.Add(randMethod);
		}
	}

	public void CallMethod(int i)
	{
		switch (i)
		{
		case 0:
			RotateTopClockwise();
			break;
		case 1:	
			RotateTopCounterClockwise();
			break;
		case 2:	
			RotateMiddleHorizontalLeft();
			break;
		case 3:
			RotateMiddleHorizontalRight();
			break;
		case 4:
			RotateBottomClockwise();
			break;
		case 5:
			RotateBottomCounterClockwise();
			break;
		case 6:
			RotateLeftClockwise();
			break;
		case 7:
			RotateLeftCounterClockwise();
			break;
		case 8:
			RotateMiddleVerticalForward();
			break;
		case 9:
			RotateMiddleVerticalBackwards();
			break;
		case 10:
			RotateRightClockwise();
			break;
		case 11:
			RotateRightCounterClockwise();
			break;
		case 12:
			RotateFrontClockwise();
			break;
		case 13:
			RotateFrontCounterClockwise();
			break;
		case 14:
			RotateMiddleFaceClockwise();
			break;
		case 15:
			RotateMiddleFaceCounterClockwise();
			break;
		case 16:
			RotateBackClockwise();
			break;
		case 17:
			RotateBackCounterClockwise();
			break;
		case 18:
			RotateCubeClockwise();
			break;
		case 19:
			RotateCubeCounterClockwise();
			break;
		case 20:
			RotateCubeForward();
			break;
		case 21:
			RotateCubeBackwards();
			break;
		case 22:
			RotateCubeLeft();
			break;
		case 23:
			RotateCubeRight();
			break;
		case 24:
			ReverseCube();
			break;
		default:
			break;
		}
	}
	public RubiksCubeModel GetCube()
	{
		return fullCubeModel.GetRubiksCube ();
	}

	public int GetRotationDegree()
	{
		return this._rotationDegree;
	}

	public void IncreaseStage ()
	{
		this.STAGE = this.STAGE + 1;
	}

	public void SetSolving(bool isSolving)
	{
		this._solving = isSolving;
	}

	/**************************************INITIALIZATION FUNCTIONS*****************************************/

	public bool IsComplete()
	{
		return fullCubeModel.IsComplete ();
	}

	public void GiveCubes(CubeModel[] cubeArrayTop, CubeModel[] cubeArrayMiddleHorizontal, CubeModel[] cubeArrayBottom)
	{
		fullCubeModel.GiveCubes(cubeArrayTop, cubeArrayMiddleHorizontal, cubeArrayBottom);
	}

	public void InitializeRubiksCube()
	{
		fullCubeModel.InitializeRubiksCube ();
	}
	
	public void InitializeCubeColors()
	{
		fullCubeModel.InitializeCubeColors ();
	}

	/*****************************************SOLVING FUNCTIONS*********************************************/

	public void SolveCube()
	{
		//Main method to solve cube
		//Remember technically the cube will be "upside down" after the first side is solved
		//solver will determine set of rotation patterns to apply 
		//then will return list of actions for controller to take
		while (STAGE <= STAGE_COUNT)
		{
			if( ActionQue.Count == 0 )
			{
				switch(STAGE)
				{
					case 1:
						fullCubeSolver.SolveTopCrossMiddle (fullCubeModel.GetRubiksCubeArray());
						break;
					case 2:
						fullCubeSolver.SolveTopCross (fullCubeModel.GetRubiksCubeArray());
						break;
					case 3:
						fullCubeSolver.SolveTopCorners (fullCubeModel.GetRubiksCubeArray());
						break;
					case 4:
						fullCubeSolver.SpinMiddle (fullCubeModel.GetRubiksCubeArray());
						break;
					case 5:
						fullCubeSolver.SolveMiddleSides (fullCubeModel.GetRubiksCubeArray());
						break;
					case 6:
						fullCubeSolver.SolveBottomCross (fullCubeModel.GetRubiksCubeArray());
						break;
					case 7:
						fullCubeSolver.SolveBottomCrossSides (fullCubeModel.GetRubiksCubeArray());
						break;
					case 8:	
						fullCubeSolver.SolveBottomCorners (fullCubeModel.GetRubiksCubeArray());
						break;
					case 9:
						fullCubeSolver.FinishBottomCorners (fullCubeModel.GetRubiksCubeArray());
						break;
					case 10:
						fullCubeSolver.SpinToWin (fullCubeModel.GetRubiksCubeArray());
						break;
				}
			}
		}
	}

}
