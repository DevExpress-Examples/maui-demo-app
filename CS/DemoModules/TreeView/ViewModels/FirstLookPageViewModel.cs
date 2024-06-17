using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using DemoCenter.Maui.DemoModules.TreeView.Data;
using DemoCenter.Maui.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using System.IO;
using Microsoft.Maui.Storage;
using DevExpress.Maui.Core.Internal;

namespace DemoCenter.Maui.DemoModules.TreeView.ViewModels;

public class FirstLookPageViewModel : NotificationObject {
    public ObservableCollection<ReportLibraryNode> Nodes => root.Nodes;
    public List<ReportLibraryNode> CheckedNodes { get; } = new();

    public Command<ReportLibraryNode> DeleteCommand { get; }
    public Command DeleteCheckedCommand { get; }
    public Command ShareCheckedCommand { get; }
    public Command SelectOrCancelCommand { get; }

    public bool IsSelectMode { get => isSelectMode; set => SetProperty(ref isSelectMode, value); }
    public int CheckedNodesCount { get => checkedNodesCount; set => SetProperty(ref checkedNodesCount, value); }

    public FirstLookPageViewModel() {
        root = ReportLibraryData.Generate();
        DeleteCommand = new(Delete);
        DeleteCheckedCommand = new(DeleteChecked, CanDeleteChecked);
        ShareCheckedCommand = new(ShareChecked, CanShareChecked);
        SelectOrCancelCommand = new(SelectOrCancel);
    }

    public void AddCheckedNode(ReportLibraryNode node) {
        CheckedNodes.Add(node);
        UpdateCheckedNodesCount();
    }
    public void RemoveCheckedNode(ReportLibraryNode node) {
        CheckedNodes.Remove(node);
        UpdateCheckedNodesCount();
    }

    void UpdateCheckedNodesCount() {
        CheckedNodesCount = CheckedNodes.Count;
        DeleteCheckedCommand.ChangeCanExecute();
        ShareCheckedCommand.ChangeCanExecute();
    }
    void SelectOrCancel() {
        if (!IsSelectMode) {
            IsSelectMode = true;
            return;
        }
        IsSelectMode = false;
        foreach (ReportLibraryNode x in CheckedNodes.ToList()) {
            x.IsChecked = false;
        }
        CheckedNodes.Clear();
        UpdateCheckedNodesCount();
    }

    void Delete(ReportLibraryNode x) {
        if (x.IsChecked == true)
            CheckedNodes.Remove(x);
        x.DeleteSelf();
        UpdateCheckedNodesCount();
    }
    void DeleteChecked() {
        CheckedNodes.ForEach(x => x.DeleteSelf());
        CheckedNodes.Clear();
        UpdateCheckedNodesCount();
    }
    bool CanDeleteChecked() {
        return CheckedNodesCount > 0;
    }

    async void ShareChecked() {
        var fileNodes = CheckedNodes
            .Where(x => !x.IsFolder)
            .ToList();
        if (fileNodes.Count == 0)
            return;
        foreach (var node in fileNodes) {
            var fullName = ReportLibraryNode.GetFileName(node);
            var f = await FileSystem.OpenAppPackageFileAsync(fullName);
            var path = Path.Combine(FileSystem.CacheDirectory, node.Name);

            if (!File.Exists(path)) {
                using (var cachedFile = File.Create(path)) {
                    f.CopyTo(cachedFile);
                }
            }
        }

        var files = fileNodes
            .Select(x => new ShareFile(Path.Combine(FileSystem.CacheDirectory, x.Name)))
            .ToList();
        await Share.Default.RequestAsync(new ShareMultipleFilesRequest {
            Title = "Share",
            Files = files
        });
    }
    bool CanShareChecked() {
        return CheckedNodes.Any(x => !x.IsFolder);
    }

    ReportLibraryNode root;
    bool isSelectMode;
    int checkedNodesCount;
}