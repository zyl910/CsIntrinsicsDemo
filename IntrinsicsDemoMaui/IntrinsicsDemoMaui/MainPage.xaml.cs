using System.Numerics;
using System.Runtime.Intrinsics;

namespace IntrinsicsDemoMaui;

public partial class MainPage : ContentPage {
    int count = 0;

    public MainPage() {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e) {
        count++;
        string msg = string.Format("Vector<Byte>.Count={0}, IsHardwareAccelerated={1}. ", Vector<Byte>.Count, Vector.IsHardwareAccelerated);
        msg += string.Format("\nVector256<Byte>.Count={0}, IsHardwareAccelerated={1}. ", Vector256<Byte>.Count, Vector.IsHardwareAccelerated);
        InfoEditor.Text = msg;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time. ";
        else
            CounterBtn.Text = $"Clicked {count} times. ";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

