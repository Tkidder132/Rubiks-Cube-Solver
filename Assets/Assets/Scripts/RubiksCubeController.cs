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
	//private bool _solving;

	RubiksCubeModel _fullCubeModel;
	RubiksCubeView _fullCubeView;
	RubiksCubeSolver _fullCubeSolver;

	CubeModel[] _cubeArrayTop;
	CubeModel[] _cubeArrayMiddleHorizontal;
	CubeModel[] _cubeArrayBottom;

	ArrayList ActionQue = new ArrayList ();
	//ArrayList ReverseActionQue = new ArrayList();

	// Update is called once per frame
	private void Update ()
	{
		if (ActionQue.Count > 0)
		{
			Debug.Log(ActionQue.Count);
			if (!IsRotating ())
			{
				CallMethod ((int)ActionQue [0]);
				ActionQue.RemoveAt (0);
			}
		}
		else
		{
			SolveCube ();
		}
	}

	public void SetRotating(bool rotating)
	{
		_fullCubeModel.SetRotating(rotating);
	}

	public bool IsRotating()
	{
		return _fullCubeModel.IsRotating();
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
		_fullCubeView.RotateTopClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateTopClockwise ();
	}

	public void RotateTopCounterClockwise()
	{
		_fullCubeView.RotateTopCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateTopCounterClockwise ();
	}

	public void RotateMiddleHorizontalLeft()
	{
		_fullCubeView.RotateMiddleHorizontalLeft (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateMiddleHorizontalLeft();
	}
	
	public void RotateMiddleHorizontalRight()
	{
		_fullCubeView.RotateMiddleHorizontalRight (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateMiddleHorizontalRight ();
	}

	public void RotateBottomClockwise()
	{
		_fullCubeView.RotateBottomClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateBottomClockwise ();
	}

	public void RotateBottomCounterClockwise()
	{
		_fullCubeView.RotateBottomCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateBottomCounterClockwise ();
	}
	
	/************************************************************************************************/
	
	public void RotateLeftClockwise()
	{
		_fullCubeView.RotateLeftClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateLeftClockwise ();
	}
	
	public void RotateLeftCounterClockwise()
	{
		_fullCubeView.RotateLeftCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateLeftCounterClockwise ();
	}
	
	public void RotateMiddleVerticalForward()
	{
		_fullCubeView.RotateMiddleVerticalForward (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateMiddleVerticalForward ();
	}
	
	public void RotateMiddleVerticalBackwards()
	{
		_fullCubeView.RotateMiddleVerticalBackwards (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateMiddleVerticalBackwards ();
	}
	
	public void RotateRightClockwise()
	{
		_fullCubeView.RotateRightClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateRightClockwise ();
	}
	
	public void RotateRightCounterClockwise()
	{
		_fullCubeView.RotateRightCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateRightCounterClockwise ();
	}
	
	/************************************************************************************************/
	
	public void RotateFrontClockwise()
	{
		_fullCubeView.RotateFrontClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateFrontClockwise ();
	}
	
	public void RotateFrontCounterClockwise()
	{
		_fullCubeView.RotateFrontCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateFrontCounterClockwise ();
	}
	
	public void RotateMiddleFaceClockwise()
	{
		_fullCubeView.RotateMiddleFaceClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateMiddleFaceClockwise ();
	}
	
	public void RotateMiddleFaceCounterClockwise()
	{
		_fullCubeView.RotateMiddleFaceCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateMiddleFaceCounterClockwise ();
	}
	
	public void RotateBackClockwise()
	{
		_fullCubeView.RotateBackClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateBackClockwise ();
	}
	
	public void RotateBackCounterClockwise()
	{
		_fullCubeView.RotateBackCounterClockwise (_fullCubeModel.GetRubiksCube());
		_fullCubeModel.RotateBackCounterClockwise ();
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
		return _fullCubeModel.GetRubiksCube ();
	}

	public int[] GetCubeCoordinates(CubeModel tempCube)
	{
		return _fullCubeModel.GetCubeCoordinates (tempCube);
	}

	public int GetRotationDegree()
	{
		return this._rotationDegree;
	}

	public void IncreaseStage ()
	{
		this.STAGE = this.STAGE + 1;
	}

	/*public void SetSolving(bool isSolving)
	{
		this._solving = isSolving;
	}*/

	public void AddAction(int method)
	{
		this.ActionQue.Add (method);
	}

	public void SetResources (RubiksCubeModel fullCubeModel, RubiksCubeView fullCubeView, RubiksCubeSolver fullCubeSolver, CubeModel[] cubeArrayTop, CubeModel[] cubeArrayMiddleHorizontal, CubeModel[] cubeArrayBottom)
	{
		this._fullCubeModel = fullCubeModel;
		this._fullCubeView = fullCubeView;
		this._fullCubeSolver = fullCubeSolver;

		//this._fullCubeModel.SetRubiksCubeController (this);
		this._fullCubeView.SetRubiksCubeController (this);
		this._fullCubeSolver.SetRubiksCubeController (this);

		this._cubeArrayTop = cubeArrayTop;
		this._cubeArrayMiddleHorizontal = cubeArrayMiddleHorizontal;
		this._cubeArrayBottom = cubeArrayBottom;

		for (int i = 0; i < 9; i++)
		{
			this._cubeArrayTop[i].SetRubiksCubeController(this);
			this._cubeArrayMiddleHorizontal[i].SetRubiksCubeController(this);
			this._cubeArrayBottom[i].SetRubiksCubeController(this);

			_fullCubeModel.GiveCubes(this._cubeArrayTop, this._cubeArrayMiddleHorizontal, this._cubeArrayBottom);
		}
	}

	/**************************************INITIALIZATION FUNCTIONS*****************************************/

	public bool IsComplete()
	{
		return _fullCubeModel.IsComplete ();
	}

	public void InitializeRubiksCube()
	{
		_fullCubeModel.InitializeRubiksCube ();
	}
	
	public void InitializeCubeColors()
	{
		_fullCubeModel.InitializeCubeColors ();
	}

	/*****************************************SOLVING FUNCTIONS*********************************************/

	public void SolveCube()
	{
		//Main method to solve cube
		//Remember technically the cube will be "upside down" after the first side is solved
		//solver will determine set of rotation patterns to apply 
		//then will return list of actions for controller to take
		if (STAGE <= STAGE_COUNT)
		{
			if( ActionQue.Count == 0 )
			{
				switch(STAGE)
				{
					case 1:
						Debug.Log("STAGE 1");
						_fullCubeSolver.SolveTopCrossMiddle (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 2:
						Debug.Log("STAGE 2");
						_fullCubeSolver.SolveTopCross (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 3:
						Debug.Log("STAGE 3");
						_fullCubeSolver.SolveTopCorners (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 4:
						Debug.Log("STAGE 4");
						_fullCubeSolver.SpinMiddle (_fullCubeModel.GetRubiksCubeArray());
						//we flip the cube cause thats the orientation I know how to solve it =/
						RotateCubeForward();
						RotateCubeForward();
						break;
					case 5:
						Debug.Log("STAGE 5");
						_fullCubeSolver.SolveMiddleSides (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 6:
						Debug.Log("STAGE 6");
						_fullCubeSolver.SolveBottomCross (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 7:
						Debug.Log("STAGE 7");
						_fullCubeSolver.SolveBottomCrossSides (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 8:	
						Debug.Log("STAGE 8");
						_fullCubeSolver.SolveBottomCorners (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 9:
						Debug.Log("STAGE 9");
						_fullCubeSolver.FinishBottomCorners (_fullCubeModel.GetRubiksCubeArray());
						break;
					case 10:
						Debug.Log("STAGE 10");
						_fullCubeSolver.SpinToWin (_fullCubeModel.GetRubiksCubeArray());
						break;
					default:
						Debug.Log("SOLVE COMPLETE!");
						break;
				}
			}
		}
	}

}
