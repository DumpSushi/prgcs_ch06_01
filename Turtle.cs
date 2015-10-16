using System;
using System.Windows;

namespace ch06_01
{
	class Turtle
	{
		// 機体の幅。
		public double PlatformWidth
		{
			get;
			set;
		}

		// 機体の高さ。
		public double PlatformHeight
		{
			get;
			set;
		}

		// モーターのスピード。単位はメートル毎秒。
		public double MotorSpeed
		{
			get;
			set;
		}

		// 左モーターの状態。
		public MotorState LeftMotorState
		{
			get;
			set;
		}

		// 右モーターの状態。
		public MotorState RightMotorState
		{
			get;
			set;
		}

		// タートルの現在位置。
		public Point CurrentPosition
		{
			get;
			private set;
		}

		// タートルの現在の方向。
		public double CurrentOrientation
		{
			get;
			private set;
		}

		// 指定した時間だけタートルを走行させます。
		public void RunFor(double duration)
		{
			if (duration <= double.Epsilon)
			{
				throw new ArgumentException(
					"0より長い時間を指定する必要があります。",
					"duration");
			}
			try
			{
				if (LeftMotorState == MotorState.Stopped &&
					RightMotorState == MotorState.Stopped)
				{
					// 完全に止まっている場合は何もしません。
					return;
				}

				// モーターが同じ方向に動いている場合には直進します。
				if ((LeftMotorState == MotorState.Running &&
					RightMotorState == MotorState.Running) ||
					(LeftMotorState == MotorState.Reversed &&
					RightMotorState == MotorState.Reversed))
				{
					Drive(duration);
					return;
				}

				// モーターが反対方向に動いている場合には回転します。
				if ((LeftMotorState == MotorState.Running &&
					RightMotorState == MotorState.Reversed) ||
					(LeftMotorState == MotorState.Reversed &&
					RightMotorState == MotorState.Running))
				{
					Rotate(duration);
					return;
				}
			}
			catch (InvalidOperationException iox)
			{
				throw new Exception("タートルに何らかの問題が発生。", iox);
			}
			catch (Exception ex)
			{
				Console.WriteLine("ログメッセージ：" + ex.Message);
				// 再スロー。
				throw;
			}
			finally
			{
				Console.WriteLine("Turtleのfinallyブロック内。");
			}
		}

		// 回転。
		private void Rotate(double duration)
		{
			if (PlatformWidth <= 0.0)
			{
				throw new InvalidOperationException(
					"PlatromWidthは0.0より大きい値に初期化しなければいけません。");
			}

			// 旋回の総円周(circumference).
			double circum = Math.PI * PlatformWidth;

			// 総移動距離。
			double d = duration * MotorSpeed;
			if (LeftMotorState == MotorState.Reversed)
			{
				// モーターが逆回転している場合は逆方向に回転します。
				d *= -1.0;
			}

			// 1周のうちで回転した割合。
			double proportionOfWholeCircle = d / circum;

			// 回転適用。
			CurrentOrientation =
				CurrentOrientation + (Math.PI * 2.0 * proportionOfWholeCircle);
		}

		// 移動。
		private void Drive(double duration)
		{
			// 総移動距離。
			double d = duration * MotorSpeed;
			if (LeftMotorState == MotorState.Reversed)
			{
				// モーターが逆回転している場合は逆方向に移動します。
				d *= -1.0;
			}

			// 移動量計算。
			double deltaX = d * Math.Sin(CurrentOrientation);
			double deltaY = d * Math.Cos(CurrentOrientation);

			// 座標更新。
			CurrentPosition = new Point(CurrentPosition.X + deltaX,
				CurrentPosition.Y + deltaY);
		}
	}
	// モーターの現在の状態。
	enum MotorState
	{
		Stopped,
		Running,
		Reversed,
	}
}
