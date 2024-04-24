using MyBackend;
using System;
using System.Diagnostics;

namespace MyGui;

public partial class Form1 : Form
{
    readonly ScottPlot.Plot MyPlot;
    readonly UserInputQueue EventMan;
    readonly Stopwatch SW = Stopwatch.StartNew();
    readonly System.Windows.Forms.Timer UpdateTimer = new() { Interval = 10 };

    public Form1()
    {
        InitializeComponent();

        MyPlot = new ScottPlot.Plot();
        MyPlot.FigureBackground.Color = ScottPlot.Color.FromARGB((uint)SystemColors.Control.ToArgb());

        EventMan = new UserInputQueue(MyPlot, pictureBox1.Width, pictureBox1.Height);

        MyPlot.Add.Signal(ScottPlot.Generate.Sin());
        MyPlot.Add.Signal(ScottPlot.Generate.Cos());

        EventMan.EventAdded += (object? s, UserInputEvent e) =>
        {
            button1.Text = $"Show Unprocessed Events ({EventMan.UnprocessedEventCount})";
            button1.Enabled = true;
        };

        EventMan.ActionExecuted += (object? sender, (IUserAction action, UserActionResult result) e) =>
        {
            lblLastAction.Text = $"{SW.Elapsed.TotalSeconds:N2} Executed: {e.action}";
            button1.Text = $"Show Unprocessed Events ({EventMan.UnprocessedEventCount})";
            button1.Enabled = EventMan.UnprocessedEventCount > 0;
            UpdatePlotImage();
        };

        button1.Click += (s, e) =>
        {
            new EventsList(EventMan.Events).ShowDialog();
        };

        UpdateTimer.Tick += (s, e) => UpdatePlotImageIfNeeded();

        SetupEventTriggers();
        UpdatePlotImage();
        UpdateTimer.Start();
    }

    bool RenderNeeded = false;
    private void UpdatePlotImage()
    {
        RenderNeeded = true;
    }

    private void UpdatePlotImageIfNeeded()
    {
        if (!RenderNeeded)
            return;

        byte[] bytes = MyPlot.GetImageBytes(pictureBox1.Width, pictureBox1.Height);
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);
        var old = pictureBox1.Image;
        pictureBox1.Image = bmp;
        old?.Dispose();
        RenderNeeded = false;
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
