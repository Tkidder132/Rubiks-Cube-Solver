using UnityEngine;
using System.Collections;

public class RubiksMain : MonoBehaviour
{
	public CubeModel[] _cubeArrayTop = new CubeModel[9];
	public CubeModel[] _cubeArrayMiddleHorizontal = new CubeModel[9];
	public CubeModel[] _cubeArrayBottom = new CubeModel[9];

	public RubiksCubeModel _fullCubeModel;
	public RubiksCubeView _fullCubeView;
	public RubiksCubeController _fullCubeController;
	public RubiksCubeSolver _fullCubeSolver;

	public ActionQueueController _queueController;
	public ActionQueueModel _queueModel;

	//Top = 0, Middle = 1, Bottom = 2
	int _level = 0;

	// Use this for initialization
	private void Start ()
	{
		_fullCubeController.SetResources (this._fullCubeModel, this._fullCubeView, this._fullCubeSolver, 
										this._cubeArrayTop, this._cubeArrayMiddleHorizontal, this._cubeArrayBottom,
		                                  this._queueController, this._queueModel);
		_fullCubeController.InitializeRubiksCube ();
		_fullCubeController.InitializeCubeColors ();
		_fullCubeController.ShuffleCube(25);
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if( Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			if( this._level == 0 )
			{
				if( !_fullCubeController.IsRotating() )
				{
					_fullCubeController.RotateTopClockwise ();
				}
			}
			else if( this._level == 1 )
			{
				if( !_fullCubeController.IsRotating() )
				{
					_fullCubeController.RotateMiddleHorizontalLeft();
				}
			}
			else
			{
				if( !_fullCubeController.IsRotating() )
				{
					_fullCubeController.RotateBottomCounterClockwise();
				}
			}
		}

		if( Input.GetKeyDown(KeyCode.RightArrow) )
		{
			if( this._level == 0 )
			{
				if( !_fullCubeController.IsRotating() )
				{
					_fullCubeController.RotateTopCounterClockwise ();
				}
			}
			else if( this._level == 1 )
			{
				if( !_fullCubeController.IsRotating() )
				{
					_fullCubeController.RotateMiddleHorizontalRight();
				}
			}
			else
			{
				if( !_fullCubeController.IsRotating() )
				{
					_fullCubeController.RotateBottomClockwise();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Q))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateLeftCounterClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.A))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateLeftClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.W))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateMiddleVerticalBackwards();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.S))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateMiddleVerticalForward();
			}
		}

		if (Input.GetKeyDown (KeyCode.D))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateRightCounterClockwise();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.E))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateRightClockwise();
			}
		}



		if (Input.GetKeyDown (KeyCode.N))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateFrontClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.B))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateFrontCounterClockwise();
			}
		}


		if (Input.GetKeyDown (KeyCode.H))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateMiddleFaceClockwise();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.G))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateMiddleFaceCounterClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.T))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateBackClockwise();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Y))
		{
			if( !_fullCubeController.IsRotating() )
			{
				_fullCubeController.RotateBackCounterClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			if( this._level > 0 )
			{
				this._level--;
			}
			else
			{

			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			if( this._level < 2 )
			{
				this._level++;
			}
			else
			{

			}
		}

		if (_fullCubeController.IsComplete ())
		{
			Debug.Log("COMPLETE!");
		}
	}

}