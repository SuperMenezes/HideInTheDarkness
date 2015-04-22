using UnityEngine;
using System.Collections;

public class Timer {

	private float m_count = 0.0f;
	private float m_timer = 0.0f;
	
	private bool m_started = false;
	
	public Timer(float timer)
	{
		m_timer = timer;
	}

	public bool Started
	{
		get { return m_started; }
	}
	
	public bool Finished
	{
		get { return m_count >= m_timer; }
	}
	
	public void Reset(bool Reset)
	{
		m_count = 0.0f;
		m_started = Reset;
	}
	
	public void Start()
	{
		m_count = 0.0f;
		m_started = true;
	}
	
	public bool Update()
	{
		if (m_count < m_timer)
			m_count += (float)Time.deltaTime;
		if (m_count >= m_timer)
			return true;
		return false;
	}
	
	public string ElapsedTimeString
	{
		get { return m_count.ToString("00.00"); }
	}
	
	public string RemainingTimeString
	{
		get { return (m_timer - m_count).ToString("00.00"); }
	}
	
	public float ElapsedTime
	{
		get { return m_count; }
	}
	
	public float RemainingTime
	{
		get { return (m_timer - m_count); }
	}
	
}