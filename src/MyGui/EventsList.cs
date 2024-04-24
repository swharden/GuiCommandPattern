using MyBackend;

namespace MyGui;

public partial class EventsList : Form
{
    public EventsList(IEnumerable<UserInputEvent> events)
    {
        InitializeComponent();

        foreach (UserInputEvent e in events)
        {
            listBox1.Items.Add(e.ToString());
        }
    }
}
