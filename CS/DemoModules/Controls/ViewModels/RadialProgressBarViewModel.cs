using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels;

public class RadialProgressBarViewModel : NotificationObject {
    public enum TestStatus { NotStarted, Starting, InProgress, Paused, Finishing, Finished }
    static readonly CompositeFormat ProgressFormat = CompositeFormat.Parse("{0:P0}");

    public static FormattedString GetPlainText(string text) {
        var res = new FormattedString();
        res.Spans.Add(new Span { Text = text, TextColor = ThemeManager.Theme.Scheme.OnSurfaceVariant });

        return res;
    }
    #region Consts
    const int TestCount = 10;
    const int TestPlans = 2;
    const string TapStartToBeginMessage = "Tap \"Start\" to begin \nsystem check";
    const string TestStartingMessage = "Launching tests, please wait";
    const string StartMessage = "Start";
    const string CheckProgressMessage = "Check progress:\n";
    const string PauseText = "Pause";
    const string LaunchingText = "Launching";
    const string PleaseWaitMessage = "Please wait";
    const string MakingReportText = "Making report";
    const string CheckPausedMessage = "Check paused:\n";
    const string ContinueText = "Continue";
    #endregion
    bool[] results;
    bool isPaused;
    TaskCompletionSource completionSource;

    double progress;
    public double Progress {
        get => this.progress;
        set => SetProperty(ref this.progress, value);
    }

    TestStatus status;
    public TestStatus Status {
        get => this.status;
        set => SetProperty(ref this.status, value, OnStatusChanged);
    }

    public Command TapCommand { get; }

    FormattedString helpMessage;
    public FormattedString HelpMessage {
        get => this.helpMessage;
        set => SetProperty(ref this.helpMessage, value);
    }

    string buttonText = StartMessage;
    public string ButtonText {
        get => this.buttonText;
        set => SetProperty(ref this.buttonText, value);
    }

    public RadialProgressBarViewModel() {
        TapCommand = new Command(OnTapped);
        Reset();
    }

    void OnTapped() {
        Status = Status switch {
            TestStatus.NotStarted => TestStatus.Starting,
            TestStatus.InProgress => TestStatus.Paused,
            TestStatus.Paused => TestStatus.InProgress,
            _ => Status
        };
    }

    void OnStatusChanged() {
        switch (Status) {
            case TestStatus.NotStarted:
                Reset();
                break;
            case TestStatus.Starting:
                Starting();
                break;
            case TestStatus.InProgress:
                if (this.isPaused) {
                    Continue();
                } else {
                    Start();
                }
                break;
            case TestStatus.Paused:
                Pause();
                break;
            case TestStatus.Finishing:
                Finishing();
                break;
            case TestStatus.Finished:
                Finish();
                break;
        }
    }

    void Continue() {
        this.completionSource.SetResult();
        this.isPaused = false;
        HelpMessage.Spans[0].Text = CheckProgressMessage;
        ButtonText = PauseText;
    }

    async void Finish() {
        TestReport[] testReports = new TestReport[TestPlans];
        testReports[0] = new(this.results.Take(TestCount).Count(it => it), TestCount, new Color[] { Color.FromArgb("#6486C9"), Color.FromArgb("#DDE5F6") }, "Memory");
        testReports[1] = new(this.results.TakeLast(TestCount).Count(it => it), TestCount, new Color[] { Color.FromArgb("#E56666"), Color.FromArgb("#F6DDDD") }, "CPU");
        Views.RadialProgressBarReportView reportView = new(testReports);
        await Shell.Current.Navigation.PushAsync(reportView);
        Status = TestStatus.NotStarted;
    }

    async void Finishing() {
        HelpMessage = GetPlainText(PleaseWaitMessage);
        ButtonText = MakingReportText;
        await Task.Delay(1500);
        Status = TestStatus.Finished;
    }

    void Pause() {
        HelpMessage.Spans[0].Text = CheckPausedMessage;
        ButtonText = ContinueText;
        this.isPaused = true;
        this.completionSource = new();
    }

    async void Start() {
        HelpMessage = new();
        HelpMessage.Spans.Add(new Span { Text = CheckProgressMessage, TextColor = ThemeManager.Theme.Scheme.OnSurfaceVariant });
        Span progressState = new() {
            FontAttributes = FontAttributes.Bold,
            FontSize = 50d,
            TextColor = ThemeManager.Theme.Scheme.Primary,
            Text = string.Format(CultureInfo.CurrentCulture, ProgressFormat, Progress),
        };
        HelpMessage.Spans.Add(progressState);
        ButtonText = PauseText;
        this.results = await Test();
        Status = TestStatus.Finishing;
    }

    async Task<bool[]> Test() {
        async Task RunSingleTest(Random random, bool[] res, int i) {
            if (this.isPaused) {
                await this.completionSource.Task;
            }
            var delay = random.Next(500, 1000);
            await Task.Delay(delay);
            res[i] = (random.Next() & 1) == 0;
            Progress += 0.05;
            HelpMessage.Spans[1].Text = string.Format(CultureInfo.CurrentCulture, ProgressFormat, Progress);
        }

        Random random = new();
        bool[] res = new bool[TestPlans * TestCount];
        for (int i = 0; i < TestPlans; i++) {
            for (int j = 0; j < TestCount; j++) {
                await RunSingleTest(random, res, j + i * TestCount);
            }
        }

        return res;
    }

    async void Starting() {
        HelpMessage = GetPlainText(TestStartingMessage);
        ButtonText = LaunchingText;
        await Task.Delay(1500);
        Status = TestStatus.InProgress;
    }

    void Reset() {
        Progress = 0d;
        HelpMessage = GetPlainText(TapStartToBeginMessage);
        ButtonText = StartMessage;
    }
}

public record class TestReport(int SuccessfulTestCount, int TotalTestCount, Color[] TestColors, string Name);