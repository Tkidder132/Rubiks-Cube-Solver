using UnityEngine;
using System.Collections;

public class RubiksMain : MonoBehaviour
{
	public CubeModel[] _cubeArrayTop = new CubeModel[9];
	public CubeModel[] _cubeArrayMiddleHorizontal = new CubeModel[9];
	public CubeModel[] _cubeArrayBottom = new CubeModel[9];

	public RubiksCubeModel fullCubeModel;
	public RubiksCubeView fullCubeView;
	public RubiksCubeController fullCubeController;
	public RubiksCubeSolver fullCubeSolver;

	//Top = 0, Middle = 1, Bottom = 2
	int _level = 0;

	// Use this for initialization
	private void Start ()
	{
		fullCubeController.SetResources (fullCubeModel, fullCubeView, fullCubeSolver, 
										this._cubeArrayTop, this._cubeArrayMiddleHorizontal, this._cubeArrayBottom);
		fullCubeController.InitializeRubiksCube ();
		fullCubeController.InitializeCubeColors ();
		fullCubeController.ShuffleCube(10);
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if( Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			if( this._level == 0 )
			{
				if( !fullCubeController.IsRotating() )
				{
					fullCubeController.RotateTopClockwise ();
				}
			}
			else if( this._level == 1 )
			{
				if( !fullCubeController.IsRotating() )
				{
					fullCubeController.RotateMiddleHorizontalLeft();
				}
			}
			else
			{
				if( !fullCubeController.IsRotating() )
				{
					fullCubeController.RotateBottomCounterClockwise();
				}
			}
		}

		if( Input.GetKeyDown(KeyCode.RightArrow) )
		{
			if( this._level == 0 )
			{
				if( !fullCubeController.IsRotating() )
				{
					fullCubeController.RotateTopCounterClockwise ();
				}
			}
			else if( this._level == 1 )
			{
				if( !fullCubeController.IsRotating() )
				{
					fullCubeController.RotateMiddleHorizontalRight();
				}
			}
			else
			{
				if( !fullCubeController.IsRotating() )
				{
					fullCubeController.RotateBottomClockwise();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Q))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateLeftCounterClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.A))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateLeftClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.W))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateMiddleVerticalBackwards();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.S))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateMiddleVerticalForward();
			}
		}

		if (Input.GetKeyDown (KeyCode.D))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateRightCounterClockwise();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.E))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateRightClockwise();
			}
		}



		if (Input.GetKeyDown (KeyCode.N))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateFrontClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.B))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateFrontCounterClockwise();
			}
		}


		if (Input.GetKeyDown (KeyCode.H))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateMiddleFaceClockwise();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.G))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateMiddleFaceCounterClockwise();
			}
		}

		if (Input.GetKeyDown (KeyCode.T))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateBackClockwise();
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Y))
		{
			if( !fullCubeController.IsRotating() )
			{
				fullCubeController.RotateBackCounterClockwise();
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

		if (fullCubeController.IsComplete ())
		{
			Debug.Log("COMPLETE!");
		}
	}

}