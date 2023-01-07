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
	}
}
