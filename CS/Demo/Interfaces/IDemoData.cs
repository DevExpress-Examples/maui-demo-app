using System.Collections.Generic;
using DemoCenter.Maui.Models;

namespace DemoCenter.Maui.Data {
    public interface IDemoData {
        List<DemoItem> DemoItems { get; }
        string Title { get; }
    }
}
