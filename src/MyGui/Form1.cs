using MyBackend;
using System.Diagnostics;

namespace MyGui;

public partial class Form1 : Form
{
    readonly ScottPlot.Plot MyPlot;
    readonly UiEventManager EventMan;
    readonly Stopwatch SW = Stopwatch.StartNew();

    public Form1()
    {
        InitializeComponent();
        MyPlot = new ScottPlot.Plot();
        EventMan = new UiEventManager(MyPlot, pictureBox1.Width, pictureBox1.Height);

        MyPlot.Add.Signal(ScottPlot.Generate.Sin());
        MyPlot.Add.Signal(ScottPlot.Generate.Cos());

        EventMan.EventAdded += (object? s, UiEvent e) =>
        {
            lbInteractions.Items.Add($"{SW.Elapsed.TotalSeconds:N2} {e.Name} X={e.X} Y={e.Y}");
            lbInteractions.SelectedIndex = lbInteractions.Items.Count - 1;
            groupBox1.Text = $"Events ({EventMan.UnprocessedEventCount})";
        };

        EventMan.ActionExecuted += (object? sender, IUiResponse actionExecuted) =>
        {
            lblLastAction.Text = $"{SW.Elapsed.TotalSeconds:N2} Executed: {actionExecuted}";
            lbInteractions.Items.Clear();
            groupBox1.Text = $"Events ({EventMan.UnprocessedEventCount})";
            UpdatePlotImage();
        };

        SetupEventTriggers();
        UpdatePlotImage();
    }

    private void UpdatePlotImage()
    {
        byte[] bytes = MyPlot.GetImageBytes(pictureBox1.Width, pictureBox1.Height);
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        var old = pictureBox1.Image;
        pictureBox1.Image = bmp;
        old?.Dispose();
    }

    private void SetupEventTriggers()
    {
        pictureBox1.MouseMove += (s, e) =>
        {
            EventMan.AddMouseMove(e.X, e.Y);
        };

        pictureBox1.MouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                EventMan.AddLeftDown(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                EventMan.AddRightDown(e.X, e.Y);
            }
        };

        pictureBox1.MouseUp += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                EventMan.AddLeftUp(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                EventMan.AddRightUp(e.X, e.Y);
            }
        };

        pictureBox1.MouseWheel += (s, e) =>
        {
            if (e.Delta < 0)
                EventMan.AddScrollDown(e.X, e.Y);
            else
                EventMan.AddScrollUp(e.X, e.Y);
        };

        KeyPreview = true;
        KeyDown += (s, e) => { };
        KeyUp += (s, e) => { };
    }
}
