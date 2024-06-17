using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class InvoicesRepository {
        public IList<Invoice> Invoices { get; private set; }

        public InvoicesRepository() {
            System.Reflection.Assembly assembly = GetType().Assembly;
            using Stream stream = assembly.GetManifestResourceStream("Invoices.json");
            using var stringContent = new StreamReader(stream);
            Invoices = JsonSerializer.Deserialize<InvocesObject>(stringContent.ReadToEnd(), TrimmableContext.Default.InvocesObject)?.Invoices;
        }
    }

    public class InvocesObject {
        public List<Invoice> Invoices { get; set; }
    }
}
