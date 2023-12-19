using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Dispatching;

namespace DemoCenter.Maui.ViewModels;

public class RadialGaugeViewModel : NotificationObject {
    const double livingRoomBaseline = 0.8;
    const double livingRoomBaselineEco = 0.6;
    const double livingRoomAmplitude = 0.2;
    const double bedroomBaseline = 0.2;
    const double bedroomBaselineEco = 0.1;
    const double bedroomAmplitude = 0.1;
    const double kitchenBaseline = 1d;
    const double kitchenBaselineEco = 0.5;
    const double kitchenAmplitude = 0.3;
    const double solarBatteryCapacity = 200d;
    const double updateIntervalSec = 1.5d;
    static readonly Random Random = new Random((int)DateTime.Now.Ticks);

    IDispatcherTimer ticker;

    public ObservableCollection<RoomInfo> Rooms { get; }

    public RadialGaugeViewModel() {
        this.livingRoomPowerLevelBrush = new(Color.FromArgb("#9BBB72"));
        this.bedroomPowerLevelBrush = new(Color.FromArgb("#6486C9"));
        this.kitchenPowerLevelBrush = new(Color.FromArgb("#B26C79"));
        Rooms = new ObservableCollection<RoomInfo> {
            new(livingRoomBaseline, livingRoomBaselineEco, livingRoomAmplitude) { Room = "Living Room", Color = this.livingRoomPowerLevelBrush.Color, Value = 0.79 },
            new(bedroomBaseline, bedroomBaselineEco, bedroomAmplitude) { Room = "Bedroom", Color = this.bedroomPowerLevelBrush.Color, Value = 0.19 },
            new(kitchenBaseline, kitchenBaselineEco, kitchenAmplitude) { Room = "Kitchen", Color = this.kitchenPowerLevelBrush.Color, Value = 0.49 },
        };
        this.solarBatteryChargeLevel = 0.95;
    }

    public double MaxLivingRoomPowerConsumption => livingRoomBaseline + livingRoomAmplitude;
    public double MaxBedroomPowerConsumption => bedroomBaseline + bedroomAmplitude;
    public double MaxKitchenPowerConsumption => kitchenBaseline + kitchenAmplitude;
    public double MaxHoursLeft => solarBatteryCapacity / (livingRoomBaselineEco + bedroomBaselineEco + kitchenBaselineEco - livingRoomAmplitude - bedroomAmplitude - kitchenAmplitude);
    public double TotalPowerLevel => LivingRoomPowerLevel + BedroomPowerLevel + KitchenPowerLevel;
    public double HoursLeft => solarBatteryCapacity * solarBatteryChargeLevel / TotalPowerLevel;

    bool isPowerSavingEnabled;
    public bool IsPowerSavingEnabled {
        get => this.isPowerSavingEnabled;
        set {
            this.isPowerSavingEnabled = value;
            foreach (var room in Rooms) {
                room.IsPowerSavingEnabled = value;
            }
        }
    }

    double solarBatteryChargeLevel;
    public double SolarBatteryChargeLevel {
        get => this.solarBatteryChargeLevel;
        set => SetProperty(ref this.solarBatteryChargeLevel, value);
    }

    public double LivingRoomPowerLevel => Rooms[0].Value;
    public double BedroomPowerLevel => Rooms[1].Value;
    public double KitchenPowerLevel => Rooms[2].Value;

    SolidColorBrush livingRoomPowerLevelBrush;
    public SolidColorBrush LivingRoomPowerLevelBrush {
        get => livingRoomPowerLevelBrush;
        set => SetProperty(ref livingRoomPowerLevelBrush, value);
    }

    SolidColorBrush bedroomPowerLevelBrush;
    public SolidColorBrush BedroomPowerLevelBrush {
        get => bedroomPowerLevelBrush;
        set => SetProperty(ref bedroomPowerLevelBrush, value);
    }

    SolidColorBrush kitchenPowerLevelBrush;
    public SolidColorBrush KitchenPowerLevelBrush {
        get => kitchenPowerLevelBrush;
        set => SetProperty(ref kitchenPowerLevelBrush, value);
    }

    internal void StartObserving() {
        this.ticker = Dispatcher.GetForCurrentThread().CreateTimer();
        this.ticker.Interval = TimeSpan.FromSeconds(updateIntervalSec);
        this.ticker.Tick += OnIntervalTick;
        this.ticker.Start();
    }
    
    internal void StopObserving() {
        this.ticker.Tick -= OnIntervalTick;
        this.ticker.Stop();
        this.ticker = null;
    }

    void OnIntervalTick(object sender, EventArgs e) {
        foreach (var room in Rooms) {
            room.Value = room.GetNewValue(Random.NextDouble() * 2d - 1d);
        }
        OnPropertyChanged(nameof(TotalPowerLevel));
        OnPropertyChanged(nameof(LivingRoomPowerLevel));
        OnPropertyChanged(nameof(BedroomPowerLevel));
        OnPropertyChanged(nameof(KitchenPowerLevel));
        OnPropertyChanged(nameof(HoursLeft));

        var diff = Random.NextDouble() / 20d;
        double newValue;
        if ((Random.Next() % 4) == 0) {
            newValue = this.solarBatteryChargeLevel + diff;
        } else {
            newValue = this.solarBatteryChargeLevel - diff;
        }
        newValue = Math.Clamp(newValue, 0d, 1d);

        SolarBatteryChargeLevel = newValue;
    }
}

public class RoomInfo : NotificationObject {
    double baseLine;
    double baselineEco;
    double amplitude;

    public RoomInfo(double baseLine, double baselineEco, double amplitude) {
        this.baseLine = baseLine;
        this.baselineEco = baselineEco;
        this.amplitude = amplitude;
    }

    Color color;
    public Color Color {
        get => this.color;
        set => SetProperty(ref this.color, value);
    }
    double value;
    public double Value {
        get => this.value;
        set => SetProperty(ref this.value, value);
    }

    public bool IsPowerSavingEnabled { get; set; }
    public string Room { get; init; }

    public double GetNewValue(double rand) {
        if (IsPowerSavingEnabled) {
            return this.baselineEco + rand * this.amplitude;
        }

        return this.baseLine + rand * this.amplitude;
    }
}