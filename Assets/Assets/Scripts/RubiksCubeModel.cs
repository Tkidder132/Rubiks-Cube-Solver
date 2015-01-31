using UnityEngine;
using System.Collections;

//all the data manipulation
public class RubiksCubeModel : MonoBehaviour
{
	public RubiksCubeController fullCubeController;

	public CubeModel[,,] fullCube = new CubeModel[3,3,3];

	CubeModel[] _cubeArrayTop = new CubeModel[9];
	CubeModel[] _cubeArrayMiddleHorizontal = new CubeModel[9];
	CubeModel[] _cubeArrayBottom = new CubeModel[9];

	bool _rotating = false;

	enum Layer{TOP, MIDDLE, BOTTOM};
	enum Face{FRONT, MIDDLE, BACK};
	enum Slice{LEFT, MIDDLE, RIGHT};

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

	void RotateLayerClockwise(int layer)
	{
		var tempCube = new CubeModel ();
		
		//set corners
		tempCube = fullCube [0, 2, layer];
		fullCube [0, 2, layer] = fullCube [0, 0, layer];
		fullCube [0, 0, layer] = fullCube [2, 0, layer];
		fullCube [2, 0, layer] = fullCube [2, 2, layer];
		fullCube [2, 2, layer] = tempCube;
		
		//set sides
		tempCube = fullCube [1, 2, layer];
		fullCube [1, 2, layer] = fullCube [0, 1, layer];
		fullCube [0, 1, layer] = fullCube [1, 0, layer];
		fullCube [1, 0, layer] = fullCube [2, 1, layer];
		fullCube [2, 1, layer] = tempCube;
		
		//set middle for shits and giggles just to say we did
		fullCube [1, 1, layer] = fullCube [1, 1, layer];
	}
	
	void RotateLayerCounterClockwise(int layer)
	{
		var tempCube = new CubeModel ();

		//set corners
		tempCube = fullCube [0, 2, layer];
		fullCube [0, 2, layer] = fullCube [2, 2, layer];
		fullCube [2, 2, layer] = fullCube [2, 0, layer];
		fullCube [2, 0, layer] = fullCube [0, 0, layer];
		fullCube [0, 0, layer] = tempCube;
		
		//set sides
		tempCube = fullCube[1, 2, layer];
		fullCube [1, 2, layer] = fullCube [2, 1, layer];
		fullCube [2, 1, layer] = fullCube [1, 0, layer];
		fullCube [1, 0, layer] = fullCube [0, 1, layer];
		fullCube [0, 1, layer] = tempCube;
		
		//set middle for shits and giggles just to say we did
		fullCube [1, 1, layer] = fullCube [1, 1, layer];
	}

	public void RotateTopClockwise()
	{
		RotateLayerClockwise((int)Layer.TOP);
	}

	public void RotateTopCounterClockwise()
	{
		RotateLayerCounterClockwise ((int)Layer.TOP);
	}

	public void RotateMiddleHorizontalLeft()
	{		
		RotateLayerClockwise ((int)Layer.MIDDLE);
	}

	public void RotateMiddleHorizontalRight()
	{
		RotateLayerCounterClockwise ((int)Layer.MIDDLE);
	}

	public void RotateBottomClockwise()
	{
		RotateLayerCounterClockwise ((int)Layer.BOTTOM);
	}

	public void RotateBottomCounterClockwise()
	{
		RotateLayerClockwise ((int)Layer.BOTTOM);
	}
	
	/************************************************************************************************/

	void RotateSliceForward(int slice)
	{
		var tempCube = new CubeModel ();

		//set corners
		tempCube = fullCube [slice, 2, 0];
		fullCube[slice,2,0] = fullCube[slice,2,2];
		fullCube[slice,2,2] = fullCube[slice,0,2];
		fullCube[slice,0,2] = fullCube[slice,0,0];
		fullCube[slice,0,0] = tempCube;

		//set sides
		tempCube = fullCube [slice, 1, 0];
		fullCube [slice, 1, 0] = fullCube [slice, 2, 1];
		fullCube [slice, 2, 1] = fullCube [slice, 1, 2];
		fullCube [slice, 1, 2] = fullCube [slice, 0, 1];
		fullCube [slice, 0, 1] = tempCube;

		//set middle for shits and giggles just to say we did
		fullCube [slice, 1, 1] = fullCube [slice, 1, 1];
	}

	void RotateSliceBackward(int slice)
	{
		var tempCube = new CubeModel ();

		//set corners
		tempCube = fullCube [slice, 2, 0];
		fullCube [slice, 2, 0] = fullCube [slice, 0, 0];
		fullCube [slice, 0, 0] = fullCube [slice, 0, 2];
		fullCube [slice, 0, 2] = fullCube [slice, 2, 2];
		fullCube [slice, 2, 2] = tempCube;
		
		//set sides
		tempCube = fullCube [slice, 1, 0];
		fullCube [slice, 1, 0] = fullCube [slice, 0, 1];
		fullCube [slice, 0, 1] = fullCube [slice, 1, 2];
		fullCube [slice, 1, 2] = fullCube [slice, 2, 1];
		fullCube [slice, 2, 1] = tempCube;
		
		//set middle for shits and giggles just to say we did
		fullCube [slice, 1, 1] = fullCube [slice, 1, 1];
	}

	public void RotateLeftClockwise()
	{
		RotateSliceForward ((int)Slice.LEFT);
	}
	
	public void RotateLeftCounterClockwise()
	{
		RotateSliceBackward ((int)Slice.LEFT);
	}
	
	public void RotateMiddleVerticalForward()
	{
		RotateSliceForward ((int)Slice.MIDDLE);
	}
	
	public void RotateMiddleVerticalBackwards()
	{
		RotateSliceBackward ((int)Slice.MIDDLE);
	}
	
	public void RotateRightClockwise()
	{
		RotateSliceBackward ((int)Slice.RIGHT);
	}
	
	public void RotateRightCounterClockwise()
	{
		RotateSliceForward ((int)Slice.RIGHT);
	}
	
	/************************************************************************************************/

	void RotateFaceClockwise (int face)
	{
		var tempCube = new CubeModel ();

		//set corners
		tempCube = fullCube [0, face, 0];
		fullCube [0, face, 0] = fullCube [0, face, 2];
		fullCube [0, face, 2] = fullCube [2, face, 2];
		fullCube [2, face, 2] = fullCube [2, face, 0];
		fullCube [2, face, 0] = tempCube;
		
		//set sides
		tempCube = fullCube [1, face, 0];
		fullCube [1, face, 0] = fullCube [0, face, 1];
		fullCube [0, face, 1] = fullCube [1, face, 2];
		fullCube [1, face, 2] = fullCube [2, face, 1];
		fullCube [2, face, 1] = tempCube;
		
		//set middle for shits and giggles just to say we did
		fullCube [1, face, 1] = fullCube [1, face, 1];
	}

	void RotateFaceCounterClockwise(int face)
	{
		var tempCube = new CubeModel ();

		//set corners
		tempCube = fullCube [0, face, 0];
		fullCube [0, face, 0] = fullCube [2, face, 0];
		fullCube [2, face, 0] = fullCube [2, face, 2];
		fullCube [2, face, 2] = fullCube [0, face, 2];
		fullCube [0, face, 2] = tempCube;

		//set sides
		tempCube = fullCube [1, face, 0];
		fullCube [1, face, 0] = fullCube [2, face, 1];
		fullCube [2, face, 1] = fullCube [1, face, 2];
		fullCube [1, face, 2] = fullCube [0, face, 1];
		fullCube [0, face, 1] = tempCube;

		fullCube [1, face, 1] = fullCube [1, face, 1];
	}

	public void RotateFrontClockwise()
	{
		RotateFaceClockwise((int)Face.FRONT);
	}
	
	public void RotateFrontCounterClockwise()
	{
		RotateFaceCounterClockwise ((int)Face.FRONT);
	}
	
	public void RotateMiddleFaceClockwise()
	{
		RotateFaceClockwise ((int)Face.MIDDLE);
	}
	
	public void RotateMiddleFaceCounterClockwise()
	{
		RotateFaceCounterClockwise ((int)Face.MIDDLE);
	}
	
	public void RotateBackClockwise()
	{
		RotateFaceCounterClockwise ((int)Face.BACK);
	}
	
	public void RotateBackCounterClockwise()
	{
		RotateFaceClockwise ((int)Face.BACK);
	}

	/**************************************INITIALIZATION FUNCTIONS*****************************************/

	public void GiveCubes(CubeModel[] cubeArrayTop, CubeModel[] cubeArrayMiddleHorizontal, CubeModel[] cubeArrayBottom)
	{
		this._cubeArrayTop = cubeArrayTop;
		this._cubeArrayMiddleHorizontal = cubeArrayMiddleHorizontal;
		this._cubeArrayBottom = cubeArrayBottom;
	}

	public void InitializeRubiksCube()
	{
		int counter = 0;
		
		//Top part of cube
		for (var y = 2; y >= 0; y--)
		{
			for( var x = 0; x < 3; x++ )
			{
				fullCube[x,y,0] = this._cubeArrayTop[counter];
				counter++;
			}
		}

		counter = 0;
		//middle part of cube
		for (var y = 2; y >= 0; y--)
		{
			for( var x = 0; x < 3; x++ )
			{
				fullCube[x,y,1] = this._cubeArrayMiddleHorizontal[counter];
				counter++;
			}
		}

		counter = 0;
		//bottom part of cube
		for (var y = 2; y >= 0; y--)
		{
			for( var x = 0; x < 3; x++ )
			{
				fullCube[x,y,2] = this._cubeArrayBottom[counter];
				counter++;
			}
		}
	}

	public void InitializeCubeColors()
	{
		Color front, back, left, right, top, bottom;
		for( var x = 0; x < 3; x++ )
		{
			for( var y = 0; y < 3; y++) 
			{
				for( var z = 0; z < 3; z++ )
				{

					if( x == 0 )
					{
						left = Color.green;
						right = Color.black;
					}
					else if( x == 2 )
					{
						left = Color.black;
						right = Color.blue;
					}
					else
					{
						left = Color.black;
						right = Color.black;
					}
					
					if( y == 0 )
					{
						front = Color.red;
						back = Color.black;
					}
					else if( y == 2 )
					{
						//we are using magenta for orange because for some reason unity doesn't have color.orange built in
						front = Color.black;
						back = Color.magenta;
					}
					else
					{
						front = Color.black;
						back = Color.black;
					}
					
					if( z == 0 )
					{
						top = Color.white;
						bottom = Color.black;
					}
					else if( z == 2 )
					{
						top = Color.black;
						bottom = Color.yellow;
					}
					else
					{
						top = Color.black;
						bottom = Color.black;
					}

					Color[] faces = {front, back, left, right, top, bottom};
					fullCube[x, y, z].SetColors(faces);
				}
			}
		}
	}

	/*****************************************UTILITY FUNCTIONS*********************************************/
	
	public void SetRotating(bool rotating)
	{
		this._rotating = rotating;
	}
	
	public bool IsRotating()
	{
		return this._rotating;
	}
	
	public void SetRubiksCubeBlock(CubeModel cube, int x, int y, int z)
	{
		fullCube [x, y, z] = cube;
	}
	
	public CubeModel GetRubiksCubeBlock(int x, int y, int z)
	{
		return fullCube [x, y, z];
	}
	
	public RubiksCubeModel GetRubiksCube()
	{
		return this;
	}

	public bool IsComplete()
	{
		Color front, back, left, right, top, bottom;
		for( var x = 0; x < 3; x++ )
		{
			for( var y = 0; y < 3; y++) 
			{
				for( var z = 0; z < 3; z++ )
				{
					
					if( x == 0 )
					{
						left = Color.green;
						right = Color.black;
					}
					else if( x == 2 )
					{
						left = Color.black;
						right = Color.blue;
					}
					else
					{
						left = Color.black;
						right = Color.black;
					}
					
					if( y == 0 )
					{
						front = Color.red;
						back = Color.black;
					}
					else if( y == 2 )
					{
						//we are using magenta for orange because for some reason unity doesn't have color.orange built in
						front = Color.black;
						back = Color.magenta;
					}
					else
					{
						front = Color.black;
						back = Color.black;
					}
					
					if( z == 0 )
					{
						top = Color.white;
						bottom = Color.black;
					}
					else if( z == 2 )
					{
						top = Color.black;
						bottom = Color.yellow;
					}
					else
					{
						top = Color.black;
						bottom = Color.black;
					}

					Color[] faces = {front, back, left, right, top, bottom};
					if( !fullCube[x, y, z].CheckColors(faces) )
					{
						return false;
					}
				}
			}
		}
		return true;
	}

}
