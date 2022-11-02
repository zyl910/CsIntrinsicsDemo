using IntrinsicsLib;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace IntrinsicsDemoMaui;

[CLSCompliant(false)]
public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) {
        count++;
        string msg = string.Format("Vector<Byte>.Count={0}, IsHardwareAccelerated={1}. ", Vector<Byte>.Count, Vector.IsHardwareAccelerated);
        msg += string.Format("\nVector64<Byte>.Count={0}. ", Vector64<Byte>.Count);
        msg += string.Format("\nVector128<Byte>.Count={0}. ", Vector128<Byte>.Count);
        msg += string.Format("\nVector256<Byte>.Count={0}. ", Vector256<Byte>.Count);
        InfoEditor.Text = msg;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time. ";
        else
            CounterBtn.Text = $"Clicked {count} times. ";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private async void ShowBtn_Clicked(object sender, EventArgs e) {
        string indent = "";
        try {
            //TextWriter tw = Console.Out;
            TextWriter tw = new StringWriter();
            tw.WriteLine("IntrinsicsDemoMaui");
            tw.WriteLine();
            IntrinsicsDemo.OutputEnvironment(tw, indent);
            tw.WriteLine();
            IntrinsicsDemo.Run(tw, indent);
            string? rt = tw.ToString();
            Debug.WriteLine(rt);
            InfoEditor.Text = rt;
            await Clipboard.Default.SetTextAsync(rt);
        } catch (Exception ex) {
            InfoEditor.Text = ex.ToString();
        }
    }

}

