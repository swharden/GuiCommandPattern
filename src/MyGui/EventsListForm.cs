using MyBackend;

namespace MyGui;

public partial class EventsListForm : Form
{
    public EventsListForm(IEnumerable<UserInputEvent> events)
    {
        InitializeComponent();

        foreach (UserInputEvent e in events)
        {
            listBox1.Items.Add(e.ToString());
        }
    }
}
