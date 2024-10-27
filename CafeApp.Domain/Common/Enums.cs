﻿namespace CafeApp.Domain.Common
{
    public enum Gender
	{
		Female=0,
		Male=1		
	}
	public enum AttendaceType
	{
		Exit=0,
		Enter=1
	}
	public enum InventoryLogState
	{
		Out=0,
		In=1
	}
	public enum InventoryLogDescription
	{
		Buy=0,
		Sell=1,
		Used=2,
		Wasted=3
	}
	public enum FactorType
	{
		OutSide=0,
		Inside=1
	}
	public enum FactorState
	{
		Cancelled=0,
		Completed=1,
		InProgress=2
	}
	public enum Platform
	{
		Web=0,
		App=1
	}
}
