using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.CollectionView.Data;
using DemoCenter.Maui.DemoModules.Grid.Data;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views;

public class ShimmerViewModel: INotifyPropertyChanged {
	public event PropertyChangedEventHandler PropertyChanged;
	private const int LoadingDelay = 3500;

	private List<HouseElement> houseItems;
	public List<HouseElement> HouseItems {
		get => houseItems;
		set {
			houseItems = value;
			OnPropertyChanged();
		}
	}

	private List<HumanElement> humanItems;
	public List<HumanElement> HumanItems {
		get => humanItems;
		set {
			humanItems = value;
			OnPropertyChanged();
		}
	}

	private bool dealersLoading = true;
	public bool DealersLoading {
		get => dealersLoading;
		set {
			dealersLoading = value;
			OnPropertyChanged();
		}
	}

	public ShimmerViewModel() {
		HumanItems = Enumerable.Range(0, 5).Select(_ => new HumanElement()).ToList();
		HouseItems = Enumerable.Range(0, 4).Select(_ => new HouseElement()).ToList();
	}

	public async Task LoadDataAsync() {
		await Task.Delay(LoadingDelay);
		HouseItems = LoadHousesItems();
		HumanItems = LoadContactsItems();
		DealersLoading = false;
	}

	private static List<HumanElement> LoadContactsItems() {
		var repository = new EmployeesRepository();
		return repository.Employees.Select(customer => new HumanElement() {
			Name = customer.FullName,
			Deals = $"{Random.Shared.Next(50, 200)} Deals",
			Photo = customer.Image
		}).Take(6).ToList();
	}

	private static List<HouseElement> LoadHousesItems() {
		var repository = new HouseSalesRepository();
		return repository.Houses.Select(house => new HouseElement() {
			Photo = house.ImageSource,
			Description = TypeToString(house.Type),
			Address = house.Address,
			Price = house.Price
		}).Take(8).ToList();
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private static string TypeToString(PropertyType type) {
		switch (type) {
			case PropertyType.SingleFamilyHome:
				return "Single Family Home";
			case PropertyType.Townhome:
				return "Condo/Townhouse";
			case PropertyType.MultiFamilyHome:
				return "Multi-Family Home";
			default:
				throw new ArgumentOutOfRangeException(nameof(type), type, null);
		}
	}
}

public class HumanElement {
	public string Name { get; set; }
	public string Deals { get; set; }
	public ImageSource Photo { get; set; }
}

public class HouseElement {
	public ImageSource Photo { get; set; }
	public string Description { get; set; }
	public string Address { get; set; }
	public decimal Price { get; set; }
}
