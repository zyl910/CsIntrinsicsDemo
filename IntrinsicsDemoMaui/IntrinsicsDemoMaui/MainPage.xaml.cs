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
        msg += string.Format("Vector256<Byte>.Count={0}, IsHardwareAccelerated={1}. ", Vector256<Byte>.Count, Vector.IsHardwareAccelerated);

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time. " + msg;
        else
            CounterBtn.Text = $"Clicked {count} times. " + msg;

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

