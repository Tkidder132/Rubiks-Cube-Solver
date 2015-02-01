﻿using UnityEngine;
using System.Collections;

public class RubiksCubeSolver : MonoBehaviour
{
	private RubiksCubeController fullCubeController;
	private ArrayList ActionsList = new ArrayList();

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
		//second rotate the rest of the cross sides
		//TODO: SOLVE WHITE/TOP SIDE
	}
	
	public void SolveTopCorners(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE WHITE/TOP SIDE
	}
	
	public void SpinMiddle(CubeModel[,,] fullCubeModel)
	{
		//TODO: SPIN MIDDLE COLORS TO MATCHING FACE
	}
	
	public void SolveMiddleSides(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE MIDDLE SIDES
	}
	
	public void SolveBottomCross(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE YELLOW/BOTTOM CROSS
	}
	
	public void SolveBottomCrossSides(CubeModel[,,] fullCubeModel)
	{
		//TODO: SOLVE BOTTOM CROSS SIDES
	}
	
	public void SolveBottomCorners(CubeModel[,,] fullCubeModel)
	{
		//TODO: PLACE CORNERS IN RIGHT SPOT
	}
	
	public void FinishBottomCorners(CubeModel[,,] fullCubeModel)
	{
		//TODO: SPIN CORNERS TO RIGHT DIRECTION
	}
	
	public void SpinToWin(CubeModel[,,] fullCubeModel)
	{
		//TODO: SPIN COLORS TO MATCH AND FINISH
	}
}
