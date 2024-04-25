using MyBackend;
using System.Diagnostics;

namespace MyGui;

public partial class Form1 : Form
{
    readonly ScottPlot.Plot MyPlot;
    readonly UserInputQueue UserInputQueue;
    readonly System.Windows.Forms.Timer UpdateTimer = new() { Interval = 10 };

    public Form1()
    {
        InitializeComponent();

        MyPlot = new ScottPlot.Plot();
        MyPlot.FigureBackground.Color = ScottPlot.Color.FromARGB((uint)SystemColors.Control.ToArgb());

        UserInputQueue = new UserInputQueue(MyPlot, pictureBox1.Width, pictureBox1.Height);

        MyPlot.Add.Signal(ScottPlot.Generate.Sin());
        MyPlot.Add.Signal(ScottPlot.Generate.Cos());

        UserInputQueue.EventAdded += (object? s, UserInputEvent e) =>
        {
            lblLastEvent.Text = $"Event #{UserInputQueue.UnprocessedEventCount}: {e}";
            gbEvents.Enabled = true;
        };

        int Executions = 0;
        UserInputQueue.ActionExecuted += (object? sender, (IUserAction action, UserActionResult result) e) =>
        {
            string suffix = e.result.ClearEvents ? "and cleared event list" : "";
            lblLastAction.Text = $"Executed action {++Executions} {e.action} {suffix}";
            gbEvents.Enabled = UserInputQueue.UnprocessedEventCount > 0;
            UpdatePlotImage();
        };

        btnShowEvents.Click += (s, e) => new EventsListForm(UserInputQueue.Events).ShowDialog();

        btnClearEvents.Click += (s, e) => UserInputQueue.Clear();

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
            UserInputQueue.AddMouseMove(e.X, e.Y);
        };

        pictureBox1.MouseDown += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                UserInputQueue.AddLeftDown(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                UserInputQueue.AddRightDown(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                UserInputQueue.AddMiddleDown(e.X, e.Y);
            }
        };

        pictureBox1.MouseUp += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                UserInputQueue.AddLeftUp(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                UserInputQueue.AddRightUp(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                UserInputQueue.AddMiddleUp(e.X, e.Y);
            }
        };

        pictureBox1.MouseWheel += (s, e) =>
        {
            if (e.Delta < 0)
                UserInputQueue.AddScrollDown(e.X, e.Y);
            else
                UserInputQueue.AddScrollUp(e.X, e.Y);
        };

        KeyPreview = true;
        KeyDown += (s, e) => { };
        KeyUp += (s, e) => { };
    }
}
