using System.Diagnostics;

namespace MyGui;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // invoke local functions on mouse actions
        pictureBox1.MouseMove += PictureBox1_MouseMove;
        pictureBox1.MouseDown += PictureBox1_MouseDown;
        pictureBox1.MouseUp += PictureBox1_MouseUp;


        // invoke local functions on keyboard actions
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
        this.KeyUp += Form1_KeyUp;
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        Keys key = e.KeyCode;
        ProcessAction($"Keyboard PRESS key {key}");
    }

    private void Form1_KeyUp(object? sender, KeyEventArgs e)
    {
        Keys key = e.KeyCode;
        ProcessAction($"Keyboard RELEASE key {key}");
    }

    private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
    {
        Point mouseLocation = e.Location;
        ProcessAction($"Mouse PRESS at {mouseLocation}");
    }

    private void PictureBox1_MouseUp(object? sender, MouseEventArgs e)
    {
        Point mouseLocation = e.Location;
        ProcessAction($"Mouse RELEASE at {mouseLocation}");
    }

    private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
    {
        Point mouseLocation = e.Location;
        ProcessAction($"Mouse MOVE to {mouseLocation}");
    }

    private void ProcessAction(string message)
    {
        // Update the GUI to display information about this action
        listBox1.Items.Add(message);
        listBox1.SelectedIndex = listBox1.Items.Count - 1;

        // Call the backend to give it information about this action.
        // TODO: build some type of class, fill it with information, and pass that to the backend.
        MyBackend.BackendDebug.Print(message);
    }
}
