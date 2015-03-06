using UnityEngine;
using System.Collections;

public class ActionQueueController : MonoBehaviour
{
	ActionQueueModel _queueModel;

	public void AddToQueue(int method)
	{
		_queueModel.AddToQueue (method);
	}
	
	public int GetNextMethod()
	{
		return _queueModel.GetNextMethod ();
	}

	public int GetQueueCount()
	{
		return _queueModel.GetQueueCount ();
	}
	
	public ArrayList getHistoryQueue()
	{
		return _queueModel.getHistoryQueue ();
	}

	public void SetActionQueueModel (ActionQueueModel queueModel)
	{
		this._queueModel = queueModel;
	}
}
