using UnityEngine;
using System.Collections;

public class ActionQueueModel : MonoBehaviour
{
	private ArrayList _ActionQueue;
	private ArrayList _HistoryQueue;

	void Start()
	{
		_ActionQueue = new ArrayList ();
		_HistoryQueue = new ArrayList ();
	}

	public void AddToQueue(int method)
	{
		this._ActionQueue.Add(method);
		this._HistoryQueue.Add(method);
	}

	public int GetNextMethod()
	{
		int NextMethod = (int)this._ActionQueue[0];
		this._ActionQueue.RemoveAt(0);
		return NextMethod;
	}

	public int GetQueueCount()
	{
		return this._ActionQueue.Count;
	}

	public ArrayList getHistoryQueue()
	{
		return this._HistoryQueue;
	}
}
