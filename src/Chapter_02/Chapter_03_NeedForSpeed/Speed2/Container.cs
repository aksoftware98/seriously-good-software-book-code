using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_03_NeedForSpeed.Speed2
{
	/// <summary>
	/// Contianer class with th logic of adding a connection in a constant time
	/// </summary>
	internal class Container
	{

		private double _amount;
		private Container _next;

        public Container()
        {
			_next = this;
		}

		public void ConnectTo(Container otherContainer)
		{
			var oldNext = _next;
			_next = otherContainer._next;
			otherContainer._next = oldNext;
		}

		public void AddWater(double newAmount)
		{
			_amount = newAmount;
		}

		/// <summary>
		/// Delay the calculation of the _amount of each container the GetAmount() gets called
		/// with the that we can have a single step execution for the connect() but O(n) for steps execution
		/// </summary>
		/// <returns></returns>
		public double GetAmount()
		{
			var current = this;
			var groupSize = 0;
			double totalAmount = 0;

			do
			{
				groupSize++;
				totalAmount += current._amount;
				current = current._next;
			} while (current != this);

			var newAmount = totalAmount / groupSize; 
			
			do
			{
				current._amount = newAmount;
				current = current._next;
			}
			while (current != this);

			return totalAmount;
		}


	}
}
