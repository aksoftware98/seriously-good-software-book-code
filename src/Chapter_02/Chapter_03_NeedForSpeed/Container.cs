using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_03_NeedForSpeed;

/// <summary>
/// Contianer class optimzed for the process of adding water to be done a single step 
/// </summary>
internal class ContainerForConstantAddingWater
{

    private GroupForConstantAddingWater? _group = null;
    public ContainerForConstantAddingWater()
    {
        _group = new(this);
    }

	public void AddWater(double amount)
    {
		var newAmountPerContainer = amount / _group._members.Count;
		_group._amountPerContainer += newAmountPerContainer;
	}

	public void ConnectTo(ContainerForConstantAddingWater otherContainer)
    {
		if (_group == otherContainer._group)
			return;

		var currentGroupSize = _group._members.Count;
		var otherGroupSize = otherContainer._group._members.Count;

		var totalAmount = _group._amountPerContainer * currentGroupSize;
		var otherGroupTotalAmount = otherContainer._group._amountPerContainer * otherGroupSize;
		var newTotalAmount = (totalAmount + otherGroupTotalAmount) / (currentGroupSize + otherGroupSize);

		_group._amountPerContainer = newTotalAmount / _group._members.Count;
		foreach (var item in otherContainer._group._members)
		{
			item._group = _group;
			_group._members.Add(item);
		}
    }

	public double GetAmount()
    {
        return _group?.GetAmountPerContainer() ?? 0;
    }

	internal class GroupForConstantAddingWater
	{
		internal double _amountPerContainer;
		internal ICollection<ContainerForConstantAddingWater> _members;

		public GroupForConstantAddingWater(ContainerForConstantAddingWater container)
		{
			_members = new HashSet<ContainerForConstantAddingWater>();
			_members.Add(container);
		}

		public double GetAmountPerContainer()
		{
			return _amountPerContainer;
		}

	}
}


