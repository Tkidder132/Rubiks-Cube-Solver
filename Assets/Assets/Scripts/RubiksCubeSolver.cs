using UnityEngine;
using System.Collections;

public class RubiksCubeSolver : MonoBehaviour
{
	private RubiksCubeController fullCubeController;
	//private ArrayList ActionsList = new ArrayList();

	public void SetRubiksCubeController(RubiksCubeController cubeController)
	{
		this.fullCubeController = cubeController;
	}
	
	public void SolveTopCrossMiddle(CubeModel[,,] fullCubeModel)
	{
		//find the middle white piece and move it to center top
		//it can only be in one of six spots

		CubeModel temp;
		temp = fullCubeModel [1, 1, 0];
		if (temp.GetTopColor ().Equals (Color.white))
		{
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [1, 1, 2];
		if (temp.GetBottomColor ().Equals (Color.white))
		{
			fullCubeController.AddAction(9);
			fullCubeController.AddAction(9);
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [1, 0, 1];
		if (temp.GetFrontColor ().Equals (Color.white))
		{
			fullCubeController.AddAction(9);
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [1, 2, 1];
		if (temp.GetBackColor ().Equals (Color.white))
		{
			fullCubeController.AddAction(8);
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [0, 1, 1];
		if (temp.GetLeftColor ().Equals (Color.white))
		{
			fullCubeController.AddAction(14);
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [2, 1, 1];
		if (temp.GetRightColor ().Equals (Color.white))
		{
			fullCubeController.AddAction(15);
			fullCubeController.IncreaseStage();
			return;
		}
	}

	public void SolveTopCross(CubeModel[,,] fullCubeModel)
	{
		//rotate the rest of the cross sides
		//find red, orange, green, blues sides
		//each piece can only be in one of 12 spots.
		//rotate red, orange, green, blue sides to top.

								// top layer                  middle layer            bottom layer
		CubeModel[] cubeArray = {fullCubeModel[ 1, 0, 0], fullCubeModel[ 0, 0, 1], fullCubeModel[ 1, 0, 2],
								fullCubeModel[ 0, 1, 0], fullCubeModel[ 2, 0, 1], fullCubeModel[ 0, 1, 2],
								fullCubeModel[ 1, 2, 0], fullCubeModel[ 0, 2, 1], fullCubeModel[ 1, 2, 2],
								fullCubeModel[ 2, 1, 0], fullCubeModel[ 2, 2, 1], fullCubeModel[ 2, 1, 2]};

		//red, orange, blue, green
		CubeModel[] sidesArray = new CubeModel[4];
		//for every cube we've pulled out of the rubiks cube, we go through them and get their color array for each
		//then we go through color array, and if one of those pieces has white (meaning a top piece)
		//we determine what is the other color is has. 
		//then we set the sidesArray properly
		for (int i = 0; i < cubeArray.Length; i++)
		{
			Color[] temp = cubeArray[i].GetColorsArray();
			
			for( int j = 0; j < temp.Length; j++ )
			{
				if( temp[j].Equals(Color.white) )
				{
					for( int k = 0; k < temp.Length; k++ )
					{
						if( temp[k].Equals(Color.black) && temp[k].Equals(Color.white) )
						{
							/*switch(temp[i])
							{
							case Color.red:
								sidesArray[0] = cubeArray[i];
								break;
							case Color.magenta:
								sidesArray[1] = cubeArray[i];
								break;
							case Color.blue:
								sidesArray[2] = cubeArray[i];
								break;
							case Color.green:
								sidesArray[3] = cubeArray[i];
								break;
							default:
								break;
							}*/
						}
					}
				}
			}
		}

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void SolveTopCorners(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE WHITE/TOP SIDE

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void SpinMiddle(CubeModel[,,] fullCubeModel)
	{
		//TODO: SPIN MIDDLE COLORS TO MATCHING FACE

		CubeModel temp;
		temp = fullCubeModel [1, 1, 0];
		if (temp.GetFrontColor ().Equals (Color.red))
		{
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [1, 2, 1];
		if (temp.GetBackColor ().Equals (Color.red))
		{
			fullCubeController.AddAction(2);
			fullCubeController.AddAction(2);
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [0, 1, 1];
		if (temp.GetLeftColor ().Equals (Color.red))
		{
			fullCubeController.AddAction(3);
			fullCubeController.IncreaseStage();
			return;
		}

		temp = fullCubeModel [2, 1, 1];
		if (temp.GetRightColor ().Equals (Color.red))
		{
			fullCubeController.AddAction(2);
			fullCubeController.IncreaseStage();
			return;
		}
	}
	
	public void SolveMiddleSides(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE MIDDLE SIDES

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void SolveBottomCross(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE YELLOW/BOTTOM CROSS

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void SolveBottomCrossSides(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE BOTTOM CROSS SIDES

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void SolveBottomCorners(CubeModel[,,] fullCubeModel)
	{
		//TODO: PLACE CORNERS IN RIGHT SPOT

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void FinishBottomCorners(CubeModel[,,] fullCubeModel)
	{
		//TODO: SPIN CORNERS TO RIGHT DIRECTION

		fullCubeController.IncreaseStage();
		return;
	}
	
	public void SpinToWin(CubeModel[,,] fullCubeModel)
	{
		//TODO: SPIN COLORS TO MATCH AND FINISH

		fullCubeController.IncreaseStage();
		return;
	}
}
