﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch06_01
{
	class Program
	{
		static void Main(string[] args)
		{
			Turtle arthurTheTurtle =
				new Turtle { PlatformWidth = 10.0, PlatformHeight = 10.0, MotorSpeed = 5.0 };

			ShowPosition(arthurTheTurtle);

			// 前進。
			arthurTheTurtle.LeftMotorState = MotorState.Running;
			arthurTheTurtle.RightMotorState = MotorState.Running;

			// 2秒間。
			arthurTheTurtle.RunFor(2.0);
			ShowPosition(arthurTheTurtle);

			// 時計回りに少し回転。
			arthurTheTurtle.RightMotorState = MotorState.Reversed;

			// PI/2秒。
			arthurTheTurtle.RunFor(Math.PI / 2.0);
			ShowPosition(arthurTheTurtle);

			// 後退。
			arthurTheTurtle.LeftMotorState = MotorState.Reversed;
			arthurTheTurtle.RightMotorState = MotorState.Reversed;

			// 5秒間。
			arthurTheTurtle.RunFor(5);
			ShowPosition(arthurTheTurtle);

			// 反時計回りに回転。
			arthurTheTurtle.RightMotorState = MotorState.Running;

			// PI/4秒間で45度。
			arthurTheTurtle.RunFor(Math.PI / 4.0);
			ShowPosition(arthurTheTurtle);

			// 少し後退。
			arthurTheTurtle.RightMotorState = MotorState.Reversed;
			arthurTheTurtle.LeftMotorState = MotorState.Reversed;
			arthurTheTurtle.RunFor(Math.Cos(Math.PI / 4.0));

			ShowPosition(arthurTheTurtle);

			Console.ReadKey();
		}

		private static void ShowPosition(Turtle arthurTheTurtle)
		{
			Console.WriteLine(
				"Arthurの位置は({0}),方向は{1:0.00}ラジアンです。",
				arthurTheTurtle.CurrentPosition,
				arthurTheTurtle.CurrentOrientation);
		}
	}
}
