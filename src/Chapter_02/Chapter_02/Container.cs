using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_02
{
	internal class Container
	{
		private double _amount = 0;
		private ICollection<Container> _group;

        public Container()
        {
			_group = new HashSet<Container>();
		}

		public double GetAmount()
		{
			return _amount;
		}

		public void ConnectTo(Container otherContainer)
		{
			if (otherContainer._group == _group)
				return;

			var currentGroupSize = _group.Count;
			var otherGroupSize = otherContainer._group.Count;

			var totalAmount = _amount * currentGroupSize;
			var otherGroupTotal = otherContainer._amount * otherGroupSize;
			var newTotalAmount = (totalAmount + otherGroupTotal) / (currentGroupSize + otherGroupSize);

			// Update the group of the other container
			foreach (var container in otherContainer._group)
			{
				_group.Add(container); 
				container._group = _group;
			}

			// Update the total of all 
			foreach (var container in _group)
			{
				container._amount = newTotalAmount;
			}
		}

		public void AddWater(double amount)
		{
			var newAmountPerContainer = amount / _group.Count;
			foreach (var item in _group)
			{
				item._amount = newAmountPerContainer;
			}
		}

		/* For the following scenarios that will give the following results:
		 *  __________________________________________________________________________
		 * |    Scenario    |       Size (Calculations)              |  Size (bytes)  |
		 * |--------------------------------------------------------------------------|
		 * | 1000 isolated  |  1000 * (12 + 8 + 4 + 52 + 32)         |    108000      |               
		 * |--------------------------------------------------------------------------|
		 * |100 groups of 10| 1000 ∗ (12 + 8 + 4) + 100 ∗ (52 + 10 ∗ 32) | 61200      |
		 * |__________________________________________________________________________
		 */

	}
}
