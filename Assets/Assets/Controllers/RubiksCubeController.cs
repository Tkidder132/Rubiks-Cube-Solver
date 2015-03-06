using UnityEngine;
using System.Collections;

public class RubiksCubeController : MonoBehaviour
{
	private int _rotationDegree = 90;
	private static int STAGE_COUNT = 10;
	private int STAGE = 1;
	//private bool _solving;

	RubiksCubeModel _fullCubeModel;
	RubiksCubeView _fullCubeView;
	RubiksCubeSolver _fullCubeSolver;

	ActionQueueController _queueController;

	CubeModel[] _cubeArrayTop;
	CubeModel[] _cubeArrayMiddleHorizontal;
	CubeModel[] _cubeArrayBottom;

	// Update is called once per frame
	private void Update ()
	{
		if (_queueController.GetQueueCount() > 0)
		{
			if (!IsRotating ())
			{
				CallMethod(_queueController.GetNextMethod());
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
		_fullCubeModel.RotateTopClockwise ();
		_fullCubeView.RotateTopClockwise (_fullCubeModel.GetRubiksCube());
	}

	public void RotateTopCounterClockwise()
	{
		_fullCubeModel.RotateTopCounterClockwise ();
		_fullCubeView.RotateTopCounterClockwise (_fullCubeModel.GetRubiksCube());
	}

	public void RotateMiddleHorizontalLeft()
	{
		_fullCubeModel.RotateMiddleHorizontalLeft();
		_fullCubeView.RotateMiddleHorizontalLeft (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateMiddleHorizontalRight()
	{
		_fullCubeModel.RotateMiddleHorizontalRight ();
		_fullCubeView.RotateMiddleHorizontalRight (_fullCubeModel.GetRubiksCube());
	}

	public void RotateBottomClockwise()
	{
		_fullCubeModel.RotateBottomClockwise ();
		_fullCubeView.RotateBottomClockwise (_fullCubeModel.GetRubiksCube());
	}

	public void RotateBottomCounterClockwise()
	{
		_fullCubeModel.RotateBottomCounterClockwise ();
		_fullCubeView.RotateBottomCounterClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	/************************************************************************************************/
	
	public void RotateLeftClockwise()
	{
		_fullCubeModel.RotateLeftClockwise ();
		_fullCubeView.RotateLeftClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateLeftCounterClockwise()
	{
		_fullCubeModel.RotateLeftCounterClockwise ();
		_fullCubeView.RotateLeftCounterClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateMiddleVerticalForward()
	{
		_fullCubeModel.RotateMiddleVerticalForward ();
		_fullCubeView.RotateMiddleVerticalForward (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateMiddleVerticalBackwards()
	{
		_fullCubeModel.RotateMiddleVerticalBackwards ();
		_fullCubeView.RotateMiddleVerticalBackwards (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateRightClockwise()
	{
		_fullCubeModel.RotateRightClockwise ();
		_fullCubeView.RotateRightClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateRightCounterClockwise()
	{
		_fullCubeModel.RotateRightCounterClockwise ();
		_fullCubeView.RotateRightCounterClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	/************************************************************************************************/
	
	public void RotateFrontClockwise()
	{
		_fullCubeModel.RotateFrontClockwise ();
		_fullCubeView.RotateFrontClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateFrontCounterClockwise()
	{
		_fullCubeModel.RotateFrontCounterClockwise ();
		_fullCubeView.RotateFrontCounterClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateMiddleFaceClockwise()
	{
		_fullCubeModel.RotateMiddleFaceClockwise ();
		_fullCubeView.RotateMiddleFaceClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateMiddleFaceCounterClockwise()
	{
		_fullCubeModel.RotateMiddleFaceCounterClockwise ();
		_fullCubeView.RotateMiddleFaceCounterClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateBackClockwise()
	{
		_fullCubeModel.RotateBackClockwise ();
		_fullCubeView.RotateBackClockwise (_fullCubeModel.GetRubiksCube());
	}
	
	public void RotateBackCounterClockwise()
	{
		_fullCubeModel.RotateBackCounterClockwise ();
		_fullCubeView.RotateBackCounterClockwise (_fullCubeModel.GetRubiksCube());
	}

	/*****************************************UTILITY FUNCTIONS*********************************************/

	public void ShuffleCube(int shuffleTimes)
	{
		int randMethod;
		for (var i = 0; i < shuffleTimes; i++) 
		{
			randMethod = Random.Range(0, 24);

			_queueController.AddToQueue(randMethod);
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
		_queueController.AddToQueue (method);
	}

	public void SetResources (RubiksCubeModel fullCubeModel, RubiksCubeView fullCubeView, RubiksCubeSolver fullCubeSolver, 
	                          CubeModel[] cubeArrayTop, CubeModel[] cubeArrayMiddleHorizontal, CubeModel[] cubeArrayBottom, 
	                          ActionQueueController queueController, ActionQueueModel queueModel)
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

		this._queueController = queueController;
		this._queueController.SetActionQueueModel (queueModel);

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
			if( _queueController.GetQueueCount() == 0 )
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
						//we flip the cube cause thats the orientation I know how to solve it
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
